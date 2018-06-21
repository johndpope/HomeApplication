using System;

namespace Home.Server.Cars
{
    public class Car
    {
        public Guid carUid { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string licensePlate { get; set; }
    }
}