namespace Shelter.Guestbook.Domain.ValueObjects.Commands
{
    public record CreateAddressCommandRequest
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string ZipCode { get; init; }
        public string Country { get; init; }
        public string State { get; init; }

        public CreateAddressCommandRequest(string street, string city, string zipCode, string country, string state)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
            Country = country;
            State = state;
        }
    }
}