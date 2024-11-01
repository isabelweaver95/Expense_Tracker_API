using MySql.Data.MySqlClient;
using System.Collections.Generic;
using ExpenseTracker.Models;

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

    //This will add an expense (Create)
    public void AddExpense(Expense expense){
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Expense (UserID, Amount, Date, Description, CategoryID) VALUES (@UserID, @Amount, @Date, @Description, @CategoryID)";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", expense.UserID);
                cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                cmd.Parameters.AddWithValue("@Date", expense.Date);
                cmd.Parameters.AddWithValue("@Description", expense.Description);
                cmd.Parameters.AddWithValue("@CategoryID", expense.CatagoryId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    //This will add a category (Create)
    public void AddCatagory(Catagory catagory){
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Catagory (Name) VALUES (@Name)";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", catagory.Name);
                cmd.ExecuteNonQuery();
            }
        }
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
                    }
                }
            }
        }
        return users;
    }


}
