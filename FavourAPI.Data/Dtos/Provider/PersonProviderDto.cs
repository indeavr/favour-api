namespace FavourAPI.Dtos
{
    public class PersonConsumerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public EmailDto[] Emails { get; set; }

        public PhoneNumberDto[] PhoneNumbers { get; set; }
    }
}
