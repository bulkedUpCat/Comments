using System.IO;

namespace Comments.Application.Models.Blob
{
    public class BlobInfo
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
    }
}