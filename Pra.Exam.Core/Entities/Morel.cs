namespace Pra.Exam.Core.Entities
{
    public class Morel : Mushroom
    {

        public Morel() : base("Morel", 150, 10, false)
        {
            GrowthRate = 0.5; // cm per night
            CurrentWeight = 50; // gr
        }
    }
}
