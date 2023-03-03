using System;
using System.Collections.Generic;

namespace Comments.Application.Models.Comment
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public string Text { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<CommentModel> Replies { get; set; }
    }
}