namespace Comments.Domain.Entities
{
    public class EntityBase<TId>: ISqlEntity
    {
        public TId Id { get; set; }
    }
}