using Home.Server.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home.Server.Cars
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarRepository _database;
        public CarController(ICarRepository database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> GetAll()
        {
            var result = await _database.GetAll();

            if (result.Error == null)
                return result.Results;
            else
                return null;
        }

        [HttpGet("{id}", Name = "GetCar")]
        public async Task<IActionResult> GetCar(int id)
        {
            var result = await _database.Get(id);

            if (result.Error == null)
                return new ObjectResult(result.Result);
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Car car)
        {
            var result = await _database.Save(car);

            if (result.Error == null)
                return new NoContentResult();
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Car car)
        {
            var result = await _database.Save(car);

            if (result.Error == null)
                return new NoContentResult();
            else
                return BadRequest();
        }
    }
}