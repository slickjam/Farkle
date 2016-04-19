using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public class FakeDice : IDice
    {

        public FakeDice(int value)
        {
            Value = value;
        }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Value { get; set; }

        /// <summary>
        /// Give the die a random value
        /// </summary>
        public void Roll()
        {
            Value = 3;
        }
        
    }
}
