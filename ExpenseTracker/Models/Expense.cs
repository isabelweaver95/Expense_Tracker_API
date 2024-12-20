namespace ExpenseTracker.Models{
    public class Expense{
        public int Id {get; set;}
        public decimal Amount {get; set;}
        public DateTime Date {get; set;}
        public string Description {get; set;}

        //This is the forign keys for the database.
        public int CatagoryId {get; set;}
        public Catagory Category {get; set;} = new Catagory();       
        public int UserID {get; set;}


        //Constructors
        public Expense(){
            Description = " ";
        }

        public Expense(decimal amount, DateTime date, string description){
            Amount = amount;
            Date = date;
            Description = description;
        }
        
        public Expense(int id, int userID, decimal amount, DateTime date, string description, int categoryID){
            Id = id;
            UserID = userID;
            Amount = amount;
            Date = date;
            Description = description;
            CatagoryId = categoryID;    
        }

        //Connecting category to expense.
        public void ConnectToCategory(Catagory catagory){
            CatagoryId = catagory.Id;
            Category = catagory;
        }

        //Updating the class. 
         public void Update(decimal newAmount, DateTime newDate, Catagory newCategory){
            this.Amount = newAmount;
            this.Date = newDate;
        
            if (newCategory != null)
            {
                this.Category = newCategory;
            this.CatagoryId = newCategory.Id; // Sync with the new Category's Id
            }
        }

        //This will connect the user to the expense.
        public void ConnectToUser(User user){
            UserID = user.Id;
        }
    }
}