using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home.Server.Cars
{
    [Route("api/[controller]")]
    public class MaintenanceController : Controller
    {
        private readonly ICarRepository _database;

        public MaintenanceController(ICarRepository database)
        {
            _database = database;
        }

        [HttpGet("{id}", Name = "GetCarMaintenance")]
        public async Task<IEnumerable<Maintenance>> GetCarMaintenance(int id)
        {
            var result = await _database.GetMaintenance(id);
            
            if (result.Error == null)
                return result.Results;
            else
                return null;
        }
    }
}