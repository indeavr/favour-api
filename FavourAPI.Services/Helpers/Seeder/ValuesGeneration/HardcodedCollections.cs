using FavourAPI.Services.Helpers.Seeder.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FavourAPI.Services.Helpers.Seeder
{
    public class HardcodedCollections : IHardcodedCollections
    {
        private readonly string folder = $@"{AppDomain.CurrentDomain.BaseDirectory}/../../../../FavourAPI.Services/Helpers/Seeder/ValuesGeneration/HardcodedCollections";

        private readonly IJsonManager jsonManager;

        public HardcodedCollections(IJsonManager jsonManager)
        {
            this.jsonManager = jsonManager;
        }

        public ICollection<string> GetPersonProvidersFirstNames()
        {
            string path = Path.Combine(folder, "personproviders_firstnames.json");
            return jsonManager.DeserializeJson<ICollection<string>>(path);
        }

        public ICollection<string> GetPersonProvidersLastNames()
        {
            string path = Path.Combine(folder, "personproviders_lastnames.json");
            return jsonManager.DeserializeJson<ICollection<string>>(path);
        }
    }
}
