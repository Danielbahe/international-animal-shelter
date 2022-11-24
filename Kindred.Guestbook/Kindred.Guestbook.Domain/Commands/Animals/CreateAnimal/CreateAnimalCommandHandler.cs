using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Kindred.Infrastructure;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommandRequest, Response<Animal>>
    {
        private readonly IAnimalsRepository animalRepository;
        private readonly ISheltersRepository shelterRepository;
        private readonly ILogger logger;

        public CreateAnimalCommandHandler(IAnimalsRepository animalRepository, ILogger logger, ISheltersRepository shelterRepository)
        {
            this.animalRepository = animalRepository;
            this.logger = logger;
            this.shelterRepository = shelterRepository;
        }

        public async Task<Response<Animal>> Handle(CreateAnimalCommandRequest request, CancellationToken cancellationToken)
        {
            var shelterExists = await shelterRepository.ShelterExists(request.ShelterId);

            if (shelterExists.IsFailure)
            {
                var result = Result.Failure<Animal>(shelterExists.Error);
                return result.ToResponse(ResponseCode.ValidationError);
            }

            var animal = Animal.Create(request);
            if (animal.IsFailure)
            {
                logger.Warning("Animal can't be creaded: {e}", animal.Error);
                logger.Information("{a}", animal);
                return animal.ToResponse(ResponseCode.ValidationError);
            }

            animalRepository.AddAnimal(animal.Value);
            await animalRepository.SaveAsync();
            logger.Information("{a}", animal);

            return animal.ToResponse(ResponseCode.Created);
        }
    }
}