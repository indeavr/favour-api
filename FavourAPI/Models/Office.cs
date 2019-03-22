using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class Office
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<Email> Emails { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public ICollection<Industry> Industries { get; set; }

        public virtual CompanyProvider CompanyProvider { get; set; }
    }
}
