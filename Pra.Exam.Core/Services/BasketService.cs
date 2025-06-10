using Pra.Exam.Core.Entities;

namespace Pra.Exam.Core.Services
{
    public class BasketService
    {
        private static int addCount = 0;

        // Private fields
        private List<Mushroom> mushrooms;

        // Public props
        public IEnumerable<Mushroom> Mushrooms
        {
            get { return mushrooms.AsReadOnly(); }
        }

        // Constructor
        public BasketService()
        {
            mushrooms = new List<Mushroom>();
        }

        // Methods
        public void AddMushroom(Mushroom mushroom)
        {
            if (addCount >= 5)
            {
                throw new InvalidOperationException("Sorry, your basket already contains the maximum amount of mushrooms.");
            }

            if (mushrooms.Count >= 2)
            {
                addCount++;
                return;
            }

            mushrooms.Add(mushroom);
        }
    }
}
