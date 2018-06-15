using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Vrsta
    {
        private int id;
        private string naziv;

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
                    throw new Exception("Morate uneti vrstu Sevisa!!!");
                naziv = value;
            }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\WorkShop.mdf;Integrated Security=True";

        public void dodajVrstu()
        {
            string insertSql = "INSERT INTO T_VRSTA " +
                "(Naziv) VALUES (@Naziv)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@Naziv", Naziv));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void azurirajVrstu()
        {
            string updateSql =
                "UPDATE T_VRSTA " +
                "SET Naziv = @Naziv " +
                "WHERE VrstaId = @VrstaId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@VrstaId", ID));
                command.Parameters.Add(new SqlParameter("@Naziv", Naziv));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void obrisiVrstu()
        {
            string deleteSql =
                "DELETE FROM T_VRSTA WHERE VrstaId = @VrstaId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@VrstaId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Vrsta> ucitajVrste()
        {
            ObservableCollection<Vrsta> vrste = new ObservableCollection<Vrsta>();
            string queryString =
                "SELECT * FROM T_VRSTA;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Vrsta vrsta;
                    while (reader.Read())
                    {
                        vrsta = new Vrsta();
                        vrsta.ID = Int32.Parse(reader["VrstaId"].ToString());
                        vrsta.Naziv = reader["Naziv"].ToString();
                        vrste.Add(vrsta);
                    }
                }
            }
            return vrste;
        }
    }

}
