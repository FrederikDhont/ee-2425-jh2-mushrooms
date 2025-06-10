using Pra.Exam.Core.Interfaces;

namespace Pra.Exam.Core.Entities
{
    public class Morel : Mushroom, IHallucinogenic, IReproducable
    {
        // Props
        public bool HasHallucinogenicEffect { get; private set; } = false;

        // Constructor
        public Morel() : base("Morel", 150, 10, false)
        {
            GrowthRate = 0.5; // cm per night
            CurrentWeight = 50; // gr
            HasHallucinogenicEffect = CurrentSize > 3;
        }

        // Methods
        public string GetEffectDescription()
        {
            return "When this mushroom is eaten, your vision becomes blurry and very colorful";
        }

        public Mushroom Reproduce()
        {
            return new Morel();
        }
    }
}
