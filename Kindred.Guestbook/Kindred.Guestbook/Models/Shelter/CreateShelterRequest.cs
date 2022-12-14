namespace Kindred.Guestbook.Api.Models.Shelter
{
    public class CreateShelterRequest
    {
        public string Name { get; set; }
        public CreateAddressRequest Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
