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

        private const int Pair = 2;
        private const int ThreePairs = 3;
        private const int SixOfAKind = 6;
        private const int FiveOfAKind = 5;
        private const int FourOfAKind = 4;
        private const int ThreeOfAKind = 3;


        private const int ThreeOfAKindMultiplier = 100;
        private const int ScoreForThreeOnes = 300;
        private const int ScoreForSixOfAKind = 3000;
        private const int ScoreForFiveOfAKind = 2000;
        private const int ScoreForFourOfAKind = 1000;
        private const int ScoreForAStraight = 1500;
        private const int ScoreForThreePairs = 1500;
        private const int ScoreForFourOfAKindAndAPair = 1500;
        private const int ScoreForTwoSetsOfThree = 2500;

        private Func<IDice, bool> diceValueCount;
        private List<int> diceCountByValue = new List<int>();


        public int ScoreRoll(IDice[] dice)
        {

            int score = 0;

            if(IsRollAOneThroughSixStraight(dice))
            {
                score = ScoreForAStraight;
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
                score = CalculateScore(dice);
            }

            if (0 == score)
            {
                score = scoreIndividualDice(dice);
            }

            return score;
        }

        private int CalculateScore(IDice[] dice)
        {
            int score = 0;
            bool foundThreeOfAKind = false;
            bool foundFourOfAKind = false;

            for (int i = MinimumDiceValue; i <= MaximumDiceValue; i++)
            {
                diceValueCount = delegate (IDice diceVal) { return diceVal.Value == i; };
                int count = dice.Count(diceValueCount);
                if (count >= FourOfAKind && count <= SixOfAKind)
                {
                    foundFourOfAKind = true;
                    score += ScoreXofAKind(count);
                }
                else if(ThreeOfAKind == count)
                {
                    if (foundThreeOfAKind)
                    {
                        score = ScoreForTwoSetsOfThree;
                    }
                    else
                    {
                        foundThreeOfAKind = true;
                        score = ScoreThreeOfAKind(i);
                    }
                }
                else if(Pair == count)
                {
                    if(foundFourOfAKind)
                    {
                        score = ScoreForFourOfAKindAndAPair;
                    }
                }

            }

            return score;
        }

        private int ScoreXofAKind(int count)
        {
            int score = 0;
            switch (count)
            {
                case SixOfAKind:
                    score = ScoreForSixOfAKind;
                    break;

                case FiveOfAKind:
                    score = ScoreForFiveOfAKind;
                    break;

                case FourOfAKind:
                    score = ScoreForFourOfAKind;
                    break;
            }

            return score;
        }

        private int ScoreThreeOfAKind(int diceFaceValue)
        {
            int score = 0;

            if(diceFaceValue != 1)
            {
                score = diceFaceValue * ThreeOfAKindMultiplier;
            }
            else
            {
                score = ScoreForThreeOnes;
            }
            
            return score;
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
                        score += 50;
                        break;
                }
            }

            return score;
        }
    }
}
