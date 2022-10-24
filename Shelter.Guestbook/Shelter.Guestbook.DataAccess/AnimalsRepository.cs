using Microsoft.EntityFrameworkCore;
using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.Repositories;

namespace Shelter.Guestbook.DataAccess
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private GuestbookContext Context { get; set; }

        public AnimalsRepository(GuestbookContext context)
        {
            Context = context;
        }

        public void AddAnimal(Animal animal)
        {
            Context.Animals.Add(animal);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            return await Context.Animals.ToListAsync();
        }
    }
}
