using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;

namespace Kindred.Guestbook.Domain.Repositories
{
    public interface IAnimalRepository : IRepository
    {
        void AddAnimal(Animal animal);
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Result<Animal>> GetByIdAsync(Guid Id);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(Animal animalToDelete);
    }
}