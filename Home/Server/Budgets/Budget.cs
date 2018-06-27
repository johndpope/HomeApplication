using System;
using System.Collections.Generic;

namespace Home.Server.Budgets
{
    public class Budget 
    {
        public int budgetId { get; set; }
        public string budgetName { get; set; }
        public TransactionFrequency frequency { get; set; }
        public TransactionType type { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public double amount { get; set; }
        public ICollection<BudgetItem> items { get; set; }
    }
}
