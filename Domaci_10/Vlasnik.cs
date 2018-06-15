using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Vlasnik
    {
        private int id;
        private string ime;
        private string prezime;
        private string redniBroj;

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
                    throw new Exception("Morate uneti ime vlasnika!!!");
                ime = value;
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti prezime vlasnika!!!");
                prezime = value;
            }
        }

        public string RedniBroj
        {
            get { return redniBroj; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti redni Broj!!!");
                redniBroj = value;
            }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\WorkShop.mdf;Integrated Security=True";

        public void dodajVlasnika()
        {
            string insertSql = "INSERT INTO T_VLASNIK " +
                "(RedniBroj, Ime, Prezime) VALUES " +
                "(@RedniBroj, @Ime, @Prezime)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@RedniBroj", redniBroj));
                command.Parameters.Add(new SqlParameter("@Ime", Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", Prezime));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void azurirajVlasnika()
        {
            string updateSql =
                "UPDATE T_VLASNIK " +
                "SET RedniBroj = @RedniBroj, Ime= @Ime, Prezime = @Prezime " +
                "WHERE StudentId = @StudentId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@VlasnikId", ID));
                command.Parameters.Add(new SqlParameter("@RedniBroj", redniBroj));
                command.Parameters.Add(new SqlParameter("@Ime", Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", Prezime));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void obrisiVlasnika()
        {
            string deleteSql =
                "DELETE FROM T_VLASNIK WHERE VlasnikId = @VlasnikId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@VlasnikId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Vlasnik> ucitajVlasnike()
        {
            ObservableCollection<Vlasnik> vlasnici = new ObservableCollection<Vlasnik>();
            string queryString =
                "SELECT * FROM T_VLASNIK;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Vlasnik vlasnik;
                    while (reader.Read())
                    {
                        vlasnik = new Vlasnik();
                        vlasnik.ID = Int32.Parse(reader["VlasnikId"].ToString());
                        vlasnik.RedniBroj = reader["RedniBroj"].ToString();
                        vlasnik.Ime = reader["Ime"].ToString();
                        vlasnik.Prezime = reader["Prezime"].ToString();
                        vlasnici.Add(vlasnik);
                    }
                }
            }
            return vlasnici;
        }

    }

}
