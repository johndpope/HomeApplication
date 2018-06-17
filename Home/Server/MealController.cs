using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Home.Server
{
    [Route("api/[controller]")]
    public class MealController : Controller
    {
        [HttpGet]
        public IEnumerable<Meal> Get() 
        {
            return new List<Meal>
            {
                new Meal 
                { 
                    mealUid = Guid.NewGuid(), 
                    mealName = "Chicken Devan"
                    // groceries = new List<Grocery> 
                    // {
                    //     new Grocery { groceryUid = Guid.NewGuid(), groceryName = "Chicken" },
                    //     new Grocery { groceryUid = Guid.NewGuid(), groceryName = "Broccoli" },
                    //     new Grocery { groceryUid = Guid.NewGuid(), groceryName = "Rice" },
                    //     new Grocery { groceryUid = Guid.NewGuid(), groceryName = "Curry" },
                    // }
                }
            };
        }
    }
}