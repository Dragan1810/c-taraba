using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Prijava
    {
        private int id;
        private Rok rok;
        private Student student;
        private DateTime datum;
        private ObservableCollection<Predmet> predmeti;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Rok Rok
        {
            get { return rok; }
            set { rok = value; }
        }

        public Student Student
        {
            get { return student; }
            set { student = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public ObservableCollection<Predmet> Predmeti
        {
            get { return predmeti; }
            set { predmeti = value; }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SSluzbaDB.mdf;Integrated Security=True";

        public void dodajPrijavu()
        {
            string insertPrijavaSql = "INSERT INTO T_PRIJAVA " +
                "(RokId, StudentId, Datum) VALUES " +
                "(@RokId, @StudentId, @Datum);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            string insertPrijavaPredmetSql = "INSERT INTO T_PREDMET_PRIJAVA " +
                "(PredmetId, PrijavaId) VALUES " +
                "(@PredmetId, @PrijavaId);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand prijavaCommand = connection.CreateCommand();
                prijavaCommand.CommandText = insertPrijavaSql;
                prijavaCommand.Parameters.Add(new SqlParameter("@RokId", Rok.ID));
                prijavaCommand.Parameters.Add(new SqlParameter("@StudentId", Student.ID));
                prijavaCommand.Parameters.Add(new SqlParameter("@Datum", Datum));
                connection.Open();
                int insertedId = (int)prijavaCommand.ExecuteScalar();

                SqlCommand prijavaPredmetCommand = connection.CreateCommand();
                prijavaPredmetCommand.CommandText = insertPrijavaPredmetSql;
                foreach (Predmet pred in Predmeti)
                {
                    prijavaPredmetCommand.Parameters.Clear();
                    prijavaPredmetCommand.Parameters.Add(new SqlParameter("@PredmetId", pred.ID));
                    prijavaPredmetCommand.Parameters.Add(new SqlParameter("@PrijavaId", insertedId));
                    prijavaPredmetCommand.ExecuteNonQuery();
                }
            }
        }

        public void azurirajPrijavu()
        {
            string updatePrijavaSql =
                "UPDATE T_PRIJAVA " +
                "SET RokId = @RokId, StudentId= @StudentId, Datum = @Datum " +
                "WHERE PrijavaId = @PrijavaId;";
            string deletePrijavaPredmetSql =
                "DELETE T_PREDMET_PRIJAVA WHERE PrijavaId = @PrijavaId";
            string insertPrijavaPredmetSql =
                "INSERT INTO T_PREDMET_PRIJAVA " +
                "(PredmetId, PrijavaId) VALUES " +
                "(@PredmetId, @PrijavaId);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand updateCommand = connection.CreateCommand();
                updateCommand.CommandText = updatePrijavaSql;
                updateCommand.Parameters.Add(new SqlParameter("@PrijavaId", ID));
                updateCommand.Parameters.Add(new SqlParameter("@RokId", Rok.ID));
                updateCommand.Parameters.Add(new SqlParameter("@StudentId", Student.ID));
                updateCommand.Parameters.Add(new SqlParameter("@Datum", Datum));
                connection.Open();
                updateCommand.ExecuteNonQuery();

                SqlCommand deleteCommand = connection.CreateCommand();
                deleteCommand.CommandText = deletePrijavaPredmetSql;
                deleteCommand.Parameters.Add(new SqlParameter("@PrijavaId", ID));
                deleteCommand.ExecuteNonQuery();

                SqlCommand prijavaPredmetCommand = connection.CreateCommand();
                prijavaPredmetCommand.CommandText = insertPrijavaPredmetSql;
                foreach (Predmet pred in Predmeti)
                {
                    prijavaPredmetCommand.Parameters.Clear();
                    prijavaPredmetCommand.Parameters.Add(new SqlParameter("@PredmetId", pred.ID));
                    prijavaPredmetCommand.Parameters.Add(new SqlParameter("@PrijavaId", ID));
                    prijavaPredmetCommand.ExecuteNonQuery();
                }
            }
        }

        public void obrisiPrijavu()
        {
            string deleteSql =
                "DELETE FROM T_PREDMET_PRIJAVA WHERE PrijavaId = @PrijavaId;" +
                "DELETE FROM T_PRIJAVA WHERE PrijavaId = @PrijavaId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@PrijavaId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Prijava> ucitajPrijave()
        {
            ObservableCollection<Prijava> prijave = new ObservableCollection<Prijava>();
            string queryString =
                "SELECT " +
                " pred.PredmetId, pred.Naziv as NazivPredmeta, pred.ESPB, pred.Sifra, " +
                " pri.PrijavaId, pri.Datum, " +
                " stud.StudentId, stud.BrojIndeksa, stud.Ime, stud.Prezime, stud.Smer, " +
                " rok.RokId, rok.Naziv as NazivRoka, rok.Tip " +
                "FROM T_PREDMET pred, T_PRIJAVA pri, T_PREDMET_PRIJAVA pp, " +
                "     T_STUDENT stud, T_ROK rok " +
                "WHERE pred.PredmetId = pp.PredmetId AND pri.PrijavaId = pp.PrijavaId AND " +
                "      pri.StudentId = stud.StudentId AND pri.RokId = rok.RokId " +
                "ORDER BY pri.PrijavaId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int prethodniIdPrijave = 0;
                    Prijava prijava = new Prijava();
                    while (reader.Read())
                    {
                        int idPrijave = Int32.Parse(reader["PrijavaId"].ToString());
                        if (idPrijave != prethodniIdPrijave)
                        {
                            prethodniIdPrijave = idPrijave;
                            prijava = new Prijava();
                            prijave.Add(prijava);
                            prijava.ID = idPrijave;

                            Rok rok = new Rok();
                            rok.ID = Int32.Parse(reader["RokId"].ToString());
                            rok.Naziv = reader["NazivRoka"].ToString();
                            rok.Tip = reader["Tip"].ToString();
                            prijava.Rok = rok;

                            Student student = new Student();
                            student.ID = Int32.Parse(reader["StudentId"].ToString());
                            student.Indeks = reader["BrojIndeksa"].ToString();
                            student.Ime = reader["Ime"].ToString();
                            student.Prezime = reader["Prezime"].ToString();
                            student.Smer = reader["Smer"].ToString();

                            prijava.Student = student;
                            prijava.Datum = DateTime.Parse(reader["Datum"].ToString());
                            prijava.Predmeti = new ObservableCollection<Predmet>();
                        }
                        Predmet predmet = new Predmet();
                        predmet.ID = Int32.Parse(reader["PredmetId"].ToString());
                        predmet.Naziv = reader["NazivPredmeta"].ToString();
                        predmet.ESPB = Int32.Parse(reader["ESPB"].ToString());
                        predmet.Sifra = reader["Sifra"].ToString();
                        prijava.Predmeti.Add(predmet);
                    }
                }
            }
            return prijave;
        }
    }

}
