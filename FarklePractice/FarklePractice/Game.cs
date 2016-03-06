using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public class Game :IGame
    {
        private Player[] players;
        public Game(Player[] players, Dice[] dice)
        {
            this.players = players;
            this.GameDice = dice;
            if (players.Length > 0)
            {
                CurrentPlayer = players[0];
            }
        }

        public Player CurrentPlayer { get; set; }
        public Dice[] GameDice { get; set; }

        public void TakeTurn()
        {
            //Current player "rolls" the dice
            RollTheDice();

        }

        private void RollTheDice()
        {
            foreach(Dice d in GameDice)
            {
                d.Roll();
            }
        }
    }
}
