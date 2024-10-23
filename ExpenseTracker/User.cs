namespace ExpenseTracker.Models{
    public class User{
        public int Id {get; set;}
        public string Username {get; set;}
        public string PasswordHash {get; set;}
        public string Email {get; set;}
        public string Salt {get; set;}

        public List<Expense> Expenses {get; set;} = new List<Expense>();

        //This is a method to store and hide the password
        public void SetPassword(string password){
            Salt = GenerateSalt();
            PasswordHash = HashPassword(password)
        }

        //This function hashes the password that is sent in
        private string HashPassword(string password){
            using(var sha256 = sha256.Create()){
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
            Expenses.add(expense);
        }

        public void RemoveExpense(Expense expense){
            Expenses.remove(expense);
        }

        /// <summary>
        /// This function will loop through all of the expenses 
        /// and add them up to get the total expenses.
        /// </summary>
        /// <returns>The total expenses.</returns>

        public decimal GetTotalExpense(){
            decimal totalAmount = 0;
            foreach(Expense expense in Expenses){
                totalAmount += expense.Amount;
            }
            
            return totalAmount;
        }

        public decimal GetTotalExpenseByCatagory(Catagory catagory){
            decimal totalAmount = 0;
            
            foreach(Expense expense in Expenses){
                if(catagory.Name = expense.catagory.Name)
                totalAmount += expense.Amount;
            }
            
            return totalAmount;
        }
   }
}