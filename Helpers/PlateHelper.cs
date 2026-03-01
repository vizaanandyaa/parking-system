using System.Linq;

namespace ParkingSystem.Helpers
{
    public static class PlateHelper
    {
        public static bool IsOddPlate(string regNo)
        {
            var numberPart = new string(regNo.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(numberPart)) return false;

            int lastDigit = int.Parse(numberPart.Last().ToString());
            return lastDigit % 2 != 0;
        }
    }
}