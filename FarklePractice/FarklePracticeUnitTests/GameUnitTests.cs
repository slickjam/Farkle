using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FarklePractice;
using Moq;
using System.Collections.Generic;

namespace FarklePracticeUnitTests
{
    [TestClass]
    public class GameUnitTests
    {
        Player playerOne = new Player("jim");
        Player playerTwo = new Player("bob");
        Player playerThree = new Player("john");
        Player playerFour = new Player("jacob");

        Game farkleWithMockInterfaces;
        Game farkleWithRealRulesEngine;
        IRulesEngine rulesEngine = new RulesEngine();
        Mock<IRulesEngine> mockEngine = new Mock<IRulesEngine>();
        Mock<IUserInteraction> mockUserInteraction = new Mock<IUserInteraction>();

        public GameUnitTests()
        {
            farkleWithMockInterfaces = new Game(new Player[] { playerOne, playerTwo, playerThree, playerFour },
                                       new IDice[] { new FakeDice(1), new FakeDice(2), new FakeDice(3),
                                       new FakeDice(4), new FakeDice(5), new FakeDice(6) },
                                       mockEngine.Object, mockUserInteraction.Object);

            farkleWithRealRulesEngine = new Game(new Player[] { playerOne, playerTwo, playerThree, playerFour },
                                        new IDice[] { new FakeDice(1), new FakeDice(2), new FakeDice(3),
                                        new FakeDice(4), new FakeDice(5), new FakeDice(6) },
                                        rulesEngine, mockUserInteraction.Object);

        }

        [TestMethod]
        public void GameStart()
        {
            Assert.AreEqual(farkleWithMockInterfaces.CurrentPlayer, playerOne);
        }

        [TestMethod]
        public void PlayerOneBeginsTurnAndDoesNotScore()
        {
            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(0);

            farkleWithMockInterfaces.TakeTurn();

            Assert.AreEqual(playerTwo.Nickname, farkleWithMockInterfaces.CurrentPlayer.Nickname);
        }

        [TestMethod]
        public void PlayerOneBeginsTurnAndScoresOneHundred()
        {
            int returnedScore = 100;
            int expectedScore = 0;
            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(returnedScore);


            farkleWithMockInterfaces.TakeTurn();

            Assert.AreEqual(expectedScore, playerOne.Score);
            Assert.IsFalse(playerOne.IsActive);
            Assert.AreEqual(playerTwo.Nickname, farkleWithMockInterfaces.CurrentPlayer.Nickname);
        }

        [TestMethod]
        public void CurrentPlayerHasReachFiveHundredPointsAndIsNowActive()
        {
            int expectedScore = 500;
            bool isActive = true;
            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(expectedScore);

            farkleWithMockInterfaces.TakeTurn();

            Assert.AreEqual(isActive, playerOne.IsActive);
            Assert.AreEqual(expectedScore, playerOne.Score);
            Assert.AreEqual(playerTwo.Nickname, farkleWithMockInterfaces.CurrentPlayer.Nickname);
        }

        [TestMethod]
        public void EachPlayerTakesATurnAndGetsOnTheBoard()
        {
            int expectedScoreActive = 500;
            int expectedScoreInActive = 0;

            mockEngine.Setup(mock => mock.ScoreRoll(new Dice[] { })).Returns(expectedScoreActive);


            farkleWithMockInterfaces.TakeTurn();

            Assert.AreEqual(true, playerOne.IsActive);
            Assert.AreEqual(expectedScoreActive, playerOne.Score);
            Assert.AreEqual(playerTwo.Nickname, farkleWithMockInterfaces.CurrentPlayer.Nickname);
            Assert.AreEqual(false, playerTwo.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerTwo.Score);
            Assert.AreEqual(false, playerThree.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerThree.Score);
            Assert.AreEqual(false, playerFour.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerFour.Score);

            farkleWithMockInterfaces.TakeTurn();

            Assert.AreEqual(true, playerOne.IsActive);
            Assert.AreEqual(expectedScoreActive, playerOne.Score);
            Assert.AreEqual(true, playerTwo.IsActive);
            Assert.AreEqual(expectedScoreActive, playerTwo.Score);
            Assert.AreEqual(playerThree.Nickname, farkleWithMockInterfaces.CurrentPlayer.Nickname);
            Assert.AreEqual(false, playerThree.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerThree.Score);
            Assert.AreEqual(false, playerFour.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerFour.Score);

            farkleWithMockInterfaces.TakeTurn();

            Assert.AreEqual(true, playerOne.IsActive);
            Assert.AreEqual(expectedScoreActive, playerOne.Score);
            Assert.AreEqual(true, playerTwo.IsActive);
            Assert.AreEqual(expectedScoreActive, playerTwo.Score);
            Assert.AreEqual(true, playerThree.IsActive);
            Assert.AreEqual(expectedScoreActive, playerThree.Score);
            Assert.AreEqual(playerFour.Nickname, farkleWithMockInterfaces.CurrentPlayer.Nickname);
            Assert.AreEqual(false, playerFour.IsActive);
            Assert.AreEqual(expectedScoreInActive, playerFour.Score);

            farkleWithMockInterfaces.TakeTurn();

            Assert.AreEqual(true, playerOne.IsActive);
            Assert.AreEqual(expectedScoreActive, playerOne.Score);
            Assert.AreEqual(true, playerTwo.IsActive);
            Assert.AreEqual(expectedScoreActive, playerTwo.Score);
            Assert.AreEqual(true, playerThree.IsActive);
            Assert.AreEqual(expectedScoreActive, playerThree.Score);
            Assert.AreEqual(true, playerFour.IsActive);
            Assert.AreEqual(expectedScoreActive, playerFour.Score);
            Assert.AreEqual(playerOne.Nickname, farkleWithMockInterfaces.CurrentPlayer.Nickname);

        }

