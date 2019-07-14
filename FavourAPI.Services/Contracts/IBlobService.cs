using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.Services.Contracts
{
    public interface IBlobService
    {
        Task<string> UploadImage(string name, byte[] blobContent, string contentType);

        Task<string> UploadImage(string name, string blobContent, string contentType);

        Task<string> UploadImage(Guid name, string blobContent, string contentType);

        Task<byte[]> GetImage(string name, int bufferSize);
    }
}
