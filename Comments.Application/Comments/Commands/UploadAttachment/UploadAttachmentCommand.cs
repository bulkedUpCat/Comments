using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Comments.Application.Comments.Commands.UploadAttachment
{
    public class UploadAttachmentCommand: IRequest
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; }
    }
}