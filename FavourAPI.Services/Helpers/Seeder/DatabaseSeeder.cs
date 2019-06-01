using FavourAPI.Data;
using FavourAPI.Data.Models;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers.Seeder.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Seeder
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly WorkFavourDbContext context;
        private readonly IGeneratedCollections generatedCollections;
        private readonly IHardcodedCollections hardcodedCollections;
        private readonly ICalculatedCollections calculatedCollections;

        public DatabaseSeeder([FromServices] WorkFavourDbContext workFavourDbContext, 
            IGeneratedCollections generatedCollections, 
            IHardcodedCollections hardcodedCollections, 
            ICalculatedCollections calculatedCollections)
        {
            this.context = workFavourDbContext;
            this.generatedCollections = generatedCollections;
            this.hardcodedCollections = hardcodedCollections;
            this.calculatedCollections = calculatedCollections;
        }

        public void SeedData()
        {
            TableSeeder<User>.ToContext(context).RowsCount(5)
                    .Column(u => u.Email).SetCollection(() => generatedCollections.EmailCollection())
                    .Column(u => u.Password).SetCollection(() => calculatedCollections.UsersPasswords())
                    .Column(u => u.PasswordHash).SetCollection(() => calculatedCollections.UsersPasswordHashes())
                    .Column(u => u.PasswordSalt).SetCollection(() => calculatedCollections.UsersPasswordSalts())
                .Apply();
        }
    }
}
