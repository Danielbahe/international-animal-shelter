using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.Repositories;

namespace Shelter.Guestbook.DataAccess
{
    public class AnimalsRepository : IAnimalsRepository
    {
        public GuestbookContext context { get; set; }

        public AnimalsRepository(GuestbookContext context)
        {
            this.context = context;
        }

        public void AddAnimal(Animal animal)
        {
            context.Animals.Add(animal);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
