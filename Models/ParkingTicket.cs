
namespace ParkingLotLLD.Models
{
    public class ParkingTicket
    {
        private static int autoIncrementId = 1;
        public ParkingTicket(int level, int spot)
        {
            this.Id = autoIncrementId++;
            this.Level = level;
            this.Spot = spot;
            this.EntryTime = DateTime.Now;
            this.Cost = 0.0;
            this.Status = ParkingTicketStatus.ACTIVE;
        }

        public int Id { get; private set; }
        public int Level { get; private set; }
        public int Spot { get; private set; }
        public DateTime EntryTime { get; private set; }
        public DateTime ExitTime { get; private set; }
        public double Cost { get; private set; }
        public ParkingTicketStatus Status { get; private set; }

        public void UpdateStatus(ParkingTicketStatus parkingTicketStatus)
        {
            this.Status = parkingTicketStatus;
            this.ExitTime = DateTime.Now;
            TimeSpan duration = this.ExitTime - this.EntryTime;
            this.Cost = duration.TotalHours * 100;
        }
    }
}