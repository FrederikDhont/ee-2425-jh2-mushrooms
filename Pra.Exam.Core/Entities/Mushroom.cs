namespace Pra.Exam.Core.Entities
{
    public abstract class Mushroom
    {
        // Fields
        private double currentSize;

        private double maxSize;

        private double currentWeight;

        private double maxWeight;

        // Props
        public string Name { get; protected set; }

        public bool IsAlive { get; set; }

        public bool IsPoisonous { get; protected set; }

        public double CurrentSize
        {
            get { return currentSize; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Huidige grootte moet minstens 0 cm bedragen");
                }

                currentSize = value;
            }
        }

        public double MaxSize
        {
            get { return maxSize; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Maximale grootte moet minstens 1 cm bedragen");
                }

                maxSize = value;
            }
        }

        public double CurrentWeight
        {
            get { return currentWeight; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Huidig gewicht moet minstens 0 gram bedragen");
                }

                currentWeight = value;
            }
        }

        public double MaxWeight
        {
            get { return maxWeight; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Maximaal gewicht moet minstens 1 gram bedragen");
                }

                maxWeight = value;
            }
        }

        public double GrowthRate { get; protected set; } = 1;

        // Constructors
        protected Mushroom(string name)
        {
            Name = name;
        }

        protected Mushroom(string name, double maxWeight) : this(name)
        {
            MaxWeight = maxWeight;
        }

        protected Mushroom(string name, double maxWeight, double maxSize) : this(name, maxWeight)
        {
            MaxSize = maxSize;
        }

        protected Mushroom(string name, double maxWeight, double maxSize, bool isPoisonous) : this(name, maxWeight, maxSize)
        {
            IsPoisonous = isPoisonous;
        }

        // Methods
    }
}
