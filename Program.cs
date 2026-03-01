using System;
using System.Security.Cryptography.X509Certificates;
using ParkingSystem.Services;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new ParkingLot();
            var program = new Program();

            while (true)
            {
                program.ShowMenu();
                var input = Console.ReadLine();
                // var command = input.Split(' ');

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Input the desired number of slots:");
                        var slotInput = Console.ReadLine();
                        if (slotInput == null)
                        {
                            Console.WriteLine("Please input valid number");
                        }
                        else
                        {

                            parkingLot.CreateLot(int.Parse(slotInput));
                        }
                        break;

                    case "2":
                        Console.WriteLine("Please use this format : vehicle_number color type");
                        Console.WriteLine("(ex : B-123-AB Hitam Mobil)");
                        var parkInput = Console.ReadLine();
                        var command = parkInput.Split(' ');
                        if (command.Length == 3)
                        {
                            parkingLot.Park(command[0], command[1], command[2]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid format.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Input the desired number of slots:");
                        var leaveInput = Console.ReadLine();
                        if (leaveInput == null)
                        {
                            Console.WriteLine("Please input valid number");
                        }
                        else
                        {

                            parkingLot.Leave(int.Parse(leaveInput));
                        }
                        break;

                    case "4":
                        parkingLot.Status();
                        break;

                    case "5":
                        Console.WriteLine("Mobil / Motor");
                        var typeInput = Console.ReadLine();
                        if (typeInput == null)
                        {
                            Console.WriteLine("Please input valid vehicle type");
                        }
                        else
                        {
                            parkingLot.CountByType(typeInput);
                        }
                        break;

                    case "6":
                        Console.WriteLine("Input vehicle number");
                        var vehNum = Console.ReadLine();
                        if (vehNum == null)
                        {
                            Console.WriteLine("Please input valid vehicle number");
                        }
                        else
                        {
                            parkingLot.GetSlotByRegistration(vehNum);
                        }
                        break;

                    case "exit":
                        Console.WriteLine("Adios!");
                        return;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("Choose commands!");
            Console.WriteLine("1. Create parking slot");
            Console.WriteLine("2. Parking");
            Console.WriteLine("3. Leave");
            Console.WriteLine("4. Parking Status");
            Console.WriteLine("5. Count by vehicle type");
            Console.WriteLine("6. Find slot");
            Console.WriteLine("7. Exit");
        }
    }
}