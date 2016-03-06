using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public interface IDice
    {
        int MinValue { get; }
        int MaxValue { get; }
        int Value { get; }

        /// <summary>
        /// Give the die a random value
        /// </summary>
        void Roll();
    }
}
