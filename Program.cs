using ParkingLotLLD.Models;
using ParkingLotLLD.Services;

namespace ParkingLotLLD
{
    public class Program
    {
        static void Main(string[] args)
        {
            ParkingLotService parkingLotService = new ParkingLotService();
            ControlPanel(parkingLotService);
        }

        private static bool ControlPanel(ParkingLotService parkingLotService)
        {
            while (true)
            {
                ShowMenu();

                Console.Write("Enter Your Choice(0-4): ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 0)
                    return false;

                switch (option)
                {
                    case 1:
                        parkingLotService.CreateParkingLot();
                        break;
                    case 2:
                        Console.Write("Vehicle Type for Parking (1: Bike, 2: Car, 3: Bus: ");
                        int vehicleType = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Vehicle License Number For Parking: ");
                        string licenseNumber = Console.ReadLine() ?? "";
                        Vehicle v = new(licenseNumber, (VehicleType)vehicleType);
                        parkingLotService.ParkVehicle(v);
                        break;
                    case 3:
                        Console.Write("Vehicle License Number For UnParking: ");
                        licenseNumber = Console.ReadLine() ?? "";
                        parkingLotService.UnParkVehicle(licenseNumber);
                        break;
                    case 4:
                        parkingLotService.ParkingLot?.ShowDisplayBoard();
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }


        private static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("########## MENU ##########");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create a Parking Lot");
            Console.WriteLine("2. Park a Vehicle");
            Console.WriteLine("3. UnPark a Vehicle");
            Console.WriteLine("4. Parking Display Board");
            Console.WriteLine();
        }
    }
}