namespace TheaterSchedule.Models
{
    public class Settings
    {
        public int SettingsId { get; set; }
        public string Language { get; set; }

        public virtual Account Account { get; set; }
    }
}
