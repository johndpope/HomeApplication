using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Home.Server.Meals
{
    [Route("api/[controller]")]
    public class MealController : Controller
    {
        private readonly IMealRepository _database;

        public MealController(IMealRepository database)
        {
            _database = database;
        }

        [HttpGet]
        public IEnumerable<Meal> Get() 
        {
            return new List<Meal>
            {
                new Meal 
                { 
                    mealId = 1, 
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

        // [HttpPost]
        // public async Task<IActionResult> Create(Meal meal)
        // {
        //     var result = await Save(meal);
        //     if (result == null)
        //         return new NoContentResult();
        //     else 
        //         return BadRequest();
        // }

        // [HttpPut]
        // public async Task<IActionResult> Update(Meal meal)
        // {
        //     var result = await Save(meal);
        //     if (result == null)
        //         return new NoContentResult();
        //     else
        //         return BadRequest();
        // }

        // private async Task<string> Save(Meal meal)
        // {
        //     try
        //     {
        //         await _database.Save(meal);
        //     }
        //     catch (Exception ex)
        //     {
        //         return ex.Message;
        //     }
        //     return null;
        // }
    }
}