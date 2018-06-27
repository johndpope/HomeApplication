using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Home.Server.Cars
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return new List<Car>
            {
                new Car { carId = 1, make = "Ford", model = "Mustang", licensePlate = "ANTT-3S9" },
                new Car { carId = 2, make = "Chevrolet", model = "Uplander", licensePlate = "ABYK-614" },
                new Car { carId = 3, make = "Toyota", model = "Matrix", licensePlate = "CCCC-CCC" },
            };
        }
    }
}