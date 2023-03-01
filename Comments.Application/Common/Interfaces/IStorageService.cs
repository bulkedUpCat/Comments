using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Models.Blob;
using Microsoft.AspNetCore.Http;

namespace Comments.Application.Common.Interfaces
{
    public interface IStorageService
    {
        Task<BlobInfo?> GetBlobAsync(
            string blobContainerName,
            string name, 
            CancellationToken cancellationToken = default);
        
        Task UploadFileAsync(
            IFormFile file, 
            string blobContainerName, 
            string fileName, 
            CancellationToken cancellationToken = default);
    }
}