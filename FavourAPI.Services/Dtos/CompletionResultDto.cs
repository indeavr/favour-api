using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class CompletionResultDto
    {
        public string Id { get; set; }

        public ConsumerDto Consumer { get; set; }

        public string ReviewForConsumer { get; set; }

        public string ReviewForProvider { get; set; }

        public string State { get; set; }
    }
}
