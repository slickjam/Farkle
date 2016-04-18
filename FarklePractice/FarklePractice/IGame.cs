using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public interface IGame
    {
        Player CurrentPlayer { get; set; }
        IDice[] GameDice { get; set; }
        bool IsFinalRound { get; }
        bool IsGameOver { get; }

        void TakeTurn();
        
    }
}
