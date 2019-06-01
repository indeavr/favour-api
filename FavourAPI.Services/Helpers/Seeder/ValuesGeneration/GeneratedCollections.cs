using FavourAPI.Services.Helpers.Seeder.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Seeder
{
    public class GeneratedCollections : IGeneratedCollections
    {
        public ICollection<string> EmailCollection()
        {
            List<string> emails = new List<string>();

            for (int i = 1; i <= 5; i++)
            {
                emails.Add($"user{i}@gmail.com");
            }

            return emails;
        }
    }
}
