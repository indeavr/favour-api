using FavourAPI.Data.Models.Enums;
using FavourAPI.Data.Models.Offerings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class PersonConsumer
    {
        [ForeignKey("User")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public string Description { get; set; }

        public virtual SexDb Sex { get; set; }

        public virtual ICollection<Location> Locations { get; set; } // v2

        public virtual ICollection<Image> Photos { get; set; }

        public string PhoneNumber { get; set; } // v2 make it class PhoneNumber and list

        public virtual User User { get; set; }

        public virtual ICollection<OngoingOffering> OngoingOfferings { get; set; }
    }
}
