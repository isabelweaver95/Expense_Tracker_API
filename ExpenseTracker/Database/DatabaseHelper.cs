using MySql.Data.MySqlClient;
using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Database{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Starting to create the CRUD methods
        // Create Methods

        //This will add a user (create)
        public int AddUser(User user)
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

                    // Execute the insert
                    cmd.ExecuteNonQuery();

                    // Retrieve the last inserted ID
                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    user.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return user.Id;
        }

        //This will add an expense (Create)
        public int AddExpense(Expense expense){
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Expense (Amount, Date, Description, CategoryID) VALUES (@UserID, @Amount, @Date, @Description, @CategoryID)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@Date", expense.Date);
                    cmd.Parameters.AddWithValue("@Description", expense.Description);
                    cmd.Parameters.AddWithValue("@CategoryID", expense.CatagoryId);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    expense.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return expense.Id; 
        }

        //This will add a category (Create)
        public int AddCatagory(Catagory catagory){
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Catagory (Name) VALUES (@Name)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", catagory.Name);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    catagory.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return catagory.Id;
        }


        // Read Methods

        //This will get all users (read)
        public List<User> GetAllUsers(){
            List<User> users = new List<User>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM User";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("Id");
                            string username = reader.GetString("Username");
                            string name = reader.GetString("Name");
                            string email = reader.GetString("Email");
                            string passwordHash = reader.GetString("PasswordHash");
                            string salt = reader.GetString("Salt");

                            User user = new User(id,username, name, email, passwordHash, salt);
                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }

        //This will get all expenses (read)
        public List<Expense> GetAllExpenses(){
            List<Expense> expenses = new List<Expense>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Expense";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("Id");
                            int userID = reader.GetInt32("UserID");
                            decimal amount = reader.GetDecimal("Amount");
                            DateTime date = reader.GetDateTime("Date");
                            string description = reader.GetString("Description");
                            int categoryID = reader.GetInt32("CategoryID");

                            Expense expense = new Expense(id, userID, amount, date, description, categoryID);
                            expenses.Add(expense);
                        }
                    }
                }
            }
            return expenses;
        }

        //This will get all categories (read)
        public List<Catagory> GetAllCatagories(){
            List<Catagory> catagories = new List<Catagory>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Catagory";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("Id");
                            string name = reader.GetString("Name"); 
                            Catagory catagory = new Catagory(id, name);
                            catagories.Add(catagory);
                        }
                    }
                }
            }
            return catagories;
        }   

        //This is the update methods

        //This will update a user (update)
        public void UpdateUser(User user){
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE User SET Username = @Username, PasswordHash = @PasswordHash, Name = @Name, Email = @Email, Salt = @Salt WHERE Id = @Id";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Salt", user.Salt);
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //This will update an expense (update)
        public void UpdateExpense(Expense expense){
            using(var connection = new MySqlConnection(connectionString)){
                connection.Open();
                string query = "UPDATE Expense SET UserID = @UserID, Amount = @Amount, Date = @Date, Description = @Description, CategoryID = @CategoryID WHERE Id = @Id";
                
                using(var cmd = new MySqlCommand(query, connection)){
                    cmd.Parameters.AddWithValue("@UserID", expense.UserID);
                    cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@Date", expense.Date);
                    cmd.Parameters.AddWithValue("@Description", expense.Description);
                    cmd.Parameters.AddWithValue("@CategoryID", expense.CatagoryId);
                    cmd.Parameters.AddWithValue("@Id", expense.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //This will update a category (update)
        public void UpdateCatagory(Catagory catagory){
            using(var connection = new MySqlConnection(connectionString)){
                connection.Open();
                string query = "UPDATE Catagory SET Name = @Name WHERE Id = @Id";

                using(var cmd = new MySqlCommand(query, connection)){
                    cmd.Parameters.AddWithValue("@Name", catagory.Name);
                    cmd.Parameters.AddWithValue("@Id", catagory.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Now creating the delete functions.

        //Delete for user
        public void DeleteUser(User user){
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM User SET Username = @Username, PasswordHash = @PasswordHash, Name = @Name, Email = @Email, Salt = @Salt WHERE Id = @Id";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Salt", user.Salt);
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //delete for Expense
        public void DeleteExpense(Expense expense){
            using(var connection = new MySqlConnection(connectionString)){
                connection.Open();
                string query = "DELETE FROM Expense SET UserID = @UserID, Amount = @Amount, Date = @Date, Description = @Description, CategoryID = @CategoryID WHERE Id = @Id";
                    
                using(var cmd = new MySqlCommand(query, connection)){
                    cmd.Parameters.AddWithValue("@UserID", expense.UserID);
                    cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@Date", expense.Date);
                    cmd.Parameters.AddWithValue("@Description", expense.Description);
                    cmd.Parameters.AddWithValue("@CategoryID", expense.CatagoryId);
                    cmd.Parameters.AddWithValue("@Id", expense.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //delete for catagory
        public void DeleteCatagory(Catagory catagory){
            using(var connection = new MySqlConnection(connectionString)){
                connection.Open();
                string query = "DELETE FROM Catagory SET Name = @Name WHERE Id = @Id";

                using(var cmd = new MySqlCommand(query, connection)){
                    cmd.Parameters.AddWithValue("@Name", catagory.Name);
                    cmd.Parameters.AddWithValue("@Id", catagory.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    

        public User GetUserById(int userId)
        {
            User user = new User();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Username, PasswordHash FROM Users WHERE Id = @Id";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Username, PasswordHash, Name, Email, Salt\
                            user.Id = reader.GetInt32("Id");
                            user.Username = reader.GetString("Username");
                            user.Name = reader.GetString("Name");
                            user.Email = reader.GetString("Email");
                            user.Salt = reader.GetString("Salt");
                            user.PasswordHash = reader.GetString("PasswordHash");
                        }
                    }
                }
            }
            return user;
        }  

        public Catagory GetCatagoryById(int catagoryId)
        {
            Catagory catagory = new Catagory();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name FROM Catagory WHERE Id = @Id";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", catagoryId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            catagory.Id = reader.GetInt32("Id");
                            catagory.Name = reader.GetString("Name");
                        }
                    }
                }
            }
            return catagory;
        }

        public Expense GetExpenseById(int expenseId)
        {
            Expense expense = new Expense();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, UserID, Amount, Date, Description, CategoryID FROM Expense WHERE Id = @Id";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", expenseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            expense.Id = reader.GetInt32("Id");
                            expense.UserID = reader.GetInt32("UserID");
                            expense.Amount = reader.GetDecimal("Amount");
                            expense.Date = reader.GetDateTime("Date");
                            expense.Description = reader.GetString("Description");
                            expense.CatagoryId = reader.GetInt32("CategoryID");
                        }
                    }
                }
            }
            return expense;
        }
                
    }

}