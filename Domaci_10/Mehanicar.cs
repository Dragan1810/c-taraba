using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Mehanicar
    {
        private int id;
        private string ime;
        private string prezime;
        private List<Auto> autos;

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
                    throw new Exception("Morate uneti ime mehanicara!!!");
                ime = value;
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti prezime mehanicara!!!");
                prezime = value;
            }
        }



        public List<Auto> Autos
        {
            get { return autos; }
            set { autos = value; }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\WorkShop.mdf;Integrated Security=True";

        public void DodajMehanicara()
        {
            string insertSql = "INSERT INTO T_MEHANICAR " +
                "(Ime, Prezime) VALUES " +
                "(@Ime, @Prezime)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@Ime", Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", Prezime));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void AzurirajMehanicara()
        {
            string updateSql =
                "UPDATE T_MEHANICAR " +
                "SET Ime=@Ime, Prezime=@Prezime " +
                "WHERE MehanicarId=@MehanicarId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@MehanicarId", ID));
                command.Parameters.Add(new SqlParameter("@Ime", Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", Prezime));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void ObrisiMehanicara()
        {
            string deleteSql =
                "DELETE FROM T_MEHANICAR WHERE MehanicarId = @MehanicarId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@MehanicarId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Mehanicar> UcitajMehanicare()
        {
            ObservableCollection<Mehanicar> mehanicari = new ObservableCollection<Mehanicar>();
            string queryString =
                "SELECT * FROM T_MEHANICAR;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Mehanicar mehanicar;
                    while (reader.Read())
                    {
                        mehanicar = new Mehanicar();
                        mehanicar.ID = Int32.Parse(reader["MehanicarId"].ToString());
                        mehanicar.Ime = reader["Ime"].ToString();
                        mehanicar.Prezime = reader["Prezime"].ToString();
                        mehanicari.Add(mehanicar);
                    }
                }
            }
            return mehanicari;

        }
        public void UpisiJSON()
        {
            ObservableCollection<Mehanicar> mehanicari = new ObservableCollection<Mehanicar>();
            string queryString =
                "SELECT * FROM T_MEHANICAR;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Mehanicar mehanicar;
                    while (reader.Read())
                    {
                        mehanicar = new Mehanicar();
                        mehanicar.ID = Int32.Parse(reader["MehanicarId"].ToString());
                        mehanicar.Ime = reader["Ime"].ToString();
                        mehanicar.Prezime = reader["Prezime"].ToString();
                        mehanicari.Add(mehanicar);
                    }
                }
            }
            string json = JsonConvert.SerializeObject(mehanicari);
            File.WriteAllText("./data.json", json);
        }

        public ObservableCollection<Mehanicar> UcitajJSON()
        {
            ObservableCollection<Mehanicar> items;
            using (StreamReader r = new StreamReader("data.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<ObservableCollection<Mehanicar>>(json);
            }
            return items;
           
        }
    }
    }
