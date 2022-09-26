using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Domain.Repositories
{
    public interface IAnimalsRepository : IRepository
    {
        void AddAnimal(Animal animal);
    }
}