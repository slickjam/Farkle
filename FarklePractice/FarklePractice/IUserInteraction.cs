using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public interface IUserInteraction
    {
        IDice[] SelectDiceToKeep(IDice[] rolledDice, string messageToUser);
        bool RollAgain(string message);
    }
}
