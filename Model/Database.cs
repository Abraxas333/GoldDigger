using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace GoldDigger.Model
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        // Constructor
        public DBConnect()
        {
            Initialize();
        }

        // Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "customers";
            uid = "root";
            password = "root";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        // Open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        // Close connection
        private bool CloseConnection()
        {
            connection.Close();
            return true;
        }

        // Insert new User statement
        public void Insert(string query)
        {
            
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (query.Substring(0, 6) == "DELETE")
                    {
                        MessageBox.Show($"Deleted {rowsAffected} row.");
                    }

                    else if (query.Substring(12, 11) == "credentials")
                    {
                        MessageBox.Show("Registration successful");
                    }

                    else if (query.Substring(0, 6) == "INSERT")
                    {
                        MessageBox.Show($"Added {rowsAffected} row");
                    }

                                    }
                CloseConnection();
            }
            
        }

        // Update statement
        public void Update(string query)
        {
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"Updated {rowsAffected} row in table.");
                }
                CloseConnection();
            }
        }

        // Delete statement
        public void Delete()
        {
            // Implementation here
        }

        // Check Username
        public bool CheckUsername(string input)
        {
            List<string> users = new List<string>();
            string user;
            string query = "SELECT username FROM credentials;";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = reader["username"].ToString();
                            if (user.Equals(input))
                            {
                                CloseConnection();
                                return true;
                            }
                        }
                    }
                }
                CloseConnection();
            }
            return false;
        }

        // Check Password
        public (string password, string salt) CheckPassword(string username)
        {
            DataSet ds = new DataSet();
            string query = "SELECT HashedPassword, Salt FROM credentials WHERE username = @username;";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                CloseConnection();
            }

            string passwd = ds.Tables[0].Rows[0]["HashedPassword"].ToString();
            string salt = ds.Tables[0].Rows[0]["Salt"].ToString();
            return (passwd, salt);
        }

        // Select Users
        public DataTable SelectUsers()
        {
            string query = "SELECT * FROM customers;";
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("surname", typeof(string)));
            dt.Columns.Add(new DataColumn("lastname", typeof(string)));
            dt.Columns.Add(new DataColumn("city", typeof(string)));
            dt.Columns.Add(new DataColumn("street", typeof(string)));
            dt.Columns.Add(new DataColumn("no", typeof(int)));
            dt.Columns.Add(new DataColumn("plz", typeof(int)));
            dt.Columns.Add(new DataColumn("email", typeof(string)));
            dt.Columns.Add(new DataColumn("id", typeof(int)));

            if (OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow dr = dt.NewRow();
                            dr["surname"] = reader["surname"];
                            dr["lastname"] = reader["lastname"];
                            dr["city"] = reader["city"];
                            dr["street"] = reader["street"];
                            dr["no"] = reader["no"];
                            dr["plz"] = reader["plz"];
                            dr["email"] = reader["email"];
                            dr["id"] = reader["id"];
                            dt.Rows.Add(dr);
                        }
                    }
                }
                CloseConnection();
            }

            return dt;
        }
        public void GetCustomerData()
        {
            string query = "SELECT * FROM customers";
            if (OpenConnection()== true)
            {

            }
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerData customer = new CustomerData(
                            Convert.ToString(reader["surname"]),
                            Convert.ToString(reader["lastname"]),
                            Convert.ToString(reader["city"]),
                            Convert.ToString(reader["street"]),
                            Convert.ToInt32(reader["no"]),
                            Convert.ToInt32(reader["plz"]),
                            Convert.ToString(reader["email"]),
                            Convert.ToInt32(reader["id"])
                            );

                    }
                }
            }
        }

        public bool Exists(int input)
        {
            string query = "SELECT id from customers;";
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["id"];
                            if (id.Equals(input))
                            {
                                CloseConnection();
                                return true;
                            }
                        }
                    }
                }
                CloseConnection();
            }
            return false;
        }

        public int GetLastInsertedId()
        {
            int lastId = 0;
            string query = "SELECT LAST_INSERT_ID();";

            if (OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    lastId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                CloseConnection();
            }

            return lastId;
        }

    }
}
