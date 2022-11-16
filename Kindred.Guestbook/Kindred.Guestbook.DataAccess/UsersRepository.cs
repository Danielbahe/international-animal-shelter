using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kindred.Guestbook.DataAccess
{
    public class UsersRepository : IUserRepository
    {
        private GuestbookContext Context { get; set; }

        public UsersRepository(GuestbookContext context)
        {
            Context = context;
        }

        public void CreateUser(User user)
        {
            Context.Users.Add(user);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<Result<User>> GetByIdAsync(Guid id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);

            return user == null ? Result.Failure<User>($"User with Id: {id} not found") : Result.Success(user);
        }

        public void DeleteUser(User userToDelete)
        {
            Context.Users.Update(userToDelete);
        }

        public void UpdateUser(User user)
        {
            Context.Users.Update(user);
        }
    }
}
