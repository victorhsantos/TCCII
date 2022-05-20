namespace TCCII.Deputados.Core.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExcludedAt { get; set; }

        protected BaseEntity() { }
    }
}
