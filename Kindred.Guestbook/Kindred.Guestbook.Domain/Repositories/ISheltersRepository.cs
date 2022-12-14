using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;

namespace Kindred.Guestbook.Domain.Repositories
{
    public interface IShelterRepository : IRepository
    {
        void AddShelter(Shelter animal);
        Task<Result<Shelter>> GetByIdAsync(Guid id);
        void DeleteShelter(Shelter shelterToDelete);
        void UpdateShelter(Shelter shelter);
        Task<IEnumerable<Shelter>> GetAllAsync();
        Task<Result> ShelterExists(Guid id);
    }
}