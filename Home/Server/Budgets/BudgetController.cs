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
            Guid budget1Uid = Guid.NewGuid();
            return new List<Budget>
            {
                new Budget 
                {
                    budgetId = 1,
                    budgetUid = budget1Uid,
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
                            itemUid = Guid.NewGuid(),
                            budgetUid = budget1Uid,
                            transactionDate = DateTime.Now
                        },
                        new BudgetItem 
                        {
                            itemId = 2,
                            itemUid = Guid.NewGuid(),
                            budgetUid = budget1Uid,
                            transactionDate = DateTime.Now
                        }
                    }
                }
            };
        }
    }
}