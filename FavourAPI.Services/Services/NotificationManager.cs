using Firebase.Database;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Helpers
{
    public class NotificationManager : INotificationManager
    {
        private readonly IConfiguration configuration;

        public NotificationManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendNotification(Notification notification,
            IReadOnlyDictionary<string, string> data,
            string firebaseUserId)
        {
            List<string> fcmTokens = await this.GetFCMTokens(firebaseUserId);

            MulticastMessage multiMessage = new MulticastMessage()
            {
                Tokens = fcmTokens,
                Notification = notification,
                Data = data
            };

            BatchResponse response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(multiMessage);

            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }

        private async Task<List<string>> GetFCMTokens(string firebaseUserId)
        {
            var secret = this.configuration.GetSection("FavourAPI_Firebase_Secret").Value;
            var firebaseClient = new FirebaseClient(
               "https://all-favour.firebaseio.com/",
               new FirebaseOptions
               {
                   AuthTokenAsyncFactory = () => Task.FromResult(secret)
               }
           );

            // many devices = many tokens
            var fcmTokens = await firebaseClient
                .Child($"users/{firebaseUserId}/fcmTokens")
                .OnceAsync<string>();

            return fcmTokens.Select((token) => token.Key).ToList();
        }
    }
}
