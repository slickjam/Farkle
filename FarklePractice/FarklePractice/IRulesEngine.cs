using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public interface IRulesEngine
    {
        int ScoreRoll(IDice[] dice);
    }
}
