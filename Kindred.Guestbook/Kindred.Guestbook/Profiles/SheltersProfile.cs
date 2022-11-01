using AutoMapper;
using Kindred.Guestbook.Api.Models;
using Kindred.Guestbook.Domain.Commands.Shelters.CreateShelter;
using Kindred.Guestbook.Domain.ValueObjects.Commands;

namespace Kindred.Guestbook.Api.Profiles
{
    public class SheltersProfile : Profile
    {
        public SheltersProfile()
        {

            CreateMap<CreateShelterRequest, CreateShelterCommandRequest>();

            CreateMap<CreateAddressRequest, CreateAddressCommandRequest>();
        }
    }
}
