using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Queries.Animals
{
    internal class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQuery, IEnumerable<Animal>>
    {
        private readonly IAnimalsRepository animalRepository;
        private readonly ILogger logger;

        public GetAllAnimalsQueryHandler(IAnimalsRepository animalRepository, ILogger logger)
        {
            this.animalRepository = animalRepository;
            this.logger = logger;
        }

        public async Task<IEnumerable<Animal>> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
        {
            var animals = await animalRepository.GetAllAsync();
            logger.Debug("Animals retrieved: {animals}", animals);

            return animals;
        }
    }
}
