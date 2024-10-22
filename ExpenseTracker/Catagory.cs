namespace ExpenseTracker.Models{
    public class Catagory{
        public int Id {get; set;}
        public string Name{get; set;}

        //Establishing a one to many relationship with Expenses
        public list<Expense> Expenses {get; set;}
    }
}