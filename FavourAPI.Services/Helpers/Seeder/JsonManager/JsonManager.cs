using FavourAPI.Services.Helpers.Seeder.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FavourAPI.Services.Helpers.Seeder.JsonManager
{
    public class JsonManager : IJsonManager
    {
        public void SerializeJson<T>(T entity, string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entity);
            }
        }

        public T DeserializeJson<T>(string path)
        {
            T entity;
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                entity = (T)serializer.Deserialize(file, typeof(T));
            }

            return entity;
        }
    }
}
