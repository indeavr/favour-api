using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class Office
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public virtual IList<OfficeIndustry> OfficeIndustries { get; set; }

        public virtual CompanyProvider CompanyProvider { get; set; }

        [NotMapped]
        public ICollection<Industry> Industries { get; set; }
    }
}
