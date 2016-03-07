using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FarklePractice;

namespace FarklePracticeUnitTests
{
    [TestClass]
    public class PlayerUnitTests
    {
        [TestMethod]
        public void PlayerFirstandLastName()
        {
            Player playerOne = new Player("John", "Doe");
            Assert.AreEqual(playerOne.FirstName, "John");
            Assert.AreEqual(playerOne.LastName, "Doe");
            Assert.IsNull(playerOne.Nickname);
        }

        [TestMethod]
        public void PlayerNickname()
        {
            Player playerOne = new Player("SlickJam");
            Assert.AreEqual(playerOne.Nickname, "SlickJam");
            Assert.IsNull(playerOne.FirstName);
            Assert.IsNull(playerOne.LastName);
        }


        [TestMethod]
        public void PlayerFirstLastandNickname()
        {
            Player playerOne = new Player("John", "Doe","SlickJam");
            Assert.AreEqual(playerOne.FirstName, "John");
            Assert.AreEqual(playerOne.LastName, "Doe");
            Assert.AreEqual(playerOne.Nickname, "SlickJam");
        }

        [TestMethod]
        public void PlayerScore()
        {
            Player playerOne = new Player("SlickJam");
            playerOne.Score = 3;
            Assert.AreEqual(playerOne.Score, 3);
        }

        [TestMethod]
        public void PlayerIsActive()
        {
            bool isActive = true;
            Player playerOne = new Player("SlickJam");
            playerOne.IsActive = true;

            Assert.AreEqual(isActive, playerOne.IsActive);
        }

    }
}
