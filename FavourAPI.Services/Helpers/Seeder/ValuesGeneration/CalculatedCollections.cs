using FavourAPI.Services.Helpers.Seeder.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FavourAPI.Services.Helpers.Seeder
{
    public class CalculatedCollections : ICalculatedCollections
    {
        private readonly string folder = $@"{AppDomain.CurrentDomain.BaseDirectory}/../../../../FavourAPI.Services/Helpers/Seeder/ValuesGeneration/CalculatedCollections";

        private readonly IHardcodedCollections hardcodedCollections;
        private readonly IJsonManager jsonManager;

        public CalculatedCollections(IHardcodedCollections hardcodedCollections, IJsonManager jsonManager)
        {
            this.hardcodedCollections = hardcodedCollections;
            this.jsonManager = jsonManager;
        }

        public ICollection<string> UsersPasswords()
        {
            List<string> passwords = this.hardcodedCollections.GetPersonProvidersLastNames()
                .Select(ppfn => $"{ppfn.ToLower()}")
                .ToList();

            string path = Path.Combine(folder, "users_passwords");
            this.jsonManager.SerializeJson(passwords, path);

            return passwords;
        }

        public ICollection<byte[]> UsersPasswordHashes()
        {
            List<byte[]> passwordHashes = this.UsersPasswords()
                .Select(up =>
                {
                    CreatePasswordHash(up, out byte[] passwordHash, out byte[] passwordSalt);
                    return passwordHash;
                })
                .Cast<byte[]>()
                .ToList();

            string path = Path.Combine(folder, "users_passwordheshes");
            this.jsonManager.SerializeJson(passwordHashes, path);

            return passwordHashes;
        }

        public ICollection<byte[]> UsersPasswordSalts()
        {
            List<byte[]> passwordSalts = this.UsersPasswords()
                .Select(up =>
                {
                    CreatePasswordHash(up, out byte[] passwordHash, out byte[] passwordSalt);
                    return passwordSalt;
                })
                .Cast<byte[]>()
                .ToList();

            string path = Path.Combine(folder, "users_passwordsalts");
            this.jsonManager.SerializeJson(passwordSalts, path);

            return passwordSalts;
        }

        #region Private Methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        #endregion
    }
}
