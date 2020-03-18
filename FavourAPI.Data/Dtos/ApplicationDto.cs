using FavourAPI.Data.Dtos.Offerings;
using System;
using System.Collections.Generic;

namespace FavourAPI.Dtos
{
    public class ApplicationDto
    {
        public string Id { get; set; }

        public List<PeriodDto> Time { get; set; }

        public DateTime ApplyTime { get; set; }

        public string Message { get; set; }

        public PersonConsumerDto PersonConsumer { get; set; }

        public ActiveJobOfferDto ActiveJobOffer { get; set; }

        public ActiveOfferingDto ActiveOfferings { get; set; }
    }
}
