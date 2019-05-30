using FavourAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FavourAPI.Data.JsonSeed
{
    public class JsonSeeder
    {
        private const string seedsFolder = @"..\FavourAPI.Data\JsonSeed";
        private readonly ModelBuilder modelBuilder;

        public JsonSeeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void RegisterJson<T>(string jsonName) where T : class
        {
            string path = Path.Combine(seedsFolder, jsonName);

            T[] entity;
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                entity = (T[])serializer.Deserialize(file, typeof(T[]));
            }

            this.modelBuilder.Entity<T>().HasData(entity);
        }
    }
}
