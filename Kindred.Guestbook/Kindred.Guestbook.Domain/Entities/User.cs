using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Commands.Users;
using Kindred.Infrastructure;

namespace Kindred.Guestbook.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        private User()
        {
        }

        public static Result<User> Create(CreateUserCommandRequest request)
        {
            var user = new User();

            Constraints
                .AddResult(user.SetName(request.Name))
                .AddResult(user.SetLastname(request.Lastname))
                .AddResult(user.SetDateOfBirth(request.DateOfBirth))
                .CombineIn(user);

            return user;
        }

        private Result<User> SetName(string name)
        {
            name.Trim();
            if (string.IsNullOrEmpty(name)) return Result.Failure<User>("Name is mandatory");

            Name = name;
            return Result.Success(this);
        }

        private Result<User> SetLastname(string lastname)
        {
            lastname.Trim();
            if (string.IsNullOrEmpty(lastname)) return Result.Failure<User>("Name is mandatory");

            Lastname = lastname;
            return Result.Success(this);
        }

        private Result<User> SetDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;

            return Result.Success(this);
        }
    }
}
