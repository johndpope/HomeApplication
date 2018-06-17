using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Home.Server
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return new List<Car>
            {
                new Car { carUid = Guid.NewGuid(), make = "Ford", model = "Mustang", licensePlate = "ANTT-3S9" },
                new Car { carUid = Guid.NewGuid(), make = "Chevrolet", model = "Uplander", licensePlate = "ABYK-614" },
                new Car { carUid = Guid.NewGuid(), make = "Toyota", model = "Matrix", licensePlate = "CCCC-CCC" },
            };
        }
    }
}