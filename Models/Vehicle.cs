using System;

namespace ParkingSystem.Models
{
    public class Vehicle
    {
        public string RegistrationNumber { get; }
        public string Colour { get; }
        public string Type { get; }
        public DateTime CheckInTime { get; }

        public Vehicle(string regNo, string colour, string type)
        {
            RegistrationNumber = regNo;
            Colour = colour;
            Type = type;
            CheckInTime = DateTime.Now;
        }
    }
}