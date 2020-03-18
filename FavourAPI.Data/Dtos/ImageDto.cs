using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Data.Dtos
{
    public class ImageDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        // Use the constants from ContentTypes
        public string ContentType { get; set; }

        public string Photo { get; set; }
    }
}
