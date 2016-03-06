using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FarklePractice;
using Moq;

namespace FarklePracticeUnitTests
{
    [TestClass]
    public class RulesEngineUnitTests
    {
        Mock<IDice> dice1 = new Mock<IDice>();
        Mock<IDice> dice2 = new Mock<IDice>();
        Mock<IDice> dice3 = new Mock<IDice>();
        Mock<IDice> dice4 = new Mock<IDice>();
        Mock<IDice> dice5 = new Mock<IDice>();
        Mock<IDice> dice6 = new Mock<IDice>();


        [TestMethod]
        public void RoleIsAOneAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(1);

            Assert.AreEqual((int)PointValues.OneHundred, rules.ScoreRoll(new IDice[] { dice1.Object }));
        }

        [TestMethod]
        public void RoleIsAFiveAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(5);

            Assert.AreEqual((int)PointValues.Fifty, rules.ScoreRoll(new IDice[] { dice1.Object }));
        }

        [TestMethod]
        public void RoleIsThreeOnesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(1);
            dice2.Setup(mock => mock.Value).Returns(1);
            dice3.Setup(mock => mock.Value).Returns(1);

            Assert.AreEqual((int)PointValues.ThreeHundred, rules.ScoreRoll(new IDice[] { dice1.Object, dice2.Object, dice3.Object }));
        }

        [TestMethod]
        public void RoleIsThreeTwosAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(2);
            dice2.Setup(mock => mock.Value).Returns(2);
            dice3.Setup(mock => mock.Value).Returns(2);

            Assert.AreEqual((int)PointValues.TwoHundred, rules.ScoreRoll(new IDice[] { dice1.Object, dice2.Object, dice3.Object }));
        }

        [TestMethod]
        public void RoleIsThreeThreesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(3);
            dice2.Setup(mock => mock.Value).Returns(3);
            dice3.Setup(mock => mock.Value).Returns(3);

            Assert.AreEqual((int)PointValues.ThreeHundred, rules.ScoreRoll(new IDice[] { dice1.Object, dice2.Object, dice3.Object }));
        }

        [TestMethod]
        public void RoleIsThreeFoursAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(4);
            dice2.Setup(mock => mock.Value).Returns(4);
            dice3.Setup(mock => mock.Value).Returns(4);

            Assert.AreEqual((int)PointValues.FourHundred, rules.ScoreRoll(new IDice[] { dice1.Object, dice2.Object, dice3.Object }));
        }

        [TestMethod]
        public void RoleIsThreeFivesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(5);
            dice2.Setup(mock => mock.Value).Returns(5);
            dice3.Setup(mock => mock.Value).Returns(5);

            Assert.AreEqual((int)PointValues.FiveHundred, rules.ScoreRoll(new IDice[] { dice1.Object, dice2.Object, dice3.Object }));
        }

        [TestMethod]
        public void RoleIsThreeSixesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(6);
            dice2.Setup(mock => mock.Value).Returns(6);
            dice3.Setup(mock => mock.Value).Returns(6);

            Assert.AreEqual((int)PointValues.SixHundred, rules.ScoreRoll(new IDice[] { dice1.Object, dice2.Object, dice3.Object }));
        }

        [TestMethod]
        public void RoleIsFourOnesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(1);
            dice2.Setup(mock => mock.Value).Returns(1);
            dice3.Setup(mock => mock.Value).Returns(1);
            dice4.Setup(mock => mock.Value).Returns(1);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object };
            Assert.AreEqual((int)PointValues.OneThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFourTwosAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(2);
            dice2.Setup(mock => mock.Value).Returns(2);
            dice3.Setup(mock => mock.Value).Returns(2);
            dice4.Setup(mock => mock.Value).Returns(2);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object };
            Assert.AreEqual((int)PointValues.OneThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFourThreesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(3);
            dice2.Setup(mock => mock.Value).Returns(3);
            dice3.Setup(mock => mock.Value).Returns(3);
            dice4.Setup(mock => mock.Value).Returns(3);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object };
            Assert.AreEqual((int)PointValues.OneThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFourFoursAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(4);
            dice2.Setup(mock => mock.Value).Returns(4);
            dice3.Setup(mock => mock.Value).Returns(4);
            dice4.Setup(mock => mock.Value).Returns(4);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object };
            Assert.AreEqual((int)PointValues.OneThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFourFivesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(5);
            dice2.Setup(mock => mock.Value).Returns(5);
            dice3.Setup(mock => mock.Value).Returns(5);
            dice4.Setup(mock => mock.Value).Returns(5);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object };
            Assert.AreEqual((int)PointValues.OneThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFourSixesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(6);
            dice2.Setup(mock => mock.Value).Returns(6);
            dice3.Setup(mock => mock.Value).Returns(6);
            dice4.Setup(mock => mock.Value).Returns(6);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object };
            Assert.AreEqual((int)PointValues.OneThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFiveOnesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(1);
            dice2.Setup(mock => mock.Value).Returns(1);
            dice3.Setup(mock => mock.Value).Returns(1);
            dice4.Setup(mock => mock.Value).Returns(1);
            dice5.Setup(mock => mock.Value).Returns(1);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object };
            Assert.AreEqual((int)PointValues.TwoThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFiveTwosAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(2);
            dice2.Setup(mock => mock.Value).Returns(2);
            dice3.Setup(mock => mock.Value).Returns(2);
            dice4.Setup(mock => mock.Value).Returns(2);
            dice5.Setup(mock => mock.Value).Returns(2);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object };
            Assert.AreEqual((int)PointValues.TwoThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFiveThreesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(3);
            dice2.Setup(mock => mock.Value).Returns(3);
            dice3.Setup(mock => mock.Value).Returns(3);
            dice4.Setup(mock => mock.Value).Returns(3);
            dice5.Setup(mock => mock.Value).Returns(3);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object };
            Assert.AreEqual((int)PointValues.TwoThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFiveFoursAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(4);
            dice2.Setup(mock => mock.Value).Returns(4);
            dice3.Setup(mock => mock.Value).Returns(4);
            dice4.Setup(mock => mock.Value).Returns(4);
            dice5.Setup(mock => mock.Value).Returns(4);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object };
            Assert.AreEqual((int)PointValues.TwoThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFiveFivesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(5);
            dice2.Setup(mock => mock.Value).Returns(5);
            dice3.Setup(mock => mock.Value).Returns(5);
            dice4.Setup(mock => mock.Value).Returns(5);
            dice5.Setup(mock => mock.Value).Returns(5);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object };
            Assert.AreEqual((int)PointValues.TwoThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFiveSixesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(6);
            dice2.Setup(mock => mock.Value).Returns(6);
            dice3.Setup(mock => mock.Value).Returns(6);
            dice4.Setup(mock => mock.Value).Returns(6);
            dice5.Setup(mock => mock.Value).Returns(6);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object };
            Assert.AreEqual((int)PointValues.TwoThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsSixOnesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(1);
            dice2.Setup(mock => mock.Value).Returns(1);
            dice3.Setup(mock => mock.Value).Returns(1);
            dice4.Setup(mock => mock.Value).Returns(1);
            dice5.Setup(mock => mock.Value).Returns(1);
            dice6.Setup(mock => mock.Value).Returns(1);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.ThreeThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsSixTwosAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(2);
            dice2.Setup(mock => mock.Value).Returns(2);
            dice3.Setup(mock => mock.Value).Returns(2);
            dice4.Setup(mock => mock.Value).Returns(2);
            dice5.Setup(mock => mock.Value).Returns(2);
            dice6.Setup(mock => mock.Value).Returns(2);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.ThreeThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsSixThreesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(3);
            dice2.Setup(mock => mock.Value).Returns(3);
            dice3.Setup(mock => mock.Value).Returns(3);
            dice4.Setup(mock => mock.Value).Returns(3);
            dice5.Setup(mock => mock.Value).Returns(3);
            dice6.Setup(mock => mock.Value).Returns(3);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.ThreeThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsSixFoursAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(4);
            dice2.Setup(mock => mock.Value).Returns(4);
            dice3.Setup(mock => mock.Value).Returns(4);
            dice4.Setup(mock => mock.Value).Returns(4);
            dice5.Setup(mock => mock.Value).Returns(4);
            dice6.Setup(mock => mock.Value).Returns(4);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.ThreeThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsSixFivesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(5);
            dice2.Setup(mock => mock.Value).Returns(5);
            dice3.Setup(mock => mock.Value).Returns(5);
            dice4.Setup(mock => mock.Value).Returns(5);
            dice5.Setup(mock => mock.Value).Returns(5);
            dice6.Setup(mock => mock.Value).Returns(5);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.ThreeThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsSixSixesAndNoOtherWinningValues()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(6);
            dice2.Setup(mock => mock.Value).Returns(6);
            dice3.Setup(mock => mock.Value).Returns(6);
            dice4.Setup(mock => mock.Value).Returns(6);
            dice5.Setup(mock => mock.Value).Returns(6);
            dice6.Setup(mock => mock.Value).Returns(6);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.ThreeThousand, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsOneThroughSixStraight()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(2);
            dice2.Setup(mock => mock.Value).Returns(1);
            dice3.Setup(mock => mock.Value).Returns(3);
            dice4.Setup(mock => mock.Value).Returns(6);
            dice5.Setup(mock => mock.Value).Returns(4);
            dice6.Setup(mock => mock.Value).Returns(5);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.OneThousandFiveHundred, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsThreePair()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(1);
            dice2.Setup(mock => mock.Value).Returns(1);
            dice3.Setup(mock => mock.Value).Returns(3);
            dice4.Setup(mock => mock.Value).Returns(3);
            dice5.Setup(mock => mock.Value).Returns(5);
            dice6.Setup(mock => mock.Value).Returns(5);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.OneThousandFiveHundred, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsThreePairWithADifferentDataSet()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(2);
            dice2.Setup(mock => mock.Value).Returns(2);
            dice3.Setup(mock => mock.Value).Returns(6);
            dice4.Setup(mock => mock.Value).Returns(3);
            dice5.Setup(mock => mock.Value).Returns(6);
            dice6.Setup(mock => mock.Value).Returns(3);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.OneThousandFiveHundred, rules.ScoreRoll(diceArray));
        }

        [TestMethod]
        public void RoleIsFourOfAKindPlusAPair()
        {
            RulesEngine rules = new RulesEngine();
            dice1.Setup(mock => mock.Value).Returns(2);
            dice2.Setup(mock => mock.Value).Returns(2);
            dice3.Setup(mock => mock.Value).Returns(2);
            dice4.Setup(mock => mock.Value).Returns(2);
            dice5.Setup(mock => mock.Value).Returns(6);
            dice6.Setup(mock => mock.Value).Returns(6);

            IDice[] diceArray = new IDice[] { dice1.Object, dice2.Object, dice3.Object, dice4.Object, dice5.Object, dice6.Object };
            Assert.AreEqual((int)PointValues.OneThousandFiveHundred, rules.ScoreRoll(diceArray));
        }
    }
}
