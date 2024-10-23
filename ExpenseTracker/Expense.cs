namespace ExpenseTracker.Models{
    public class Expense{
        public int Id {get; set;}
        public decimal Amount {get; set;}
        public DateTime date {get; set;}
        public string Description {get; set;}
        public int CatagoryID {get; set;}
        public Catagory catagory {get; set;}

    }
}