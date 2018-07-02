using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Server.Meals
{
    public interface IMealRepository
    {
        Task Save(Meal meal);
    }
}
