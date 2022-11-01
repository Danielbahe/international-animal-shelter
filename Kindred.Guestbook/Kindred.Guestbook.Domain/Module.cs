using System.Reflection;

namespace Kindred.Guestbook.Domain
{
    public class Module
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
