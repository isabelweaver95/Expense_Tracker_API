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
            var user = new User("izzy@gmail.com", "IsabelK", "Isabel", "aaaaaaaaaa", "bbbbbbbbbbbb");
            user.Id = dbHelper.AddUser(user);


            // Assert
            // Verify that the user was added correctly
            Assert.true(user.Id > 0);

            var userTest = dbHelper.GetUserById(user.id);
            Assert.NotNull(userTest);
            Assert.Equal(user.Email, userTest.Email);
            Assert.Equal(user.Username, userTest.Username);
            Assert.Equal(user.Name, userTest.Name);
            Assert.Equal(user.PasswordHash, userTest.PasswordHash);
            Asser.Equal(user.Salt, userTest.Salt);
        }

        
    }
}