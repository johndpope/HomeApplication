using System;

namespace Home.Server.Cars 
{
    public class MaintenanceType
    {
        public int typeId { get; set; }
        public bool reminder { get; set; }
        public int timeSpan { get; set; }
    }
}