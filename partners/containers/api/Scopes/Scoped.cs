namespace Easyfood.Partners.Api.Scopes
{
    public class Scoped : IScoped
    {
        public Guid Trace { get; private set; }

        public Scoped()
        {
            Trace = Guid.NewGuid();
        }

        public void Print()
        {
            Console.WriteLine($"Scoped: {Trace}");
        }
    }

    public interface IScoped
    {
        Guid Trace { get; }

        void Print();
    }
}