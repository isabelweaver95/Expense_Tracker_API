namespace ExpenseTracker.Models{
    public class User{
        public int Id {get; set;}
        public string Username {get; set;}
        public string PasswordHash {get; set;}
        public string Email {get; set;}
        public string Salt {get; set;}

        //This is a method to store and hide the password
        public void SetPassword(string password){
            Salt = GenerateSalt();
            PasswordHash = HashPassword(password)
        }

        private string HashPassword(string password){
            using(var sha256 = sha256.Create()){
                var combined = Encoding.UTF8.GetBytes(password + Salt);
                return Convert.ToBase64String(sha256.ComputeHash(combined));
            }
        }

        private string GenerateSalt(){
            var rng = new RNGCryptoServiceProvider();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }
}