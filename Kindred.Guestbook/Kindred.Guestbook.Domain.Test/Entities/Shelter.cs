using Kindred.Guestbook.Domain.Commands.Shelters.CreateShelter;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.ValueObjects;
using Kindred.Guestbook.Domain.ValueObjects.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kindred.Guestbook.Domain.Test.Entities
{
    public class ShelterShould
    {
        [InlineData("valid@email.com", "validName", "+34111111111", true, true)]
        [InlineData("valid@email.com", "validName", "+34111111111", false, false)]
        [InlineData("valid@email.com", "validName", "", true, false)]
        [InlineData("valid@email.com", "", "+34111111111", true, false)]
        [InlineData("", "validName", "+34111111111", true, false)]
        [Theory]
        public void CreateShelterSuccessfully(string email, string name, string phoneNumber, bool validAddress, bool shouldBeValid)
        {
            var addressRequest = validAddress ? GetValidAddressCommandRequest() : GetInValidAddressCommandRequest();
            var shelterRequest = new CreateShelterCommandRequest(name, addressRequest, phoneNumber, email);
            var shelter = Shelter.Create(shelterRequest);

            Assert.Equal(shelter.IsSuccess, shouldBeValid);
        }

        private CreateAddressCommandRequest GetValidAddressCommandRequest()
        {
            return new CreateAddressCommandRequest("false street", "Sant Cugat del Valles", "08172", "Spain", "Catalonia");
        }

        private CreateAddressCommandRequest GetInValidAddressCommandRequest()
        {
            return new CreateAddressCommandRequest("", "", "", "", "");
        }
    }
}
