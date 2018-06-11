using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Predmet
    {
        private int id;
        private string naziv;
        private int espb;
        private string sifra;
        private Profesor profesor;
        private bool selektovan;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti naziv predmeta!!!");
                naziv = value;
            }
        }

        public int ESPB
        {
            get { return espb; }
            set
            {
                if (value == 0)
                    throw new Exception("Morate uneti ESPB poene!!!");
                espb = value;
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti šifru predmeta!!!");
                sifra = value;
            }
        }

        public Profesor Profesor
        {
            get { return profesor; }
            set
            {
                if (value?.ID == 0)
                    throw new Exception("Morate uneti Profesora!!!");
                profesor = value;
            }
        }

        public bool Selektovan
        {
            get { return selektovan; }
            set { selektovan = value; }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SSluzbaDB.mdf;Integrated Security=True";

        public void dodajPredmet()
        {
            string insertSql = "INSERT INTO T_PREDMET " +
                "(Naziv, ESPB, Sifra, ProfesorId) VALUES " +
                "(@Naziv, @ESPB, @Sifra, @ProfesorId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@Naziv", Naziv));
                command.Parameters.Add(new SqlParameter("@ESPB", ESPB));
                command.Parameters.Add(new SqlParameter("@Sifra", Sifra));
                command.Parameters.Add(new SqlParameter("@ProfesorId", Profesor.ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void azurirajPredmet()
        {
            string updateSql =
                "UPDATE T_PREDMET " +
                "SET Naziv = @Naziv, ESPB= @ESPB, Sifra = @Sifra, ProfesorId = @ProfesorId " +
                "WHERE PredmetId = @PredmetId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@PredmetId", ID));
                command.Parameters.Add(new SqlParameter("@Naziv", Naziv));
                command.Parameters.Add(new SqlParameter("@ESPB", ESPB));
                command.Parameters.Add(new SqlParameter("@Sifra", Sifra));
                command.Parameters.Add(new SqlParameter("@ProfesorId", Profesor.ID));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void obrisiPredmet()
        {
            string deleteSql =
                "DELETE FROM T_PREDMET WHERE PredmetId = @PredmetId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@PredmetId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Predmet> ucitajPredmete()
        {
            ObservableCollection<Predmet> predmeti = new ObservableCollection<Predmet>();
            string queryString =
                "SELECT " +
                " pred.PredmetId, pred.Naziv, pred.ESPB, pred.Sifra, " +
                " prof.ProfesorId, prof.Ime, prof.Prezime, prof.Zvanje " +
                "FROM T_PREDMET pred, T_PROFESOR prof " +
                "WHERE pred.ProfesorId = prof.ProfesorId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Predmet predmet;
                    while (reader.Read())
                    {
                        predmet = new Predmet();
                        predmet.ID = Int32.Parse(reader["PredmetId"].ToString());
                        predmet.Naziv = reader["Naziv"].ToString();
                        predmet.ESPB = Int32.Parse(reader["ESPB"].ToString());
                        predmet.Sifra = reader["Sifra"].ToString();
                        predmet.profesor = new Profesor();
                        predmet.profesor.ID = Int32.Parse(reader["ProfesorId"].ToString());
                        predmet.profesor.Ime = reader["Ime"].ToString();
                        predmet.profesor.Prezime = reader["Prezime"].ToString();
                        predmet.profesor.Zvanje = reader["Zvanje"].ToString();
                        predmeti.Add(predmet);
                    }
                }
            }
            return predmeti;
        }

        public ObservableCollection<Predmet> ucitajPredmeteZaProfesora(int profesorId)
        {
            ObservableCollection<Predmet> predmeti = new ObservableCollection<Predmet>();
            string queryString =
                "SELECT " +
                " pred.PredmetId, pred.Naziv, pred.ESPB, pred.Sifra, " +
                " prof.ProfesorId, prof.Ime, prof.Prezime, prof.Zvanje " +
                "FROM T_PREDMET pred, T_PROFESOR prof " +
                "WHERE pred.ProfesorId = prof.ProfesorId AND prof.ProfesorId = @ProfesorId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                command.Parameters.Add(new SqlParameter("@ProfesorId", profesorId));
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Predmet predmet;
                    while (reader.Read())
                    {
                        predmet = new Predmet();
                        predmet.ID = Int32.Parse(reader["PredmetId"].ToString());
                        predmet.Naziv = reader["Naziv"].ToString();
                        predmet.ESPB = Int32.Parse(reader["ESPB"].ToString());
                        predmet.Sifra = reader["Sifra"].ToString();
                        predmet.profesor = new Profesor();
                        predmet.profesor.ID = Int32.Parse(reader["ProfesorId"].ToString());
                        predmet.profesor.Ime = reader["Ime"].ToString();
                        predmet.profesor.Prezime = reader["Prezime"].ToString();
                        predmet.profesor.Zvanje = reader["Zvanje"].ToString();
                        predmeti.Add(predmet);
                    }
                }
            }
            return predmeti;
        }
    }

}
