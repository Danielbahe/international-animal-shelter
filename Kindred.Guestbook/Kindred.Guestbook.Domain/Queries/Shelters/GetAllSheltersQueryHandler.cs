using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Queries.Shelters
{
    internal class GetAllSheltersQueryHandler : IRequestHandler<GetAllSheltersQueryRequest, IEnumerable<Shelter>>
    {
        private readonly ISheltersRepository shelterRepository;
        private readonly ILogger logger;

        public GetAllSheltersQueryHandler(ISheltersRepository shelterRepository, ILogger logger)
        {
            this.shelterRepository = shelterRepository;
            this.logger = logger;
        }

        public async Task<IEnumerable<Shelter>> Handle(GetAllSheltersQueryRequest request, CancellationToken cancellationToken)
        {
            var shelters = await shelterRepository.GetAllAsync();
            logger.Debug("Shelters retrieved: {shelters}", shelters);

            return shelters;
        }
    }
}
