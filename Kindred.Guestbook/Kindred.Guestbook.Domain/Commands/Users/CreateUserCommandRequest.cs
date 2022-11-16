using CSharpFunctionalExtensions;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Users
{
    public record CreateUserCommandRequest : IRequest<Result>
    {
        public string Name { get; }
        public string Lastname { get; }
        public DateTime DateOfBirth { get; }

        public CreateUserCommandRequest(string name, string lastname, DateTime dateOfBirth)
        {
            Name = name;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
        }

    }
}
