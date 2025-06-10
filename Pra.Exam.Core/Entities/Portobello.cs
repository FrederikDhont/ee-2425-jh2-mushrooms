using Pra.Exam.Core.Interfaces;

namespace Pra.Exam.Core.Entities
{
    public class Portobello : Mushroom, IReproducable
    {

        public Portobello() : base("Portobello", 75, 7, false)
        {
            GrowthRate = 2; // cm per night
        }

        public Mushroom Reproduce()
        {
            return new Portobello();
        }
    }
}
