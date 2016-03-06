using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FarklePractice;

namespace FarklePracticeUnitTests
{
    [TestClass]
    public class GameUnitTests
    {
        Player playerOne = new Player("jim");
        Player playerTwo = new Player("bob");

        [TestMethod]
        public void GameObjectsAreCreatedAndValid()
        {
            // Dice
            Dice[] farkleDice = new Dice[] { new Dice(1,6), new Dice(1, 6), new Dice(1, 6),
                                             new Dice(1, 6), new Dice(1, 6), new Dice(1, 6) };

            //Players
            Game farkle = new Game(new Player[] { playerOne, playerTwo }, farkleDice);

            //Rules


            Assert.AreEqual(farkle.CurrentPlayer, playerOne);
            Assert.AreEqual(farkle.GameDice.Length, 6);
        }

        [TestMethod]
        public void GameStart()
        {
            Game farkle = new Game(new Player[] { playerOne, playerTwo }, new Dice[] { });

            Assert.AreEqual(farkle.CurrentPlayer, playerOne);
        }

        [TestMethod]
        public void GameStartWithNoPlayers()
        {
            Game farkle = new Game(new Player[] { },new Dice[] { });

            Assert.IsNull(farkle.CurrentPlayer);
        }

       /* [TestMethod]
        public void PlayerOneBeginTurnAndDoesNotScore()
        {
            Game farkle = new Game(new Player[] { playerOne, playerTwo }, new Dice[] { });
            farkle.TakeTurn();

            Assert.AreEqual(farkle.CurrentPlayer, playerTwo);
        }*/
    }
}
