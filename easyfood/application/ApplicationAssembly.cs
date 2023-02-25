using System.Reflection;

namespace Easyfood.Application
{
    public class ApplicationAssembly
    {
        protected ApplicationAssembly()
        {
        }

        public static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
    }
}