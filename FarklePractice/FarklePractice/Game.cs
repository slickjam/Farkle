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
        private IUserInteraction userInteraction;
        private int numberOfDiceInPlay;
        private const int MinimumGameEndingScore = 10000;
        private const int MinimumActiveScore = 500;

        public Game(Player[] players, IDice[] dice, IRulesEngine engine, IUserInteraction uiObject)
        {
            this.players = players;
            this.GameDice = dice;
            this.rulesEngine = engine;
            this.userInteraction = uiObject;
            numberOfDiceInPlay = GameDice.Count();

            if (players.Length > 0)
            {
                CurrentPlayer = players[currentPlayerIndex];
            }
        }

        public Player CurrentPlayer { get; set; }
        public IDice[] GameDice { get; set; }
        public bool IsFinalRound { get; private set; }
        public bool IsGameOver { get; private set; }

        public void TakeTurn()
        {
            bool playerRolledAgain = false;
            // Current player "rolls" the dice
            RollTheDice();

            // Prompt the player to select the dice to keep
            IDice[] selectedDice = userInteraction.SelectDiceToKeep(GameDice, "Which dice would you like to keep?");

            // Score the roll
            int score = rulesEngine.ScoreRoll(selectedDice);
            if (CurrentPlayer.IsActive && 0 != score)
            {
                CurrentPlayer.Score += score;
                playerRolledAgain = PromptPlayerToRollAgain(selectedDice);

            }
            else if (score >= MinimumActiveScore && !CurrentPlayer.IsActive)
            {
                CurrentPlayer.IsActive = true;
                CurrentPlayer.Score = score;
                playerRolledAgain = PromptPlayerToRollAgain(selectedDice);
            }

            if (playerRolledAgain)
            {
                // Has a player reached a minimum ending score
                CheckIfFinalRoundShouldStart();

                // Check if the game should be marked as over
                CheckIfGameIsOver();

                // Move to the next player
                MoveToTheNextPlayer();
            }    
        }

        private void RollTheDice()
        {
            for (int i = 0; i < numberOfDiceInPlay; i++)
            {
                GameDice[i].Roll();
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

            // reset the number of dice in play
            numberOfDiceInPlay = GameDice.Count();
        }

        private void CheckIfFinalRoundShouldStart()
        {
            if (CurrentPlayer.Score >= MinimumGameEndingScore && !IsFinalRound)
            {
                IsFinalRound = true;
            }
        }

        private void CheckIfGameIsOver()
        {
            if (IsFinalRound)
            {
                CurrentPlayer.IsActive = false;
                AreAllPlayersInactive();
            }
        }

        private void AreAllPlayersInactive()
        {
            var numberOfInActivePlayers = from Player p in players
                        where p.IsActive == false
                        select p;

            if(numberOfInActivePlayers.Count() == players.Count())
            {
                IsGameOver = true;
            }
        }

        private bool PromptPlayerToRollAgain(IDice[] selectedDice)
        {
            bool rollAgain = false;
            // Prompt user to roll again, if they want
            if (userInteraction.RollAgain("Do you want to roll again?"))
            {
                numberOfDiceInPlay = GameDice.Count() - selectedDice.Count();
                if (0 == numberOfDiceInPlay)
                {
                    // We used all the dice the last turn and still scored so we now have them all to use again
                    numberOfDiceInPlay = GameDice.Count();
                }

                TakeTurn();
                rollAgain = true;
            }

            return rollAgain;
        }
    }
}
