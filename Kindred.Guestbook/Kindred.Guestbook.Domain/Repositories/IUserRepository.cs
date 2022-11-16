using Kindred.Guestbook.Domain.Entities;

namespace Kindred.Guestbook.Domain.Repositories
{
    public interface IUserRepository : IRepository
    {
        void CreateUser(User user);
    }
}
