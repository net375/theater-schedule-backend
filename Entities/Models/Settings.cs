using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Settings
    {
        public int SettingsId { get; set; }
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        [InverseProperty("Settings")]
        public virtual Language Language { get; set; }
        [InverseProperty("AccountNavigation")]
        public virtual Account Account { get; set; }
    }
}
