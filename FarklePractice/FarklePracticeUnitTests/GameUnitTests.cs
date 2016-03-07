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
        Player playerThree = new Player("john");
        Player playerFour = new Player("jacob");

        Game farkle;
        Mock<IRulesEngine> mockEngine = new Mock<IRulesEngine>();

        public GameUnitTests()
        {
            farkle = new Game(new Player[] { playerOne, playerTwo, playerThree, playerFour }, new Dice[] { }, mockEngine.Object);
        }

        [TestMethod]
        public void GameStart()
        {
            Assert.AreEqual(farkle.CurrentPlayer, playerOne);
        }

        [TestMethod]
        public void PlayerOneBeginsTurnAndDoesNotScore()
        {
            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(0);

            farkle.TakeTurn();

            Assert.AreEqual(playerTwo.Nickname, farkle.CurrentPlayer.Nickname);
        }

        [TestMethod]
        public void PlayerOneBeginsTurnAndScoresOneHundred()
        {
            int returnedScore = 100;
            int expectedScore = 0;
            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(returnedScore);


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

            farkle.TakeTurn();

            Assert.AreEqual(isActive, playerOne.IsActive);
            Assert.AreEqual(expectedScore, playerOne.Score);
            Assert.AreEqual(playerTwo.Nickname, farkle.CurrentPlayer.Nickname);
        }

        [TestMethod]
        public void EachPlayerTakesATurnAndGetsOnTheBoard()
        {
            int expectedScoreActive = 500;
            int expectedScoreInActive = 0;

            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(expectedScoreActive);
            

            farkle.TakeTurn();

            Assert.AreEqual(true, playerOne.IsActive);
            Assert.AreEqual(expectedScoreActive, playerOne.Score);
            Assert.AreEqual(playerTwo.Nickname, farkle.CurrentPlayer.Nickname);
            Assert.AreEqual(false, playerTwo.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerTwo.Score);
            Assert.AreEqual(false, playerThree.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerThree.Score);
            Assert.AreEqual(false, playerFour.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerFour.Score);

            farkle.TakeTurn();

            Assert.AreEqual(true, playerOne.IsActive);
            Assert.AreEqual(expectedScoreActive, playerOne.Score);
            Assert.AreEqual(true, playerTwo.IsActive);
            Assert.AreEqual(expectedScoreActive, playerTwo.Score);
            Assert.AreEqual(playerThree.Nickname, farkle.CurrentPlayer.Nickname);
            Assert.AreEqual(false, playerThree.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerThree.Score);
            Assert.AreEqual(false, playerFour.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerFour.Score);

            farkle.TakeTurn();

            Assert.AreEqual(true, playerOne.IsActive);
            Assert.AreEqual(expectedScoreActive, playerOne.Score);
            Assert.AreEqual(true, playerTwo.IsActive);
            Assert.AreEqual(expectedScoreActive, playerTwo.Score);
            Assert.AreEqual(true, playerThree.IsActive);
            Assert.AreEqual(expectedScoreActive, playerThree.Score);
            Assert.AreEqual(playerFour.Nickname, farkle.CurrentPlayer.Nickname);
            Assert.AreEqual(false, playerFour.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerFour.Score);

            farkle.TakeTurn();

            Assert.AreEqual(true, playerOne.IsActive);
            Assert.AreEqual(expectedScoreActive, playerOne.Score);
            Assert.AreEqual(true, playerTwo.IsActive);
            Assert.AreEqual(expectedScoreActive, playerTwo.Score);
            Assert.AreEqual(true, playerThree.IsActive);
            Assert.AreEqual(expectedScoreActive, playerThree.Score);
            Assert.AreEqual(true, playerFour.IsActive);
            Assert.AreEqual(expectedScoreActive, playerFour.Score);
            Assert.AreEqual(playerOne.Nickname, farkle.CurrentPlayer.Nickname);

        }
    }
}
