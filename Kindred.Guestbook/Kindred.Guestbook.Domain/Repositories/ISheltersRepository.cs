using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;

namespace Kindred.Guestbook.Domain.Repositories
{
    public interface ISheltersRepository : IRepository
    {
        void AddShelter(Shelter animal);
        Task<Result<Shelter>> GetByIdAsync(Guid id);
        void DeleteShelter(Shelter shelterToDelete);
        void UpdateShelter(Shelter shelter);
        Task<IEnumerable<Shelter>> GetAllAsync();
    }
}