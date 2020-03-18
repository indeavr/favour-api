using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        // Use the constants from ContentTypes
        public string ContentType { get; set; }

        public string Uri { get; set; }
    }
}
