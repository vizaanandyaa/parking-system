using System;
using System.Collections.Generic;
using System.Linq;
using ParkingSystem.Models;
using ParkingSystem.Helpers;

namespace ParkingSystem.Services
{
    public class ParkingLot
    {
        private readonly List<Slot> _slots = new List<Slot>();

        public void CreateLot(int total)
        {
            for (int i = 1; i <= total; i++)
            {
                _slots.Add(new Slot(i));
            }

            Console.WriteLine($"Created a parking lot with {total} slots");
        }

        public void Park(string regNum, string colour, string type)
        {
            var available = _slots.FirstOrDefault(s => s.IsAvailable);

            if (available == null)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }


            if (type != "Mobil" && type != "Motor")
            {
                Console.WriteLine($"{type} is not allowed");
                return;
            }

            available.AssignVehicle(new Vehicle(regNum, colour, type));
            Console.WriteLine($"Allocated slot number: {available.SlotNumber}");
        }

        public void Leave(int slotNumber)
        {
            var slot = _slots.FirstOrDefault(s => s.SlotNumber == slotNumber);

            if (slot != null && !slot.IsAvailable)
            {
                slot.RemoveVehicle();
                Console.WriteLine($"Slot number {slotNumber} is free");
            }
        }

        public void Status()
        {
            Console.WriteLine("Slot No. Type Registration No Colour");

            foreach (var slot in _slots.Where(s => !s.IsAvailable))
            {
                Console.WriteLine($"{slot.SlotNumber} {slot.Vehicle.Type} {slot.Vehicle.RegistrationNumber} {slot.Vehicle.Colour}");
            }
        }

        public void CountByType(string type)
        {
            var count = _slots.Count(s => !s.IsAvailable && s.Vehicle.Type == type);
            Console.WriteLine(count);
        }

        public void GetOddPlate()
        {
            var result = _slots
                .Where(s => !s.IsAvailable && PlateHelper.IsOddPlate(s.Vehicle.RegistrationNumber))
                .Select(s => s.Vehicle.RegistrationNumber);

            Console.WriteLine(string.Join(", ", result));
        }

        public void GetEvenPlate()
        {
            var result = _slots
                .Where(s => !s.IsAvailable && !PlateHelper.IsOddPlate(s.Vehicle.RegistrationNumber))
                .Select(s => s.Vehicle.RegistrationNumber);

            Console.WriteLine(string.Join(", ", result));
        }

        public void GetByColour(string colour)
        {
            var result = _slots
                .Where(s => !s.IsAvailable && s.Vehicle.Colour == colour)
                .Select(s => s.Vehicle.RegistrationNumber);

            Console.WriteLine(string.Join(", ", result));
        }

        public void GetSlotByColour(string colour)
        {
            var result = _slots
                .Where(s => !s.IsAvailable && s.Vehicle.Colour == colour)
                .Select(s => s.SlotNumber);

            Console.WriteLine(string.Join(", ", result));
        }

        public void GetSlotByRegistration(string regNo)
        {
            var slot = _slots
                .FirstOrDefault(s => !s.IsAvailable && s.Vehicle.RegistrationNumber == regNo);

            Console.WriteLine(slot == null ? "Not found" : slot.SlotNumber.ToString());
        }
    }
}