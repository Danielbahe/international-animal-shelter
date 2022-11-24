using AutoMapper;
using Kindred.Guestbook.Api.Models.Shelter;
using Kindred.Guestbook.Domain.Commands.Shelters;
using Kindred.Guestbook.Domain.Commands.Shelters.CreateShelter;
using Kindred.Guestbook.Domain.Queries.Shelters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kindred.Guestbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SheltersController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public SheltersController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IResult> CreateShelter([FromBody] CreateShelterRequest request)
        {
            var command = mapper.Map<CreateShelterCommandRequest>(request);
            var response = await mediator.Send(command);

            return response.ToHttpResponse(nameof(CreateShelter));
        }

        [HttpGet]
        public async Task<IResult> GetAllShelters()
        {
            var query = new GetAllSheltersQueryRequest();
            var result = await mediator.Send(query);

            var response = mapper.Map<IEnumerable<ShelterBasicInfoResponse>>(result);

            return Results.Ok(response);
        }

        [HttpPut]
        public async Task<IResult> UpdateShelter([FromBody] UpdateShelterRequest request)
        {
            var command = mapper.Map<UpdateShelterCommandRequest>(request);
            var response = await mediator.Send(command);

            return response.ToHttpResponse();
        }

        [HttpDelete]
        public async Task<IResult> DeleteShelter([FromBody] DeleteShelterRequest request)
        {
            var command = mapper.Map<DeleteShelterCommandRequest>(request);
            var response = await mediator.Send(command);

            return response.ToHttpResponse();
        }
    }
}
