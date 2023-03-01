using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Comments.API.Controllers
{
    [ApiController]
    [Route("api/blobs")]
    public class BlobsController: ControllerBase
    {
        private readonly IStorageService _storageService;

        public BlobsController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("{containerName}/{blobName}")]
        public async Task<IActionResult> GetBlob(
            string containerName,
            string blobName,
            CancellationToken cancellationToken)
        {
            var blob = await _storageService.GetBlobAsync(containerName, blobName, cancellationToken);
            return blob != null ? File(blob.Content, blob.ContentType) : NoContent();
        }

        [HttpPost("{containerName}/{blobName}")]
        public async Task<IActionResult> UploadBlob(
            string containerName,
            string blobName,
            [FromForm(Name = "file")] IFormFile file,
            CancellationToken cancellationToken)
        {
            await _storageService.UploadFileAsync(file, containerName, blobName, cancellationToken);
            return NoContent();
        }
    }
}