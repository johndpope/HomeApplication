using System;

namespace Home.Server.Budgets
{
    public class BudgetItem
    {
        public int itemId { get; set; }
        public Guid itemUid { get; set; }
        public Guid budgetUid { get; set; }
        public DateTime transactionDate { get; set; }
        public Budget budget { get; set; }
    }
}