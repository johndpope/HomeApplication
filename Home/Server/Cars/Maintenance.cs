using System;

namespace Home.Server.Cars
{
    public class Maintenance 
    {
        public int maintenanceId { get; set; }
        public int carId { get; set; }
        public int typeId { get; set; }
        public DateTime date { get; set; }
        public int kilometers { get; set; }
        public MaintenanceType type { get; set; }
    }
}