using System;

namespace Comments.Domain.Entities
{
    public class AuditEntity<TId>: EntityBase<TId>
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}