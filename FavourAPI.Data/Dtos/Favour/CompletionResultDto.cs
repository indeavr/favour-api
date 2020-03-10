using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class CompletionResultDto
    {
        public string Id { get; set; }

        public ProviderDto Consumer { get; set; }

        public string Date { get; set; }

        public string ReviewForConsumer { get; set; }

        public string ReviewForProvider { get; set; }

        public string State { get; set; }
    }
}
