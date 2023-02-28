using System;
using System.Collections.Generic;

namespace Comments.Domain.Entities
{
    public class Comment: AuditEntity<Guid>
    {
        public string HomePage { get; set; }
        public string Text { get; set; }

        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        
        public virtual Comment? ParentComment { get; set; }
        public virtual ICollection<Comment> Replies { get; set; }
    }
}