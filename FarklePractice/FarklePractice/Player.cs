using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public class Player
    {
        public Player(string nickname)
        {
            Nickname = nickname;
        }

        public Player(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Player(string firstName, string lastName, string nickname):this (firstName,lastName)
        {
            Nickname = nickname;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Nickname { get; private set; }
        public int Score { get; set; }
        public bool IsActive { get; set; }
        public List<Dice> RolledDice { get; set; }
    }
}
