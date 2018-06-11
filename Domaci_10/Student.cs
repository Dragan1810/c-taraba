using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_10
{
    public class Student
    {
        private int id;
        private string ime;
        private string prezime;
        private string indeks;
        private string smer;

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
                    throw new Exception("Morate uneti ime ucenika!!!");
                ime = value;
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti prezime ucenika!!!");
                prezime = value;
            }
        }

        public string Indeks
        {
            get { return indeks; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti indeks ucenika!!!");
                indeks = value;
            }
        }

        public string Smer
        {
            get { return smer; }
            set
            {
                if (value == "")
                    throw new Exception("Morate uneti smer ucenika!!!");
                smer = value;
            }
        }

        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SSluzbaDB.mdf;Integrated Security=True";

        public void dodajStudenta()
        {
            string insertSql = "INSERT INTO T_STUDENT " +
                "(BrojIndeksa, Ime, Prezime, Smer) VALUES " +
                "(@BrojIndeksa, @Ime, @Prezime, @Smer)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@BrojIndeksa", Indeks));
                command.Parameters.Add(new SqlParameter("@Ime", Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", Prezime));
                command.Parameters.Add(new SqlParameter("@Smer", Smer));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void azurirajStudenta()
        {
            string updateSql =
                "UPDATE T_STUDENT " +
                "SET BrojIndeksa = @BrojIndeksa, Ime= @Ime, Prezime = @Prezime, Smer = @Smer " +
                "WHERE StudentId = @StudentId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@StudentId", ID));
                command.Parameters.Add(new SqlParameter("@BrojIndeksa", Indeks));
                command.Parameters.Add(new SqlParameter("@Ime", Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", Prezime));
                command.Parameters.Add(new SqlParameter("@Smer", Smer));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void obrisiStudenta()
        {
            string deleteSql =
                "DELETE FROM T_STUDENT WHERE StudentId = @StudentId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@StudentId", ID));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Student> ucitajStudente()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            string queryString =
                "SELECT * FROM T_STUDENT;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Student stud;
                    while (reader.Read())
                    {
                        stud = new Student();
                        stud.ID = Int32.Parse(reader["StudentId"].ToString());
                        stud.Indeks = reader["BrojIndeksa"].ToString();
                        stud.Ime = reader["Ime"].ToString();
                        stud.Prezime = reader["Prezime"].ToString();
                        stud.Smer = reader["Smer"].ToString();
                        students.Add(stud);
                    }
                }
            }
            return students;
        }

    }

}
