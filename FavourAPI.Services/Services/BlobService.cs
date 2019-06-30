using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.AspNetCore.Mvc;
using FavourAPI.Services.Contracts;
using System.Threading.Tasks;

namespace FavourAPI.Services.Services
{
    public class BlobService : IBlobService
    {
        private readonly IConfiguration configuration;
        private readonly CloudBlobContainer blobContainer;

        public BlobService([FromServices] IConfiguration configuration)
        {
            this.configuration = configuration;
            this.blobContainer = GetCloudBlobContainer();
        }

        public async Task<string> UploadImage(string name, byte[] blobContent, string contentType)
        {
            var blockBlob = blobContainer.GetBlockBlobReference(name);

            await blockBlob.UploadFromByteArrayAsync(blobContent, 0, blobContent.Length);

            blockBlob.Properties.ContentType = contentType;

            await blockBlob.SetPropertiesAsync();

            return blockBlob.Uri.ToString();
        }

        public async Task<byte[]> GetImage(string name, int bufferSize)
        {
            var downloadedBuffer = new byte[bufferSize];
            await blobContainer.GetBlockBlobReference(name).DownloadToByteArrayAsync(downloadedBuffer, 0);

            return downloadedBuffer;
        }

        private CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.configuration["ConnectionStrings:AzureStorageConnectionString-1"]);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("workfavour");
            return container;
        }
    }
}
