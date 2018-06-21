using System;
using System.Collections.Generic;
using Home.Server.Groceries;

namespace Home.Server.Meals
{
    public class Meal
    {
        public Guid mealUid { get; set; }
        public string mealName { get; set; }
        public ICollection<Grocery> groceries { get; set; }
    }
}
