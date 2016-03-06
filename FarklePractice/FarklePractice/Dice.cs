using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public class Dice : IDice
    {
        private Random randomNumberGenerator;

        public Dice(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            randomNumberGenerator = new Random();
        }

        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public int Value { get; private set; }

        /// <summary>
        /// Give the die a random value
        /// </summary>
        public void Roll()
        {
           Value = randomNumberGenerator.Next(MinValue, MaxValue + 1);
        }
    }
}
