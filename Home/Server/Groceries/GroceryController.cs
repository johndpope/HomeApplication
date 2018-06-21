using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Home.Server.Groceries
{
    [Route("api/[controller]")]
    public class GroceryController : Controller
    {
        [HttpGet]
        public IEnumerable<Grocery> Get()
        {
            return new List<Grocery> 
            {
                new Grocery { groceryUid = Guid.NewGuid(), groceryName = "Chicken" },
                new Grocery { groceryUid = Guid.NewGuid(), groceryName = "Broccoli" },
                new Grocery { groceryUid = Guid.NewGuid(), groceryName = "Rice" },
                new Grocery { groceryUid = Guid.NewGuid(), groceryName = "Curry" },
            };
        }
    }
}
