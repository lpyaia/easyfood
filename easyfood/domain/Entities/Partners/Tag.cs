namespace Easyfood.Domain.Entities.Partners
{
    public class Tag : BaseEntity
    {
        public string Name { get; private set; }

        public List<Partner> Partners { get; private set; } = new();

        public Tag(string name)
        {
            Name = name;
        }

        private Tag()
        { }
    }
}