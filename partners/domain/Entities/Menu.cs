namespace Easyfood.Partners.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public List<MenuItem> Items { get; private set; }

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
        }

        public Menu()
        {
            Items = new List<MenuItem>();
        }
    }
}