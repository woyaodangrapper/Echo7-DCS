namespace ECHO.Infrastructure.Entities
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}