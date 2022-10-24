using System.Reflection;

namespace Shelter.Guestbook.Api
{
    public static class AssembliesHelper
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }

        public static Assembly[] GetAllAssemblies()
        {
            var assemblies = new List<Assembly>
            {
                GetAssembly(),
                Domain.Module.GetAssembly()
            };

            return assemblies.ToArray();
        }
    }
}
