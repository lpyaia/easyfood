using Easyfood.Partners.Domain.ValueObjects;

namespace Easyfood.Partners.Domain.Entities
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public Money Price { get; private set; }

        public Menu? Menu { get; private set; }

        private MenuItem()
        { }

        public MenuItem(string name, string description, string image, Money price)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}