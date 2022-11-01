using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;

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
            Context.Add(shelter);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
