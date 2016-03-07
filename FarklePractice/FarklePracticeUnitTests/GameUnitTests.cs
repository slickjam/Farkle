using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FarklePractice;
using Moq;

namespace FarklePracticeUnitTests
{
    [TestClass]
    public class GameUnitTests
    {
        Player playerOne = new Player("jim");
        Player playerTwo = new Player("bob");
        Mock<IRulesEngine> mockEngine = new Mock<IRulesEngine>();

        [TestMethod]
        public void GameStart()
        {
            IGame farkle = new Game(new Player[] { playerOne, playerTwo }, new Dice[] { }, new RulesEngine());

            Assert.AreEqual(farkle.CurrentPlayer, playerOne);
        }

        [TestMethod]
        public void GameStartWithNoPlayers()
        {
            Game farkle = new Game(new Player[] { },new Dice[] { }, new RulesEngine());

            Assert.IsNull(farkle.CurrentPlayer);
        }

        [TestMethod]
        public void PlayerOneBeginsTurnAndDoesNotScore()
        {
            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(0);
            Game farkle = new Game(new Player[] { playerOne, playerTwo }, new Dice[] { }, mockEngine.Object);
            farkle.TakeTurn();

            Assert.AreEqual(playerTwo.Nickname, farkle.CurrentPlayer.Nickname);
        }

        [TestMethod]
        public void PlayerOneBeginsTurnAndScoresOneHundred()
        {
            int returnedScore = 100;
            int expectedScore = 0;
            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(returnedScore);
            Game farkle = new Game(new Player[] { playerOne, playerTwo }, new Dice[] { }, mockEngine.Object);
            farkle.TakeTurn();

            Assert.AreEqual(expectedScore, playerOne.Score);
            Assert.IsFalse(playerOne.IsActive);
            Assert.AreEqual(playerTwo.Nickname, farkle.CurrentPlayer.Nickname);
        }

        [TestMethod]
        public void CurrentPlayerHasReachFiveHundredPointsAndIsNowActive()
        {
            int expectedScore = 500;
            bool isActive = true;

            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(expectedScore);
            Game farkle = new Game(new Player[] { playerOne, playerTwo }, new Dice[] { }, mockEngine.Object);
            farkle.TakeTurn();

            Assert.AreEqual(isActive, playerOne.IsActive);
            Assert.AreEqual(expectedScore, playerOne.Score);
            Assert.AreEqual(playerTwo.Nickname, farkle.CurrentPlayer.Nickname);
        }
    }
}
