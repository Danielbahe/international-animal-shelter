﻿namespace Shelter.Guestbook.Api.Models
{
    public class CreateAddressRequest
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}
