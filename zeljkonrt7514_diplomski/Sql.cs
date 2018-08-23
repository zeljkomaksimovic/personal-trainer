using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace zeljkonrt7514_diplomski
{
    class Sql
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NutritionConnectionStringLocal"].ConnectionString;
        //SELECT
        public DataTable Select()
        {
            string upit = "SELECT * FROM users";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            return dataTable;
        }
        //LOGIN #################
        public Korisnik Login(string username, string password)
        {
            string upit = "SELECT * FROM users WHERE username = @username AND password = @password";
            Korisnik korisnik = null;

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    int id = Int32.Parse(dataTable.Rows[0]["id"].ToString());
                    string uname = dataTable.Rows[0]["username"].ToString();
                    string pw = dataTable.Rows[0]["password"].ToString();
                    string imePrezime = dataTable.Rows[0]["imeprezime"].ToString();
                    string pol = dataTable.Rows[0]["pol"].ToString();
                    int godine = Int32.Parse(dataTable.Rows[0]["godine"].ToString());
                    int visina = Int32.Parse(dataTable.Rows[0]["visina"].ToString());
                    int tezina = Int32.Parse(dataTable.Rows[0]["tezina"].ToString());
                    string aktivnost = dataTable.Rows[0]["aktivnost"].ToString();
                    int smanjiKilazu = Int32.Parse(dataTable.Rows[0]["smanjikilazu"].ToString());
                    int pdu = Int32.Parse(dataTable.Rows[0]["pdu"].ToString());
                    string slika = dataTable.Rows[0]["slika"].ToString();                    

                    korisnik = new Korisnik(id, uname, pw, imePrezime, pol, godine, visina, tezina,aktivnost, smanjiKilazu, pdu, slika);

                    Console.WriteLine("Uspesno ste se ulogovali");
                }
                else
                {
                    Console.WriteLine("Pogresan username ili password!");
                }

                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }

            return korisnik;
        }
        //REGISTER
        public void Register(string username, string password, string imePrezime, string pol, int godine, int visina, int tezina, string aktivnost, int smanjiKilazu, int pdu)
        {
            string upit = "INSERT INTO users(username, password, imeprezime, pol, godine, visina, tezina, aktivnost, smanjikilazu, pdu)" +
                          "VALUES(@username, @password, @imeprezime, @pol, @godine, @visina, @tezina, @aktivnost, @smanjikilazu, @pdu)";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);

            connection.Open();

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@imeprezime", imePrezime);
            command.Parameters.AddWithValue("@pol", pol);
            command.Parameters.AddWithValue("@godine", godine);
            command.Parameters.AddWithValue("@visina", visina);
            command.Parameters.AddWithValue("@tezina", tezina);
            command.Parameters.AddWithValue("@aktivnost", aktivnost);
            command.Parameters.AddWithValue("@smanjikilazu", smanjiKilazu);
            command.Parameters.AddWithValue("@pdu", pdu);

            command.ExecuteNonQuery();

            Console.WriteLine("==== Upisano ====");

            connection.Close();
        }
        //UpdateUser
        public void UpdateUser(Korisnik korisnik)
        {
            string upit = "UPDATE users SET username = @username, password = @password, imeprezime = @imeprezime, pol = @pol, godine = @godine, visina = @visina," +
                          "tezina = @tezina, aktivnost = @aktivnost, smanjikilazu = @smanjikilazu, pdu = @pdu, slika = @slika WHERE id = @id";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);

            connection.Open();

            command.Parameters.AddWithValue("@id", korisnik.id);
            command.Parameters.AddWithValue("@username", korisnik.username);
            command.Parameters.AddWithValue("@password", korisnik.password);
            command.Parameters.AddWithValue("@imeprezime", korisnik.imePrezime);
            command.Parameters.AddWithValue("@pol", korisnik.pol);
            command.Parameters.AddWithValue("@godine", korisnik.godine);
            command.Parameters.AddWithValue("@visina", korisnik.visina);
            command.Parameters.AddWithValue("@tezina", korisnik.tezina);
            command.Parameters.AddWithValue("@aktivnost", korisnik.aktivnost);
            command.Parameters.AddWithValue("@smanjikilazu", korisnik.smanjiKilazu);
            command.Parameters.AddWithValue("@pdu", korisnik.pdu);
            command.Parameters.AddWithValue("@slika", korisnik.slika);

            command.ExecuteNonQuery();

            Console.WriteLine("==== Izmenjeno ====");

            connection.Close();
        }

        //UserweightdiaryInsert
        public void UserWeightDiaryInsert(TezinaDnevnik tezinaDnevnik)
        {
            string upit = "INSERT INTO userweightdiary (userid, tezina)" +
                          "VALUES (@userid, @tezina)";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);

            connection.Open();

            command.Parameters.AddWithValue("@userid", tezinaDnevnik.userId);
            command.Parameters.AddWithValue("@tezina", tezinaDnevnik.tezina);

            command.ExecuteNonQuery();
            Console.WriteLine("==== Upisano ====");

            connection.Close();
        }
        //UserWeightDiary Select *
        public List<TezinaDnevnik> UserWeightDiarySelect(int userIdParameter)
        {
            string upit = "SELECT * FROM userweightdiary WHERE userId = @userId";
            List<TezinaDnevnik> listaTezinaDnevnik = new List<TezinaDnevnik>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();

                command.Parameters.AddWithValue("@userid", userIdParameter);
                adapter.Fill(dataTable);

                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int id = Int32.Parse(dataTable.Rows[i]["id"].ToString());
                int userId = Int32.Parse(dataTable.Rows[i]["userId"].ToString());
                int tezina = Int32.Parse(dataTable.Rows[i]["tezina"].ToString());
                DateTime vremeUnosa = (DateTime)dataTable.Rows[0]["vremeunosa"];

                TezinaDnevnik foodCategory = new TezinaDnevnik(id, userId, tezina, vremeUnosa);
                listaTezinaDnevnik.Add(foodCategory);
            }
            return listaTezinaDnevnik;
        }
        //NapuniTreningTabele
        public List<Treninzi> NapuniTreningTabele()
        {
            string upit = "SELECT * FROM workout";
            List<Treninzi> listaTreninga = new List<Treninzi>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
             try
             {
                 connection.Open();
                 adapter.Fill(dataTable);           
                 connection.Close();
             }
             catch (MySqlException ex)
             {
                 Console.WriteLine(ex);
             }
             for (int i = 0; i < dataTable.Rows.Count; i++)
             {
                 int id = Int32.Parse(dataTable.Rows[i]["id"].ToString());
                 string exercise_name = dataTable.Rows[i]["exercise_name"].ToString();
                 int exercise_category = Int32.Parse(dataTable.Rows[i][2].ToString());
                 int sets = Int32.Parse(dataTable.Rows[i]["sets"].ToString());
                 int reps = Int32.Parse(dataTable.Rows[i]["reps"].ToString());
                 string muscle_group = dataTable.Rows[i]["muscle_group"].ToString();
                 int week = Int32.Parse(dataTable.Rows[i]["week"].ToString());

                 Treninzi trening = new Treninzi(id, exercise_name, exercise_category, sets, reps, muscle_group, week);
                 listaTreninga.Add(trening);
             }
             return listaTreninga;
        }
        //FoodCategoryList
        public List<FoodCategory> FoodCategoryList()
        {
            string upit = "SELECT * FROM foodcategory";
            List<FoodCategory> listaKategorija = new List<FoodCategory>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();

                adapter.Fill(dataTable);

                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int id = Int32.Parse(dataTable.Rows[i]["id"].ToString());
                string categoryName = dataTable.Rows[i]["category_name"].ToString();
                FoodCategory foodCategory = new FoodCategory(id, categoryName);

                listaKategorija.Add(foodCategory);
            }
            return listaKategorija;
        }

        //ListboxPopulation
        public List<Namirnice> ListBoxPopulate(int idOdabraneKategorije)
        {
            string upit = "SELECT * FROM nutritiondata WHERE category_id = @idOdabraneKategorije";
            List<Namirnice> listaKategorija = new List<Namirnice>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();

                command.Parameters.AddWithValue("@idOdabraneKategorije", idOdabraneKategorije);
                adapter.Fill(dataTable);

                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int id = Int32.Parse(dataTable.Rows[i]["id"].ToString());
                int categoryId = Int32.Parse(dataTable.Rows[i]["category_id"].ToString());
                string foodName = dataTable.Rows[i]["food_name"].ToString();
                int kj = Int32.Parse(dataTable.Rows[i]["kj"].ToString());
                int kcal = Int32.Parse(dataTable.Rows[i]["kcal"].ToString());
                int protein = Int32.Parse(dataTable.Rows[i]["protein"].ToString());
                int uh = Int32.Parse(dataTable.Rows[i]["uh"].ToString());
                int masti = Int32.Parse(dataTable.Rows[i]["masti"].ToString());

                Namirnice namirnice = new Namirnice(id, categoryId, foodName, kj, kcal, protein, uh, masti);
                listaKategorija.Add(namirnice);
            }
            return listaKategorija;
        }

        //MenuNutritionData
        public List<Namirnice> MenuNutritionData()
        {
            string upit = "SELECT * FROM nutritiondata";
            List<Namirnice> listaKategorija = new List<Namirnice>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();

                adapter.Fill(dataTable);

                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int id = Int32.Parse(dataTable.Rows[i]["id"].ToString());
                int categoryId = Int32.Parse(dataTable.Rows[i]["category_id"].ToString());
                string foodName = dataTable.Rows[i]["food_name"].ToString();
                int kj = Int32.Parse(dataTable.Rows[i]["kj"].ToString());
                int kcal = Int32.Parse(dataTable.Rows[i]["kcal"].ToString());
                int protein = Int32.Parse(dataTable.Rows[i]["protein"].ToString());
                int uh = Int32.Parse(dataTable.Rows[i]["uh"].ToString());
                int masti = Int32.Parse(dataTable.Rows[i]["masti"].ToString());

                Namirnice namirnice = new Namirnice(id, categoryId, foodName, kj, kcal, protein, uh, masti);
                listaKategorija.Add(namirnice);
            }
            return listaKategorija;
        }
        //UserMealsInsert
        public void UserMealInsert(Obroci obroci)
        {
            string upit = "INSERT INTO usermeals (userid, food_name, kj, kcal, protein, uh, masti, kolicina, obrok)" +
                          "VALUES (@userid, @food_name, @kj, @kcal, @protein, @uh, @masti, @kolicina, @obrok)";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);

            connection.Open();

            command.Parameters.AddWithValue("@userid", obroci.userId);
            command.Parameters.AddWithValue("@food_name", obroci.foodName);
            command.Parameters.AddWithValue("@kj", obroci.kj);
            command.Parameters.AddWithValue("@kcal", obroci.kcal);
            command.Parameters.AddWithValue("@protein", obroci.protein);
            command.Parameters.AddWithValue("@uh", obroci.uh);
            command.Parameters.AddWithValue("@masti", obroci.masti);
            command.Parameters.AddWithValue("@kolicina", obroci.kolicina);
            command.Parameters.AddWithValue("@obrok", obroci.obrok);

            command.ExecuteNonQuery();
            Console.WriteLine("==== Upisano ====");

            connection.Close();
        }
        //UserNutritionInfo
        public List<Obroci> UserNutritionInfo(int userid)
        {
            string upit = "SELECT * FROM usermeals WHERE userid = @userid";
            List<Obroci> listaNamirnica = new List<Obroci>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            connection.Open();

            command.Parameters.AddWithValue("@userid", userid);
            adapter.Fill(dataTable);

            connection.Close();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int id = Int32.Parse(dataTable.Rows[i]["id"].ToString());
                int uid = Int32.Parse(dataTable.Rows[i]["userid"].ToString());
                string foodName = dataTable.Rows[i]["food_name"].ToString();
                double kj = double.Parse(dataTable.Rows[i]["kj"].ToString());
                double kcal = double.Parse(dataTable.Rows[i]["kcal"].ToString());
                double protein = double.Parse(dataTable.Rows[i]["protein"].ToString());
                double uh = double.Parse(dataTable.Rows[i]["uh"].ToString());
                double masti = double.Parse(dataTable.Rows[i]["masti"].ToString());
                double kolicina = double.Parse(dataTable.Rows[i]["kolicina"].ToString());
                string obrok = dataTable.Rows[i]["obrok"].ToString();
                DateTime vremeUnosa = (DateTime)dataTable.Rows[i]["vremeunosa"];

                Obroci namirnica = new Obroci(id, uid, foodName, kj, kcal, protein, uh, masti, obrok, kolicina, vremeUnosa);
                listaNamirnica.Add(namirnica);
            }
            return listaNamirnica;
        }
        //Delete
        public void Delete(string id)
        {
            string upit = "DELETE FROM usermeals WHERE id = @id";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(upit, connection);

            connection.Open();

            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            Console.WriteLine("==== Obrisano ====");

            connection.Close();
        }
    }
}

