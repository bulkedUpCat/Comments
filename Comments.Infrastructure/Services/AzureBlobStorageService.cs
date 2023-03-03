using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Comments.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using BlobInfo = Comments.Application.Models.Blob.BlobInfo;

namespace Comments.Infrastructure.Services
{
    public class AzureBlobStorageService: IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureBlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> GetBlobAsync(
            string blobContainerName, 
            string name, 
            CancellationToken cancellationToken = default)
        {
            var blobContainerClient = GetContainerClient(blobContainerName);
            var blobClient = blobContainerClient.GetBlobClient(name);

            if (!await blobClient.ExistsAsync(cancellationToken))
            {
                return null;
            }
            
            return blobClient.Uri.ToString();
        }

        public async Task UploadFileAsync(
            IFormFile file, 
            string blobContainerName, 
            string fileName,
            CancellationToken cancellationToken = default)
        {
            var blobContainerClient = GetContainerClient(blobContainerName);
            var blobClient = blobContainerClient.GetBlobClient(fileName);
        
            await using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, true, cancellationToken);
        }
        
        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
        }
    }
}