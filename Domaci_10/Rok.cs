using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Rok
    {
        private int id;
        private string naziv;
        private string tip;

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
                    throw new Exception("Morate uneti naziv roka!!!");
                naziv = value;
            }
        }

        public string Tip
        {
            get { return tip; }
            set
            {
                if (value == "")
                    throw new Exception("Morate tip roka!!!");
                tip = value;
            }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SSluzbaDB.mdf;Integrated Security=True";

        public void dodajRok()
        {
            string insertSql = "INSERT INTO T_ROK " +
                "(Naziv, Tip) VALUES (@Naziv, @Tip)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@Naziv", Naziv));
                command.Parameters.Add(new SqlParameter("@Tip", Tip));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void azurirajRok()
        {
            string updateSql =
                "UPDATE T_ROK " +
                "SET Naziv = @Naziv, Tip= @Tip " +
                "WHERE RokId = @RokId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@RokId", ID));
                command.Parameters.Add(new SqlParameter("@Naziv", Naziv));
                command.Parameters.Add(new SqlParameter("@Tip", Tip));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void obrisiRok()
        {
            string deleteSql =
                "DELETE FROM T_ROK WHERE RokId = @RokId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@RokId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Rok> ucitajRokove()
        {
            ObservableCollection<Rok> rokovi = new ObservableCollection<Rok>();
            string queryString =
                "SELECT * FROM T_ROK;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Rok rok;
                    while (reader.Read())
                    {
                        rok = new Rok();
                        rok.ID = Int32.Parse(reader["RokId"].ToString());
                        rok.Naziv = reader["Naziv"].ToString();
                        rok.Tip = reader["Tip"].ToString();
                        rokovi.Add(rok);
                    }
                }
            }
            return rokovi;
        }
    }

}
