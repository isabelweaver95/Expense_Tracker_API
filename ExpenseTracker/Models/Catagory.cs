namespace ExpenseTracker.Models{

    public class Catagory{
        public int Id {get; set;}
        public string Name {get; set;}

        //Establishing a one to many relationship with Expenses
        public List<Expense> Expenses {get; set;} = new List<Expense>();

        public Catagory(){
            Name = " ";
        }

        public void AddExpense(Expense expense){
            Expenses.Add(expense);
        }

        public decimal GetTotalExpense(){
            decimal totalExpense = 0;

            foreach(Expense expense in Expenses){
                totalExpense = expense.Amount;
            }
            return totalExpense;
        }

        public void RemoveExpense(Expense expense){
            foreach(Expense checkExpense in Expenses){
                if(expense.Date == checkExpense.Date){
                    Expenses.Remove(expense);
                }
            }
        }
    }
}