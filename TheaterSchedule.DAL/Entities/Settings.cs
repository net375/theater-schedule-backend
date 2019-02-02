namespace TheaterSchedule.DAL.Entities
{
    public class Settings
    {
        public string SettingsId { get; set; }
        public string Language { get; set; }

        public virtual Account Account { get; set; }
    }
}
