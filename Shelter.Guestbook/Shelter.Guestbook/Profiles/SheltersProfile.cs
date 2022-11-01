using AutoMapper;
using Shelter.Guestbook.Api.Models;
using Shelter.Guestbook.Domain.Commands.Shelters.CreateShelter;
using Shelter.Guestbook.Domain.ValueObjects.Commands;

namespace Shelter.Guestbook.Api.Profiles
{
    public class SheltersProfile : Profile
    {
        public SheltersProfile()
        {

            CreateMap<CreateAnimalShelterRequest, CreateAnimalShelterCommandRequest>();

            CreateMap<CreateAddressRequest, CreateAddressCommandRequest>();
        }
    }
}