        [TestMethod]
        public void IsFinalRoundIsFalse()
        {
            playerOne.Score = 9999;
            farkleWithMockInterfaces.CurrentPlayer = playerOne;
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsFalse(farkleWithMockInterfaces.IsFinalRound);
        }

        [TestMethod]
        public void IsFinalRoundIsTrue()
        {
            playerOne.Score = 10000;
            farkleWithMockInterfaces.CurrentPlayer = playerOne;
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsTrue(farkleWithMockInterfaces.IsFinalRound);
        }

        [TestMethod]
        public void IsFinalRoundIsTrueOverMinimumScore()
        {
            playerOne.Score = 10001;
            farkleWithMockInterfaces.CurrentPlayer = playerOne;
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsTrue(farkleWithMockInterfaces.IsFinalRound);
        }

        [TestMethod]
        public void GameIsNotOver()
        {
            playerOne.Score = 9000;
            farkleWithMockInterfaces.CurrentPlayer = playerOne;
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsFalse(farkleWithMockInterfaces.IsGameOver);
        }

        [TestMethod]
        public void GameIsNotOverStillHaveActivePlayers()
        {
            playerOne.Score = 10000;
            farkleWithMockInterfaces.CurrentPlayer = playerOne;
            playerTwo.IsActive = true;
            playerThree.IsActive = true;
            playerFour.IsActive = true;

            // Player one takes a turn and sets the final round to true by getting 10,000 points
            // Player one is marked as inactive after the turn is over
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsFalse(farkleWithMockInterfaces.IsGameOver);

            // Player two takes a turn and since the final round  has started is marked as inactive after the turn is over
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsFalse(farkleWithMockInterfaces.IsGameOver);

            // Player three takes a turn and since the final round has started is marged as inacive after the turn is over
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsFalse(farkleWithMockInterfaces.IsGameOver);

            // Player four takes a turn, since the final round has started and player four is the last player the game ends once
            // Player for is done with the turn
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsTrue(farkleWithMockInterfaces.IsGameOver);

        }

        [TestMethod]
        public void GameIsOver()
        {
            playerOne.Score = 10001;
            farkleWithMockInterfaces.CurrentPlayer = playerOne;
            farkleWithMockInterfaces.TakeTurn();
            Assert.IsTrue(farkleWithMockInterfaces.IsGameOver);
        }

        [TestMethod]
        public void CurrentPlayerUsesAllDiceAndRollsAgain()
        {
            int expectedScore = 1000;
            bool isActive = true;
            FakeDice[] fakes = new FakeDice[] { new FakeDice(5), new FakeDice(5), new FakeDice(5) };
            Queue<bool> rollAgain = new Queue<bool>();
            rollAgain.Enqueue(true);
            rollAgain.Enqueue(false);

            mockUserInteraction.Setup(mock => mock.SelectDiceToKeep(It.IsAny<IDice[]>(),
                                      It.IsAny<string>())).Returns(fakes);
            mockUserInteraction.Setup(mock => mock.RollAgain(It.IsAny<string>())).Returns(rollAgain.Dequeue);

            farkleWithRealRulesEngine.TakeTurn();

            //what happens when we roll three times in a row??

            Assert.AreEqual(isActive, playerOne.IsActive);
            Assert.AreEqual(expectedScore, playerOne.Score);
            Assert.AreEqual(playerTwo.Nickname, farkleWithRealRulesEngine.CurrentPlayer.Nickname);
        }
    }
}
