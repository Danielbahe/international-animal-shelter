using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shelter.Guestbook.Api.Dto;
using Shelter.Guestbook.Api.Models;
using Shelter.Guestbook.Domain.Animals.CreateAnimal;
using Shelter.Guestbook.Domain.Commands.Shelters.CreateShelter;

namespace Shelter.Guestbook.Api.Controllers
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
        public async Task<IActionResult> CreateShelter([FromBody] CreateAnimalShelterRequest request)
        {
            var command = mapper.Map<CreateAnimalShelterCommandRequest>(request);
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
