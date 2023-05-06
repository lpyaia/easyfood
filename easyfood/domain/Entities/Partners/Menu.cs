using Easyfood.Domain.Entities.Partners;

namespace Easyfood.Domain.Entities.Partners
{
    public class Menu : BaseEntity
    {
        public List<MenuItem> Items { get; private set; }

        public Guid PartnerId { get; private set; }

        public Partner Partner { get; set; }

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
        }

        public Menu(Guid partnerId)
        {
            PartnerId = partnerId;
            Items = new List<MenuItem>();
        }

        public bool HasMenuItems(List<Guid> menuItemsId)
        {
            return menuItemsId.All(HasMenuItem);
        }

        public bool HasMenuItem(Guid menuItemId)
        {
            return Items.Any(x => x.Id == menuItemId);
        }
    }
}