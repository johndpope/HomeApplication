using System;
using System.Collections.Generic;
using Home.Server.Groceries;

namespace Home.Server.Meals
{
    public class Meal
    {
        public int mealId { get; set; }
        public string mealName { get; set; }
        public bool enabled { get; set; }
        public ICollection<Grocery> groceries { get; set; }
    }
}
