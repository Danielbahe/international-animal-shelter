using CSharpFunctionalExtensions;
using MediatR;
using Serilog;
using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelter.Guestbook.Domain.Queries.Animals
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
