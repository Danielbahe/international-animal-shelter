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
    public class SheltersController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public SheltersController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShelter([FromBody] CreateShelterRequest request)
        {
            var command = mapper.Map<CreateShelterCommandRequest>(request);
            var response = await mediator.Send(command);

            return MapToHttpResponse(response, nameof(CreateShelter));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShelters()
        {
            var query = new GetAllSheltersQueryRequest();
            var result = await mediator.Send(query);

            var response = mapper.Map<IEnumerable<ShelterBasicInfoResponse>>(result);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShelter([FromBody] UpdateShelterRequest request)
        {
            var command = mapper.Map<UpdateShelterCommandRequest>(request);
            var response = await mediator.Send(command);

            return MapToHttpResponse(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShelter([FromBody] DeleteShelterRequest request)
        {
            var command = mapper.Map<DeleteShelterCommandRequest>(request);
            var response = await mediator.Send(command);

            return MapToHttpResponse(response);
        }
    }
}
