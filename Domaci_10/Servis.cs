using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Servis
    {
        private int id;
        private Vrsta vrsta;
        private Vlasnik vlasnik;
        private DateTime datum;
        private ObservableCollection<Auto> autos;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Vrsta Vrsta
        {
            get { return vrsta; }
            set { vrsta = value; }
        }

        public Vlasnik Vlasnik
        {
            get { return vlasnik; }
            set { vlasnik = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public ObservableCollection<Auto> Autos
        {
            get { return autos; }
            set { autos = value; }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\WorkShop.mdf;Integrated Security=True";

        public void dodajServis()
        {
            string insertServisSql = "INSERT INTO T_SERVIS " +
                "(VrstaId, VlasnikId, Datum) VALUES " +
                "(@VrstaId, @VlasnikId, @Datum);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            string insertServisAutoSql = "INSERT INTO T_AUTO_SERVIS " +
                "(AutoId, ServisId) VALUES " +
                "(@AutoId, @ServisId);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand servisCommand = connection.CreateCommand();
                servisCommand.CommandText = insertServisSql;
                servisCommand.Parameters.Add(new SqlParameter("@VrstaId", Vrsta.ID));
                servisCommand.Parameters.Add(new SqlParameter("@VlasnikId", Vlasnik.ID));
                servisCommand.Parameters.Add(new SqlParameter("@Datum", Datum));
                connection.Open();
                int insertedId = (int)servisCommand.ExecuteScalar();

                SqlCommand servisAutoCommand = connection.CreateCommand();
                servisAutoCommand.CommandText = insertServisAutoSql;
                foreach (Auto auto in Autos)
                {
                    servisAutoCommand.Parameters.Clear();
                    servisAutoCommand.Parameters.Add(new SqlParameter("@AutoId", auto.ID));
                    servisAutoCommand.Parameters.Add(new SqlParameter("@ServisId", insertedId));
                    servisAutoCommand.ExecuteNonQuery();
                }
            }
        }

        public void azurirajServis()
        {
            string updateServisSql =
                "UPDATE T_SERVIS " +
                "SET VrstaId = @VrstaId, VlasnikId= @VlasnikId, Datum = @Datum " +
                "WHERE ServisId = @ServisId;";
            string deleteServisAutoSql =
                "DELETE T_AUTO_SERVIS WHERE ServisId = @ServisId";
            string insertServisAutoSql =
                "INSERT INTO T_AUTO_SERVIS " +
                "(AutoId, ServisId) VALUES " +
                "(@AutoId, @ServisId);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand updateCommand = connection.CreateCommand();
                updateCommand.CommandText = updateServisSql;
                updateCommand.Parameters.Add(new SqlParameter("@ServisId", ID));
                updateCommand.Parameters.Add(new SqlParameter("@VrstaId", Vrsta.ID));
                updateCommand.Parameters.Add(new SqlParameter("@VlasnikId", Vlasnik.ID));
                updateCommand.Parameters.Add(new SqlParameter("@Datum", Datum));
                connection.Open();
                updateCommand.ExecuteNonQuery();

                SqlCommand deleteCommand = connection.CreateCommand();
                deleteCommand.CommandText = deleteServisAutoSql;
                deleteCommand.Parameters.Add(new SqlParameter("@ServisId", ID));
                deleteCommand.ExecuteNonQuery();

                SqlCommand prijavaPredmetCommand = connection.CreateCommand();
                prijavaPredmetCommand.CommandText = insertServisAutoSql;
                foreach (Auto auto in Autos)
                {
                    prijavaPredmetCommand.Parameters.Clear();
                    prijavaPredmetCommand.Parameters.Add(new SqlParameter("@AutoId", auto.ID));
                    prijavaPredmetCommand.Parameters.Add(new SqlParameter("@ServisId", ID));
                    prijavaPredmetCommand.ExecuteNonQuery();
                }
            }
        }

        public void obrisiServis()
        {
            string deleteSql =
                "DELETE FROM T_AUTO_SERVIS WHERE ServisId = @ServisId;" +
                "DELETE FROM T_SERVIS WHERE ServisId = @ServisId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@ServisId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Servis> ucitajServise()
        {
            ObservableCollection<Servis> servisi = new ObservableCollection<Servis>();
            string queryString =
                @"SELECT auto.AutoId, auto.Naziv AS NazivAuta, auto.Godiste, auto.Sifra, servis.ServisId, servis.Datum, vlasnik.VlasnikId, vlasnik.RedniBroj, vlasnik.Ime, vlasnik.Prezime, vrsta.VrstaId, vrsta.Naziv AS VrstaServisa
                  FROM T_AUTO auto, T_SERVIS servis, T_AUTO_SERVIS ass, T_VLASNIK vlasnik, T_VRSTA vrsta
                  WHERE auto.AutoId=ass.AutoId AND servis.ServisId=ass.ServisId AND servis.VlasnikId=vlasnik.VlasnikId AND servis.VrstaId=vrsta.VrstaId 
                  ORDER BY servis.ServisId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int prethodniIdServis = 0;
                    Servis servis = new Servis();
                    while (reader.Read())
                    {
                        int idServis = Int32.Parse(reader["ServisId"].ToString());
                        if (idServis != prethodniIdServis)
                        {
                            prethodniIdServis = idServis;
                            servis = new Servis();
                            servisi.Add(servis);
                            servis.ID = idServis;

                            Vrsta vrsta = new Vrsta();
                            vrsta.ID = Int32.Parse(reader["VrstaId"].ToString());
                            vrsta.Naziv = reader["VrstaServisa"].ToString();
                            servis.Vrsta = vrsta;

                            Vlasnik vlasnik = new Vlasnik();
                            vlasnik.ID = Int32.Parse(reader["VlasnikId"].ToString());
                            vlasnik.RedniBroj = reader["RedniBroj"].ToString();
                            vlasnik.Ime = reader["Ime"].ToString();
                            vlasnik.Prezime = reader["Prezime"].ToString();

                            servis.Vlasnik = vlasnik;
                            servis.Datum = DateTime.Parse(reader["Datum"].ToString());
                            servis.Autos = new ObservableCollection<Auto>();
                        }
                        Auto auto = new Auto();
                        auto.ID = Int32.Parse(reader["AutoId"].ToString());
                        auto.Naziv = reader["NazivAuta"].ToString();
                        auto.Godiste = Int32.Parse(reader["Godiste"].ToString());
                        auto.Sifra = reader["Sifra"].ToString();
                        servis.Autos.Add(auto);
                        //servis.Auto = auto;
                    }
                }
            }
            return servisi;
        }
    }

}
