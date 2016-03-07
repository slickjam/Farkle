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
        private int currentPlayerIndex;
        private IRulesEngine rulesEngine;
        private const int MinimumActiveScore = 500;

        public Game(Player[] players, IDice[] dice, IRulesEngine engine)
        {
            this.players = players;
            this.GameDice = dice;
            this.rulesEngine = engine;

            if (players.Length > 0)
            {
                CurrentPlayer = players[currentPlayerIndex];
            }
        }

        public Player CurrentPlayer { get; set; }
        public IDice[] GameDice { get; set; }
        public bool IsFinalRound { get; private set; }

        public void TakeTurn()
        {
            //Current player "rolls" the dice
            RollTheDice();

            // Score the roll
            int score = rulesEngine.ScoreRoll(GameDice);
            if (CurrentPlayer.IsActive)
            {
                CurrentPlayer.Score += score;
            }
            else if (score >= MinimumActiveScore && !CurrentPlayer.IsActive)
            {
                CurrentPlayer.IsActive = true;
                CurrentPlayer.Score = score;
            }

            // Move to the next player
            MoveToTheNextPlayer();        
        }

        private void RollTheDice()
        {
            foreach(Dice d in GameDice)
            {
                d.Roll();
            }
        }

        private void MoveToTheNextPlayer()
        {
            currentPlayerIndex++;
            if (players.Length == currentPlayerIndex)
            {
                currentPlayerIndex = 0;
            }
            CurrentPlayer = players[currentPlayerIndex];
        }
    }
}
