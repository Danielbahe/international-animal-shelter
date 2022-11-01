using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Shelters.CreateShelter
{
    public class CreateShelterCommandHandler : IRequestHandler<CreateShelterCommandRequest, Result<Shelter>>
    {
        private readonly ISheltersRepository shelterRepository;
        private readonly ILogger logger;

        public CreateShelterCommandHandler(ISheltersRepository shelterRepository, ILogger logger)
        {
            this.shelterRepository = shelterRepository;
            this.logger = logger;
        }

        public async Task<Result<Shelter>> Handle(CreateShelterCommandRequest request, CancellationToken cancellationToken)
        {
            var shelter = Shelter.Create(request);
            if (shelter.IsFailure)
            {
                logger.Warning("Animal shelter can't be creaded: {e}", shelter.Error);
                return shelter;
            }

            shelterRepository.AddShelter(shelter.Value);
            await shelterRepository.SaveAsync();

            return shelter;
        }
    }
}
