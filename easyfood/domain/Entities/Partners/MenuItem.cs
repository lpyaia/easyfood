using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities.Partners
{
    public class MenuItem : BaseEntity
    {
        public string ItemName { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public Money Price { get; private set; }

        public Guid MenuId { get; private set; }

        public Menu Menu { get; private set; }

        private MenuItem()
        {
        }

        public MenuItem(string itemName, string description, string image, Money price, Guid menuId)
        {
            ItemName = itemName;
            Description = description;
            Image = image;
            Price = price;
            MenuId = menuId;
        }
    }
}