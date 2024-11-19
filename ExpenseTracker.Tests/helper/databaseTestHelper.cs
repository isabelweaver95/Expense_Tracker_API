using Xunit;
using ExpenseTracker.Database;
using ExpenseTracker.Models;

namespace ExpenseTracker.Tests.Helper
{
    public class DatabaseHelperTests
    {
        [Fact]
        public void Test_AddUser()
        {
            // Arrange
            var dbHelper = new DatabaseHelper();

            // Act
            var user = new User("izzy@gmail.com", "IsabelK", "Isabel", "aaaaaaaaaa", "bbbbbbbbbbbb");
            user.Id = dbHelper.AddUser(user);

            // Assert
            Assert.True(user.Id > 0);

            var userTest = dbHelper.GetUserById(user.Id);
            Assert.NotNull(userTest);
            Assert.Equal(user.Email, userTest.Email);
            Assert.Equal(user.Username, userTest.Username);
            Assert.Equal(user.Name, userTest.Name);
            Assert.Equal(user.PasswordHash, userTest.PasswordHash);
            Assert.Equal(user.Salt, userTest.Salt);
        }

        [Fact]
        public void Test_AddCategory()
        {
            // Arrange
            var dbHelper = new DatabaseHelper();
            var category = new Catagory("Clothes");

            // Act
            category.Id = dbHelper.AddCatagory(category);

            // Assert
            Assert.True(category.Id > 0);

            var categoryTest = dbHelper.GetCatagoryById(category.Id);
            Assert.NotNull(categoryTest);
            Assert.Equal(category.Name, categoryTest.Name);
        }

        [Fact]
        public void Test_AddExpense()
        {
            // Arrange
            var dbHelper = new DatabaseHelper();
  
            var expense = new Expense(10.00M, DateTime.Now, "test");

            // Act
            expense.Id = dbHelper.AddExpense(expense);

            // Assert
            Assert.True(expense.Id > 0);
            var expenseTest = dbHelper.GetExpenseById(expense.Id);
            Assert.NotNull(expenseTest);
            Assert.Equal(expense.Amount, expenseTest.Amount);
            Assert.Equal(expense.Date, expenseTest.Date);
            Assert.Equal(expense.Description, expenseTest.Description);
        }
    }
}