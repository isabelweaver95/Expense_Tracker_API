namespace ExpenseTracker.Models{

    public class Catagory{
        public int Id {get; set;}
        public string Name{get; set;}

        //Establishing a one to many relationship with Expenses
        public List<Expense> Expenses {get; set;}

        public void AddExpense(Expense expense){
            Expenses.add(expense);
        }

        public decimal GetTotalExpense(){
            decimal totalExpense = 0.0;

            foreach(Expense expense in Expenses){
                totalExpense = expense.Amount;
            }
        }

        public void RemoveExpense(Expense expense){
            foreach(Expense checkExpense in Expenses){
                if(expense.date == checkExpense.date){
                    Expenses.remove(expense);
                }
            }
        }
    }
}