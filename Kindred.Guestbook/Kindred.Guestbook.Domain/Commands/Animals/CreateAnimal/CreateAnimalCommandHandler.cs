using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommandRequest, Result<Animal>>
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

        public async Task<Result<Animal>> Handle(CreateAnimalCommandRequest request, CancellationToken cancellationToken)
        {
            var shelterExists = await shelterRepository.ShelterExists(request.ShelterId);

            if (shelterExists.IsFailure)
            {
                logger.Warning("Animal can't be creaded: {e}", shelterExists.Error);
                return Result.Failure<Animal>(shelterExists.Error);
            }

            logger.Information("Hey: {@request}", request);
            var animal = Animal.Create(request);
            if (animal.IsFailure)
            {
                logger.Warning("Animal can't be creaded: {e}", animal.Error);
                return animal;
            }
            logger.Information("Hey2: {@animal}", animal.Value);

            animalRepository.AddAnimal(animal.Value);
            await animalRepository.SaveAsync();

            return animal;
        }
    }
}
