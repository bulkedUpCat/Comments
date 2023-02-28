using System;
using System.Collections.Generic;

namespace Comments.Domain.Entities
{
    public class User: AuditEntity<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];

        public virtual ICollection<Comment> Comments { get; set; }
    }
}