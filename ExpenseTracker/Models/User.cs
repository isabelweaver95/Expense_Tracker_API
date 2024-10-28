using System;
using System.Security.Cryptography;
using System.Text;

namespace ExpenseTracker.Models{
    public class User{
        public int Id {get; set;}
        public string Username {get; set;}
        public string PasswordHash {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Salt {get; set;}
        

        public List<Expense> Expenses {get; set;} = new List<Expense>();

        //This is a method to store and hide the password
        public void SetPassword(string password){
            Salt = GenerateSalt();
            PasswordHash = HashPassword(password);
        }

        //This function hashes the password that is sent in
        private string HashPassword(string password){
            using (var sha256 = SHA256.Create())
            {
                var combined = Encoding.UTF8.GetBytes(password + Salt);
                return Convert.ToBase64String(sha256.ComputeHash(combined));
            }
        }

        //This function generates the hash.
        private string GenerateSalt(){
            var rng = new RNGCryptoServiceProvider();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        //This Function will use to authenticate a person logging in
        public bool Authenticate(string username, string password){
            if(username == Username){

                string passwordCheck = HashPassword(password);

                if(passwordCheck == PasswordHash){
                    return true;
                }else{
                    return false;
                }
            }else{
                return false;
            }
        }

        //This will add an expense
        public void AddExpense(Expense expense){
            Expenses.Add(expense);
        }

        public void RemoveExpense(Expense expense){
            Expenses.Remove(expense);
        }


        public decimal GetTotalExpense(){
            decimal totalAmount = 0;
            foreach(Expense expense in Expenses){
                totalAmount += expense.Amount;
            }
            
            return totalAmount;
        }

        //User will send in a category and then will return the total expenses by the category. 
        public decimal GetTotalExpenseByCatagory(Catagory catagory){

            foreach(Expense expense in Expenses){
                if(catagory.Name == expense.Category.Name){
                    return expense.Category.GetTotalExpense();
                }

            }

            return -1;
        }

        //updating only name and email. 
        public void Update(string newName = null, string newEmail = null){
            if (!string.IsNullOrEmpty(newName))
            {
                this.Name = newName;
            }

            if (!string.IsNullOrEmpty(newEmail))
            {
                this.Email = newEmail;
            }
        }
   }
}