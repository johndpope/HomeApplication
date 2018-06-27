using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Home.Server.Budgets
{
    [Route("api/[controller]")]
    public class BudgetController : Controller
    {
        public IEnumerable<Budget> Get()
        {
            return new List<Budget>
            {
                new Budget 
                {
                    budgetId = 1,
                    budgetName = "Cell Phone Bill",
                    frequency = TransactionFrequency.weekly,
                    type = TransactionType.credit,
                    createdDate = DateTime.Now,
                    updatedDate = DateTime.Now,
                    amount = 420.69,
                    items = new List<BudgetItem> 
                    {
                        new BudgetItem 
                        {
                            itemId = 1,
                            budgetId = 1,
                            transactionDate = DateTime.Now
                        },
                        new BudgetItem 
                        {
                            itemId = 2,
                            budgetId = 1,
                            transactionDate = DateTime.Now
                        }
                    }
                }
            };
        }
    }
}