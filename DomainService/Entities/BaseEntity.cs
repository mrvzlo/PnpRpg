namespace Pnprpg.DomainService.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
