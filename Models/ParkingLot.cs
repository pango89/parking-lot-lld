namespace ParkingLotLLD.Models
{
    public class ParkingLot
    {
        public ParkingLot()
        {
            this.ParkingFloors = new List<ParkingFloor>();
        }

        public void AddNewParkingFloor()
        {
            int lastParkingLevel = this.ParkingFloors.Count;
            this.ParkingFloors.Add(new ParkingFloor(lastParkingLevel + 1));
        }

        public List<ParkingFloor> ParkingFloors { get; private set; }

        public void ShowDisplayBoard()
        {
            foreach (var parkingFloor in this.ParkingFloors)
            {
                parkingFloor.ShowDisplayBoard();
            }
        }
    }
}
