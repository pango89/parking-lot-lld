using System.Reflection.Emit;
using ParkingLotLLD.Models;

namespace ParkingLotLLD.Services
{
    public class ParkingLotService
    {
        public ParkingLot? ParkingLot { get; private set; }

        public void CreateParkingLot()
        {
            this.ParkingLot = new ParkingLot();
            this.AddParkingFloors(1);
        }

        public void AddParkingFloors(int floors)
        {
            for (int i = 1; i <= floors; i++)
            {
                this.ParkingLot?.AddNewParkingFloor();
                this.ParkingLot?.ParkingFloors[i - 1].AddParkingSpots(VehicleType.Bike, 5);
                this.ParkingLot?.ParkingFloors[i - 1].AddParkingSpots(VehicleType.Car, 3);
                this.ParkingLot?.ParkingFloors[i - 1].AddParkingSpots(VehicleType.Bus, 1);
            }
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            if (this.ParkingLot == null)
                return;

            foreach (ParkingFloor parkingFloor in this.ParkingLot.ParkingFloors)
            {
                if (parkingFloor.IsParkingSpotAvailable(vehicle.VehicleType))
                {
                    ParkingSpot? ps = parkingFloor.ParkVehicle(vehicle);
                    if (ps != null)
                    {
                        ParkingTicket pt = new ParkingTicket(parkingFloor.Level, ps.Id);
                        vehicle.AttachParkingTicket(pt);
                    }
                    return;
                }
            }

            Console.WriteLine("None of the parking spots are vacant for parking the Vehicle of type {0}", vehicle.VehicleType);
        }

        public void UnParkVehicle(string licenseNumber)
        {
            if (this.ParkingLot == null)
                return;

            foreach (ParkingFloor parkingFloor in this.ParkingLot.ParkingFloors)
            {
                Vehicle? v = parkingFloor.UnParkVehicle(licenseNumber);
                v?.ParkingTicket?.UpdateStatus(ParkingTicketStatus.FINISHED);
                Console.WriteLine("Total Cost Incurred = INR {0}", v?.ParkingTicket?.Cost);
            }
        }
    }

}