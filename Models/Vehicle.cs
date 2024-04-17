
namespace ParkingLotLLD.Models
{
    public class Vehicle
    {
        public Vehicle(string licenseNumber, VehicleType vehicleType)
        {
            this.LicenseNumber = licenseNumber;
            this.VehicleType = vehicleType;
        }

        public string LicenseNumber { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public ParkingTicket? ParkingTicket { get; private set; }

        public void AttachParkingTicket(ParkingTicket pt)
        {
            this.ParkingTicket = pt;
        }
    }
}