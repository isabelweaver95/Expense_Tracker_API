using Xunit;
using ExpenseTracker.Database;
using ExpenseTracker.Models;

namespace ExpenseTracker.Tests.helper{
    public DatabaseHelperTests{
        [Fact]
        public void Test_AddUser()
        {
            // Arrange
            var dbHelper = new DatabaseHelper();
            

            // Act
            // Call the method to add a user
            //public User(int id, string email, string username, string name, string passwordHash, string salt)
            var user = new User(1, "izzy@gmail.com", "IsabelK", "Isabel", "aaaaaaaaaa", "bbbbbbbbbbbb");
            dbHelper.AddUser(user);


            // Assert
            // Verify that the user was added correctly
        }
    }
}