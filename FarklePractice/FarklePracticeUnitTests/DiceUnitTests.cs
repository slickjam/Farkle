using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FarklePractice;

namespace FarklePracticeUnitTests
{
    [TestClass]
    public class DiceUnitTests
    {
        [TestMethod]
        public void DiceMinandMaxValue()
        {
            Dice myDice = new Dice(1,6);
            Assert.AreEqual(myDice.MinValue, 1);
            Assert.AreEqual(myDice.MaxValue, 6);
        }

        [TestMethod]
        public void DiceDefaultValue()
        {
            Dice myDice = new Dice(1, 6);
            Assert.AreEqual(myDice.Value, 0);
        }

        [TestMethod]
        public void DiceRoll()
        {
            Dice myDice = new Dice(1, 6);
            myDice.Roll();
            Assert.AreNotEqual(myDice.Value, 0);
        }
    }
}
