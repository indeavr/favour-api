using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class PersonProvider
    {
        [ForeignKey("User")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
