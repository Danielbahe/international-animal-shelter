using Shelter.Guestbook.Domain.ValueObjects;

namespace Shelter.Guestbook.Api.Models
{
    public class CreateAnimalShelterRequest
    {
        public string Name { get; set; }
        public CreateAddressRequest Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
