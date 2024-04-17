namespace ParkingLotLLD.Models
{
    public class ParkingFloor
    {
        public ParkingFloor(int level)
        {
            this.Level = level;
            this.ParkingSpots = new List<ParkingSpot>();
            this.ParkingSpotsMap = new Dictionary<VehicleType, (int, int)>();
        }

        public int Level { get; private set; }
        public List<ParkingSpot> ParkingSpots { get; private set; }
        public Dictionary<VehicleType, (int, int)> ParkingSpotsMap { get; private set; } // (Vacant, Occupied)

        public void AddParkingSpots(VehicleType parkingSpaceType, int count)
        {
            int lastSpotId = this.ParkingSpots.Count;
            for (int i = 1; i <= count; i++)
            {
                this.ParkingSpots.Add(new ParkingSpot(i + lastSpotId, this.Level, parkingSpaceType));

                if (!this.ParkingSpotsMap.ContainsKey(parkingSpaceType))
                    this.ParkingSpotsMap.Add(parkingSpaceType, (0, 0));


                this.ParkingSpotsMap[parkingSpaceType] = (1 + this.ParkingSpotsMap[parkingSpaceType].Item1, this.ParkingSpotsMap[parkingSpaceType].Item2);
            }
        }

        public void ShowDisplayBoard()
        {
            if (this.ParkingSpotsMap.Count == 0)
                Console.WriteLine("Parking Spots not initialized for floor {0}", this.Level);

            foreach (KeyValuePair<VehicleType, (int, int)> entry in this.ParkingSpotsMap)
            {
                Console.WriteLine("Floor = {0}, Type = {1}, Free = {2}, Occupied = {3}", this.Level, entry.Key, entry.Value.Item1, entry.Value.Item2);
            }
        }

        public bool IsParkingSpotAvailable(VehicleType vehicleType)
        {
            return this.ParkingSpots.Any(x => x.ParkingSpaceType == vehicleType && x.IsVacant());
        }

        public ParkingSpot? ParkVehicle(Vehicle vehicle)
        {
            ParkingSpot? spot = this.ParkingSpots.FirstOrDefault(x => x.ParkingSpaceType == vehicle.VehicleType && x.IsVacant());
            if (spot != null)
            {
                spot.ParkVehicle(vehicle);
                this.ParkingSpotsMap[vehicle.VehicleType] = (-1 + this.ParkingSpotsMap[vehicle.VehicleType].Item1, 1 + this.ParkingSpotsMap[vehicle.VehicleType].Item2);
            }

            return spot;
        }

        public Vehicle? UnParkVehicle(string licenseNumber)
        {
            ParkingSpot? spot = this.ParkingSpots.FirstOrDefault(x => x.Vehicle?.LicenseNumber == licenseNumber);
            Vehicle v = spot?.Vehicle;

            if (spot != null && spot.Vehicle != null)
            {
                v = spot.Vehicle;
                VehicleType vehicleType = spot.Vehicle.VehicleType;
                spot.UnParkVehicle();
                this.ParkingSpotsMap[vehicleType] = (1 + this.ParkingSpotsMap[vehicleType].Item1, -1 + this.ParkingSpotsMap[vehicleType].Item2);
            }

            return v;
        }
    }
}