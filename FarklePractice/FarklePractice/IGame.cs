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
        Dice[] GameDice { get; set; }

        void TakeTurn();
        
    }
}
