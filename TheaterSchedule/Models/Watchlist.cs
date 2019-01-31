namespace TheaterSchedule.Models
{
    public class Watchlist
    {
        public int AccountId { get; set; }
        public int ScheduleId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
