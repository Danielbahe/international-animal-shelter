namespace Kindred.Guestbook.Api.Models.Animal
{
    public class UpdateAnimalRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Species { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
