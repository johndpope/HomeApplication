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
                new Grocery { groceryId = 1, groceryName = "Chicken" },
                new Grocery { groceryId = 2, groceryName = "Broccoli" },
                new Grocery { groceryId = 3, groceryName = "Rice" },
                new Grocery { groceryId = 4, groceryName = "Curry" },
            };
        }
    }
}
