using System.Reflection;

namespace Easyfood.Partners.Application
{
    public class ApplicationAssembly
    {
        protected ApplicationAssembly()
        {
        }

        public static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
    }
}