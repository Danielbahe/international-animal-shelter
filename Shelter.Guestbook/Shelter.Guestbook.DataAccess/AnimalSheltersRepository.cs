using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.Repositories;

namespace Shelter.Guestbook.DataAccess
{
    public class AnimalSheltersRepository : IAnimalSheltersRepository
    {
        private GuestbookContext Context { get; set; }

        public AnimalSheltersRepository(GuestbookContext context)
        {
            Context = context;
        }

        public void AddShelter(AnimalShelter animalShelter)
        {
            Context.Add(animalShelter);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
