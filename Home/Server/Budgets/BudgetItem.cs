using System;

namespace Home.Server.Budgets
{
    public class BudgetItem
    {
        public int itemId { get; set; }
        public int budgetId { get; set; }
        public DateTime transactionDate { get; set; }
        public bool enabled { get; set; }
        public Budget budget { get; set; }
    }
}