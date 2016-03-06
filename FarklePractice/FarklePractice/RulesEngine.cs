using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarklePractice
{
    public enum PointValues { OneHundred = 100, Fifty = 50, TwoHundred = 200, ThreeHundred = 300,
                              FourHundred = 400, FiveHundred = 500, SixHundred = 600, OneThousand = 1000,
                              OneThousandFiveHundred = 1500, TwoThousand = 2000, TwoThousandFiveHundred = 2500, ThreeThousand = 3000};

    public class RulesEngine : IRulesEngine
    {
        private const int MinimumDiceValue = 1;
        private const int MaximumDiceValue = 6;
        private const int MaxNumberOfDice = 6;
        private const int ThreePairs = 3;
        private const int ScoreForSixOfAKind = 3000;
        private const int ScoreForFiveOfAKind = 2000;
        private const int ScoreForFourOfAKind = 1000;
        private const int ScoreForAStraight = 1500;
        private const int ScoreForThreePairs = 1500;
        private const int ScoreForFourOfAKindAndAPair = 1500;
        private const int ScoreForTwoSetsOfThree = 2500;

        private Func<IDice, bool> diceValueCount;


        public int ScoreRoll(IDice[] dice)
        {

            int score = 0;

            if(IsRollAOneThroughSixStraight(dice))
            {
                score = ScoreForAStraight;
            }

            if(0 == score)
            {
                if(IsTwoSetsOfThreeOfAKind(dice))
                {
                    score = ScoreForTwoSetsOfThree;
                }
            }

            if(0 == score)
            {
                if(IsFourOfAKindAndAPair(dice))
                {
                    score = ScoreForFourOfAKindAndAPair;
                }
            }

            if(0 == score)
            {
                if(IsThreePairs(dice))
                {
                    score = ScoreForThreePairs;
                }
            }

            if (0 == score)
            {
                if (IsXNumberOfAKind(dice, 6))
                {
                    score = ScoreForSixOfAKind;
                }
            }

            if(0 == score)
            {
                if (IsXNumberOfAKind(dice, 5))
                {
                    score = ScoreForFiveOfAKind;
                }
            }

            if(0 == score)
            {
                if (IsXNumberOfAKind(dice, 4))
                {
                    score = ScoreForFourOfAKind;
                }
            }

            if (0 == score)
            {
                score = ScoreIfThreeOfAKind(dice);
            }

            if (0 == score)
            {
                score = scoreIndividualDice(dice);
            }

            return score;
        }

        private bool IsTwoSetsOfThreeOfAKind(IDice[] dice)
        {
            bool result = false;
            int setsOfThree = 0;

            for (int i = MinimumDiceValue; i <= MaximumDiceValue; i++)
            {
                diceValueCount = delegate (IDice diceVal) { return diceVal.Value == i; };
                if (dice.Count(diceValueCount) == 3)
                {
                    setsOfThree++;
                }

                if (2 == setsOfThree)
                {
                    result = true;
                }
            }


            return result;
        }

        private bool IsFourOfAKindAndAPair(IDice[] dice)
        {
            bool result = false;
            bool foundFourOfAKind = false;
            bool foundTwoOfAKind = false;

            for (int i = MinimumDiceValue; i <= MaximumDiceValue; i++)
            {
                diceValueCount = delegate (IDice diceVal) { return diceVal.Value == i; };
                if (dice.Count(diceValueCount) == 4)
                {
                    foundFourOfAKind = true;
                }

                if (dice.Count(diceValueCount) == 2)
                {
                    foundTwoOfAKind = true;
                }

                if(foundTwoOfAKind && foundFourOfAKind)
                {
                    result = true;
                }
            }
            return result;
        }

        private bool IsRollAOneThroughSixStraight(IDice[] dice)
        {
            bool result = true;
            List<int> diceValues = new List<int>();

            if (dice.Length == MaxNumberOfDice)
            {
                foreach (IDice d in dice)
                {
                    diceValues.Add(d.Value);
                }

                diceValues.Sort();

                for (int i = 0; i < MaximumDiceValue; i++)
                {
                    if (diceValues[i] != i + 1)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        private bool IsThreePairs(IDice[] dice)
        {
            bool result = false;
            int count = 0;
            

            for (int i = MinimumDiceValue; i <= MaximumDiceValue; i++)
            {
                diceValueCount = delegate (IDice diceVal) { return diceVal.Value == i; };
                if (dice.Count(diceValueCount) == 2)
                {
                    count++;
                }
            }

            if(ThreePairs == count)
            {
                result = true;
            }


            return result;
        }


        private bool IsXNumberOfAKind(IDice[] dice, int countOfAKind)
        {
            bool result = false;
            for (int i = MinimumDiceValue; i <= MaximumDiceValue; i++)
            {
                diceValueCount = delegate (IDice diceVal) { return diceVal.Value == i; };
                if (dice.Count(diceValueCount) == countOfAKind)
                {
                    result = true;
                }
            }
            return result;
        }

        private int ScoreIfThreeOfAKind(IDice[] dice)
        {
            int score = 0;
            // Start at 2 because 1 is a special case and shouldn't be handled in this function
            for (int i = MinimumDiceValue + 1; i <= MaximumDiceValue; i++)
            {
                diceValueCount = delegate (IDice diceVal) { return diceVal.Value == i; };
                if (dice.Count(diceValueCount) == 3)
                {
                    score = i * 100;
                }
            }
            return score;
        }

        private int scoreIndividualDice(IDice[] dice)
        {
            int score = 0;
            foreach (IDice d in dice)
            {
                switch (d.Value)
                {
                    case 1:
                        score += 100;
                        break;
                    case 2:

                    case 5:
                        score = 50;
                        break;
                }
            }

            return score;
        }
    }
}
