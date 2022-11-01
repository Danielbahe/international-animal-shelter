using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kindred.Guestbook.DataAccess
{
    public class SheltersRepository : ISheltersRepository
    {
        private GuestbookContext Context { get; set; }

        public SheltersRepository(GuestbookContext context)
        {
            Context = context;
        }

        public void AddShelter(Shelter shelter)
        {
            Context.Shelters.Add(shelter);
        }
        public async Task<Result<Shelter>> GetByIdAsync(Guid id)
        {
            var shelter = await Context.Shelters.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);

            return shelter == null ? Result.Failure<Shelter>($"Shelter with Id: {id} not found") : Result.Success(shelter);
        }

        public async Task<IEnumerable<Shelter>> GetAllAsync()
        {
            return await Context.Shelters.Where(a => !a.IsDeleted).ToListAsync();
        }

        public void DeleteShelter(Shelter shelterToDelete)
        {
            Context.Shelters.Update(shelterToDelete);
        }

        public void UpdateShelter(Shelter shelter)
        {
            Context.Shelters.Update(shelter);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
