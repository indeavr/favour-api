using System;

namespace FavourAPI.Dtos
{
    public class EmailDto
    {
        public Guid Id { get; set; }

        public string Label { get; set; }

        public string EmailAddress { get; set; }
    }
}
