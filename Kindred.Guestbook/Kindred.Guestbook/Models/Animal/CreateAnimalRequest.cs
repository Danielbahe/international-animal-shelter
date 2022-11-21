namespace Kindred.Guestbook.Api.Models.Animal
{
    public class CreateAnimalRequest
    {
        public string Name { get; set; }
        public int Species { get; set; }
        public string Description { get; set; }
        public Guid ShelterId { get; set; }
        public int Status { get; set; }
    }
}
