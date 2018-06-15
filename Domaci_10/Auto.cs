using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Auto
    {
        private int id;
        private string naziv;
        private int godiste;
        private string sifra;
        private Mehanicar mehanicar;
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
                    throw new Exception("Morate uneti naziv Auta!!!");
                naziv = value;
            }
        }

        public int Godiste
        {
            get { return godiste; }
            set
            {
                if (value == 0)
                    throw new Exception("Morate uneti Godiste!!!");
                godiste = value;
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti šifru Auta!!!");
                sifra = value;
            }
        }

        public Mehanicar Mehanicar
        {
            get { return mehanicar; }
            set
            {
                if (value?.ID == 0)
                    throw new Exception("Morate uneti Mehanicara!!!");
                mehanicar = value;
            }
        }

        public bool Selektovan
        {
            get { return selektovan; }
            set { selektovan = value; }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\WorkShop.mdf;Integrated Security=True";

        public void dodajAuto()
        {
            string insertSql = "INSERT INTO T_AUTO " +
                "(Naziv, Godiste, Sifra, MehanicarId) VALUES " +
                "(@Naziv, @Godiste, @Sifra, @MehanicarId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@Naziv", Naziv));
                command.Parameters.Add(new SqlParameter("@Godiste", Godiste));
                command.Parameters.Add(new SqlParameter("@Sifra", Sifra));
                command.Parameters.Add(new SqlParameter("@MehanicarId", Mehanicar.ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void azurirajAuto()
        {
            string updateSql =
                "UPDATE T_AUTO " +
                "SET Naziv = @Naziv, Godiste= @Godiste, Sifra = @Sifra, MehanicarId = @MehanicarId " +
                "WHERE PredmetId = @PredmetId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@PredmetId", ID));
                command.Parameters.Add(new SqlParameter("@Naziv", Naziv));
                command.Parameters.Add(new SqlParameter("@Godiste", Godiste));
                command.Parameters.Add(new SqlParameter("@Sifra", Sifra));
                command.Parameters.Add(new SqlParameter("@MehanicarId", Mehanicar.ID));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void obrisiAuto()
        {
            string deleteSql =
                "DELETE FROM T_AUTO WHERE AutoId = @AutoId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@AutoId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Auto> ucitajAuto()
        {
            ObservableCollection<Auto> autos = new ObservableCollection<Auto>();
            string queryString =
                "SELECT " +
                " auto.AutoId, auto.Naziv, auto.Godiste, auto.Sifra, " +
                " mehanicar.MehanicarId, mehanicar.Ime, mehanicar.Prezime " +
                "FROM T_AUTO auto, T_MEHANICAR mehanicar " +
                "WHERE auto.MehanicarId = mehanicar.MehanicarId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Auto auto;
                    while (reader.Read())
                    {
                        auto = new Auto();
                        auto.ID = Int32.Parse(reader["AutoId"].ToString());
                        auto.Naziv = reader["Naziv"].ToString();
                        auto.Godiste = Int32.Parse(reader["Godiste"].ToString());
                        auto.Sifra = reader["Sifra"].ToString();
                        auto.mehanicar = new Mehanicar();
                        auto.mehanicar.ID = Int32.Parse(reader["MehanicarId"].ToString());
                        auto.mehanicar.Ime = reader["Ime"].ToString();
                        auto.mehanicar.Prezime = reader["Prezime"].ToString();
                        autos.Add(auto);
                    }
                }
            }
            return autos;
        }

        public ObservableCollection<Auto> ucitajPredmeteZaProfesora(int mehanicarId)
        {
            ObservableCollection<Auto> autos = new ObservableCollection<Auto>();
            string queryString =
                "SELECT " +
                " auto.AutoId, auto.Naziv, auto.Godiste, auto.Sifra, " +
                " mehanicar.MehanicarId, mehanicar.Ime, mehanicar.Prezime " +
                "FROM T_AUTO auto, T_MEHANICAR mehanicar " +
                "WHERE auto.MehanicarId = mehanicar.MehanicarId AND mehanicar.MehanicarId = @MehanicarId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                command.Parameters.Add(new SqlParameter("@MehanicarId", mehanicarId));
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Auto auto;
                    while (reader.Read())
                    {
                        auto = new Auto();
                        auto.ID = Int32.Parse(reader["AutoId"].ToString());
                        auto.Naziv = reader["Naziv"].ToString();
                        auto.Godiste = Int32.Parse(reader["Godiste"].ToString());
                        auto.Sifra = reader["Sifra"].ToString();
                        auto.mehanicar = new Mehanicar();
                        auto.mehanicar.ID = Int32.Parse(reader["MehanicarId"].ToString());
                        auto.mehanicar.Ime = reader["Ime"].ToString();
                        auto.mehanicar.Prezime = reader["Prezime"].ToString();
                        autos.Add(auto);
                    }
                }
            }
            return autos;
        }
    }

}
