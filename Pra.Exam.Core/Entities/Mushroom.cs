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

        public bool IsAlive { get; set; } = true;

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
        public override string ToString()
        {
            string notAliveIcon = !IsAlive ? "💀 " : "";
            return $"{notAliveIcon}{Name}:   ⚖️ {Math.Round(CurrentWeight, 0)} gr. (max: {MaxWeight})   📏 {GetSizeDisplay()}   📈 {GrowthRate} cm/night";
        }

        string GetSizeDisplay()
        {
            string sizeDisplay = "";

            for (int i = 0; i < (int)CurrentSize; i++)
            {
                sizeDisplay += "◉";
            }

            for (int i = 0; i < (MaxSize - (int)CurrentSize); i++)
            {
                sizeDisplay += "○";
            }

            return sizeDisplay + $"{CurrentSize}";
        }

        public void Grow(int numOfNights)
        {
            // Only grow mushrooms that are alive
            if (!IsAlive) return;

            // Increment size
            if (Name == "Morel")
            {
                for (int i = 0; i < numOfNights; i++)
                {
                    GrowthRate += 0.5F;
                    if (GrowthRate >= 2.5) { GrowthRate = 2.5; }
                    CurrentSize = CurrentSize * GrowthRate;
                }
            }
            else
            {
                CurrentSize += numOfNights * GrowthRate;
            }

            if (CurrentSize > MaxSize)
            {
                CurrentSize = MaxSize;
                IsAlive = false; // Mushroom dies if it grows over its max size
            }

            // Increment weight
            if (CurrentWeight == 0)
            {
                CurrentWeight += 50;
                numOfNights--;
            }

            for (int i = 0; i < numOfNights; i++)
            {
                CurrentWeight = CurrentWeight + (0.1 * CurrentWeight);
            }

            if (CurrentWeight > MaxWeight)
            {
                CurrentWeight = MaxWeight;
            }
        }

        public bool IsReadyToPick()
        {
            bool readyToPick = IsAlive && CurrentSize > 0;

            if (Name == "Morel")
            {
                if (CurrentWeight < 75) { readyToPick = false; }
            }
            if (Name == "Portobello")
            {
                if (CurrentSize < 5) { readyToPick = false; }
            }

            return readyToPick;
        }

        protected Mushroom Reproduce(Mushroom mushroom)
        {
            return mushroom;
        }
    }
}
