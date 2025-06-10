using Pra.Exam.Core.Entities;

namespace Pra.Exam.Core.Services
{
    public class ForestService
    {
        // Private fields
        private List<Mushroom> mushrooms;

        // Public props
        public IEnumerable<Mushroom> Mushrooms
        {
            get { return mushrooms.AsReadOnly(); }
        }

        // Constructor
        public ForestService(bool seedData)
        {
            if (seedData)
            {
                SeedMushrooms();
            }
            else
                mushrooms = new List<Mushroom>();
        }

        // Methods
        void SeedMushrooms()
        {
            Portobello portobello = new Portobello();
            Chanterelle chanterelle = new Chanterelle();
            Morel morel = new Morel();

            // Add data to list
            mushrooms = new List<Mushroom> { portobello, chanterelle, morel };

        }

        void Plant(Mushroom mushroom)
        {
            if (mushroom == null)
            {
                throw new ArgumentNullException("Gelieve een paddenstoel toe te voegen");
            }
            mushrooms.Add(mushroom);
        }

        bool Pick(Mushroom mushroom)
        {
            try
            {
                mushrooms.Remove(mushroom);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
