using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kindred.Guestbook.DataAccess
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

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await Context.Animals.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<Result<Animal>> GetByIdAsync(Guid id)
        {
            var animal = await Context.Animals.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);

            return animal == null ? Result.Failure<Animal>($"Animal with Id: {id} not found") : Result.Success(animal);
        }

        public void DeleteAnimal(Animal animalToDelete)
        {
            Context.Animals.Update(animalToDelete);
        }

        public void UpdateAnimal(Animal animal)
        {
            Context.Animals.Update(animal);
        }
    }
}
