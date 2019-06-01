using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Seeder.Contracts
{
    public interface IJsonManager
    {
        void SerializeJson<T>(T entity, string path);

        T DeserializeJson<T>(string path);
    }
}
