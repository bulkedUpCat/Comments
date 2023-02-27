using System;

namespace Comments.Domain.Entities
{
    public class Comment: AuditEntity<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public string Text { get; set; }
    }
}