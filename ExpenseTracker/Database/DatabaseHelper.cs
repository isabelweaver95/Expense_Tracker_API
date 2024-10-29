using ExpenseTracker.Models;
using MySql.Data.MySqlClient;

namespace ExpenseTracker.Database{
    public class DatabaseHelper{
        private readonly string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

    // Example: Add a user
        public void AddUser(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO User (Username, PasswordHash, Name, Email, Salt) VALUES (@Username, @PasswordHash, @Name, @Email, @Salt)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Salt", user.Salt);
                    cmd.ExecuteNonQuery();
                }
            }
        }
}