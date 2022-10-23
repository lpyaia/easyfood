namespace Easyfood.Partners.Api.Scopes
{
    public class Transient : ITransient
    {
        private readonly IScoped _scoped;

        public Guid Trace { get; private set; }

        public Transient(IServiceProvider serviceProvider)
        {
            Trace = Guid.NewGuid();

            using var scope = serviceProvider.CreateScope();

            _scoped = scope.ServiceProvider.GetRequiredService<IScoped>();
        }

        public void Print()
        {
            _scoped.Print();
            Console.WriteLine($"Transient: {Trace}");
        }
    }

    public interface ITransient
    {
        Guid Trace { get; }

        void Print();
    }
}