using CSharpFunctionalExtensions;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Domain.Repositories
{
    public interface IAnimalsRepository : IRepository
    {
        void AddAnimal(Animal animal);
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Result<Animal>> GetByIdAsync(Guid Id);
        void UpdateAnimal(Animal animal);
    }
}