namespace Pra.Exam.Core.Entities
{
    public class Portobello : Mushroom
    {

        public Portobello() : base("Portobello", 75, 7, false)
        {
            GrowthRate = 2; // cm per night
        }
    }
}
