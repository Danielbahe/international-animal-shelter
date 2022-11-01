using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Domain.Repositories
{
    public interface IAnimalSheltersRepository : IRepository
    {
        void AddShelter(AnimalShelter animal);
    }
}