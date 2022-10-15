using Shelter.Guestbook.Api.Controllers;

namespace Shelter.Guestbook.Bdd.StepDefinitions
{
    [Binding]
    public class AnimalStepDefinitions
    {
        [Given("the name is {string}")]
        public void GivenTheNameIs(string lua)
        {
            throw new PendingStepException();
        }

        [Given("the species is {string}")]
        public void GivenTheSpeciesIs(string cat)
        {
            throw new PendingStepException();
        }

        [Given("the description is {string}")]
        public void GivenTheDescriptionIs(string cute)
        {
            throw new PendingStepException();
        }

        [When("animals is sent to the server")]
        public void WhenAnimalsIsSentToTheServer()
        {
            throw new PendingStepException();
        }

        [Then("animal is created")]
        public void ThenAnimalIsCreated()
        {
            var controller = new AnimalsController();

            controller.CreateAnimal();
        }

        [Then("animal is not created")]
        public void ThenAnimalIsNotCreated()
        {
            throw new PendingStepException();
        }
    }
}
