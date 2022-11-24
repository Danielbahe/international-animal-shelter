using Kindred.Infrastructure;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Shelters
{
    public record DeleteShelterCommandRequest : IRequest<Response>
    {
        public Guid Id { get; init; }

        public DeleteShelterCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
