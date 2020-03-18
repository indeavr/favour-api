using System;

namespace FavourAPI.Dtos
{
    public class PhoneNumberDto
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string Number { get; set; }

        public PersonConsumerDto PersonConsumer { get; set; }

        public ProviderDto Provider { get; set; }
    }
}
