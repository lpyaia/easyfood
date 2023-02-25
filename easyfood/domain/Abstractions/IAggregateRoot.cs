namespace Easyfood.Domain.Abstractions
{
    public interface IAggregateRoot
    {
        public Guid Id { get; set; }
    }
}