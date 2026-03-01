using ParkingSystem.Models;

namespace ParkingSystem.Models
{
    
    public class Slot
    {
        public int SlotNumber { get; }
        public Vehicle Vehicle { get; private set; }

        public List<Vehicle> vehicles => new List<Vehicle>();

        public bool IsAvailable => Vehicle == null;

        public Slot(int number)
        {
            SlotNumber = number;
        }

        public void AssignVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public bool VehicleExist(string regNum)
        {
            return vehicles.Any(v => v.RegistrationNumber == regNum);
        }

        public void RemoveVehicle()
        {
            Vehicle = null;
        }
    }
}