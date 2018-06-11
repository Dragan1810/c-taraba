using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    class Profesor
    {
        private int id;
        private string ime;
        private string prezime;
        private string zvanje;
        private List<Predmet> predmeti;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Ime
        {
            get { return ime; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti ime profesora!!!");
                ime = value;
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti prezime profesora!!!");
                prezime = value;
            }
        }

        public string Zvanje
        {
            get { return zvanje; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti zvanje profesora!!!");
                zvanje = value;
            }
        }

        public List<Predmet> Predmeti
        {
            get { return predmeti; }
            set { predmeti = value; }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SSluzbaDB.mdf;Integrated Security=True";

        public void dodajProfesora()
        {
            string insertSql = "INSERT INTO T_PROFESOR " +
                "(Ime, Prezime, Zvanje) VALUES " +
                "(@Ime, @Prezime, @Zvanje)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@Ime", Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", Prezime));
                command.Parameters.Add(new SqlParameter("@Zvanje", Zvanje));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void azurirajProfesora()
        {
            string updateSql =
                "UPDATE T_PROFESOR " +
                "SET Ime= @Ime, Prezime = @Prezime, Zvanje = @Zvanje " +
                "WHERE ProfesorId = @ProfesorId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@ProfesorId", ID));
                command.Parameters.Add(new SqlParameter("@Ime", Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", Prezime));
                command.Parameters.Add(new SqlParameter("@Zvanje", Zvanje));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void obrisiProfesora()
        {
            string deleteSql =
                "DELETE FROM T_PROFESOR WHERE ProfesorId = @ProfesorId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@ProfesorId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Profesor> ucitajProfesore()
        {
            ObservableCollection<Profesor> profesori = new ObservableCollection<Profesor>();
            string queryString =
                "SELECT * FROM T_PROFESOR;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Profesor prof;
                    while (reader.Read())
                    {
                        prof = new Profesor();
                        prof.ID = Int32.Parse(reader["ProfesorId"].ToString());
                        prof.Ime = reader["Ime"].ToString();
                        prof.Prezime = reader["Prezime"].ToString();
                        prof.Zvanje = reader["Zvanje"].ToString();
                        profesori.Add(prof);
                    }
                }
            }
            return profesori;

        }
        }
    }
