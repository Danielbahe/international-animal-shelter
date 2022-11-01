using Kindred.Guestbook.Domain.Entities;

namespace Kindred.Guestbook.Domain.Repositories
{
    public interface ISheltersRepository : IRepository
    {
        void AddShelter(Shelter animal);
    }
}