using AutoMapper;
using Kindred.Guestbook.Api.Models;
using Kindred.Guestbook.Domain.Commands.Shelters.CreateShelter;
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
        public async Task<IActionResult> CreateShelter([FromBody] CreateShelterRequest request)
        {
            var command = mapper.Map<CreateShelterCommandRequest>(request);
            var result = await mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}
