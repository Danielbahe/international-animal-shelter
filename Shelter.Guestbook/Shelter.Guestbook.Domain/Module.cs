using System.Reflection;

namespace Shelter.Guestbook.Domain
{
    public class Module
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
