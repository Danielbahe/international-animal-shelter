using CSharpFunctionalExtensions;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Shelters
{
    public record DeleteShelterCommandRequest : IRequest<Result>
    {
        public Guid Id { get; init; }

        public DeleteShelterCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
