using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Account
    {
        public Account()
        {
            Watchlist = new HashSet<Watchlist>();
        }

        public int AccountId { get; set; }
        [StringLength(60)]
        public string Password { get; set; }
        [StringLength(60)]
        public string Email { get; set; }
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneIdentifier { get; set; }

        [ForeignKey("AccountId")]
        [InverseProperty("Account")]
        public virtual Settings AccountNavigation { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Watchlist> Watchlist { get; set; }
    }
}
