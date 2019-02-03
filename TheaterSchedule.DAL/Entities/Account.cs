using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class Account
    {
        public Account()
        {
            Watchlist = new HashSet<Watchlist>();
        }

        public int AccountId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PhoneIdentifier { get; set; }
        public int SettingsId { get; set; }

        public virtual Settings AccountNavigation { get; set; }
        public virtual ICollection<Watchlist> Watchlist { get; set; }
    }
}
