using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class Settings
    {

        public string SettingsId { get; set; }
        public int LanguageId { get; set; }


        public virtual Language Language { get; set; }
        public virtual Account Account { get; set; }
    }
}
