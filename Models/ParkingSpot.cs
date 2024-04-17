namespace ParkingLotLLD.Models
{
    public class ParkingSpot
    {
        public ParkingSpot(int id, int level, VehicleType parkingSpaceType)
        {
            this.Id = id;
            this.Level = level;
            this.ParkingSpaceType = parkingSpaceType;
        }

        public int Id { get; private set; }
        public int Level { get; private set; }
        public VehicleType ParkingSpaceType { get; private set; }
        public Vehicle? Vehicle { get; private set; }
        public bool IsVacant() => this.Vehicle == null;

        public void ParkVehicle(Vehicle vehicle)
        {
            if (vehicle.VehicleType != this.ParkingSpaceType)
            {
                Console.WriteLine("Vehicle ${0} can not be parked in ${1} spot", vehicle.VehicleType.ToString(), this.ParkingSpaceType.ToString());
                return;
            }

            this.Vehicle = vehicle;
        }

        public void UnParkVehicle()
        {
            if (!this.IsVacant())
                this.Vehicle = null;
        }
    }
}