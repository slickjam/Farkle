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

        private const int Single = 1;
        private const int Pair = 2;
        private const int TwoSetsOfThreeOfAKind = 2;
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

            if (0 == score)
            {
                score = CalculateScore(dice);
            }

            return score;
        }

        private int CalculateScore(IDice[] dice)
        {
            int score = 0;
            int pairCounter = 0;
            int threeOfAKindCounter = 0;
            bool foundFourOfAKind = false;

            for (int diceFaceValue = MinimumDiceValue; diceFaceValue <= MaximumDiceValue; diceFaceValue++)
            {
                diceValueCount = delegate (IDice diceVal) { return diceVal.Value == diceFaceValue; };
                int count = dice.Count(diceValueCount);
                if (FiveOfAKind == count || SixOfAKind == count)
                {
                    score = ScoreXofAKind(count);
                }
                else if (FourOfAKind == count)
                {
                    foundFourOfAKind = true;
                    score = ScoreXofAKind(count);
                    if (pairCounter == Single)
                    {
                        score = ScoreThreePairsOrFourOfAKindAndAPair(foundFourOfAKind);
                    }
                }
                else if (ThreeOfAKind == count)
                {
                    threeOfAKindCounter++;
                    if (threeOfAKindCounter == TwoSetsOfThreeOfAKind)
                    {
                        score = ScoreThreeOfAKindOrTwoSetsOfThree(diceFaceValue, threeOfAKindCounter);
                    }
                    else
                    {
                        score += ScoreThreeOfAKindOrTwoSetsOfThree(diceFaceValue, threeOfAKindCounter);
                    }

                }
                else if (Pair == count)
                {
                    pairCounter++;
                    if (pairCounter == ThreePairs  || foundFourOfAKind)
                    {
                        score = ScoreThreePairsOrFourOfAKindAndAPair(foundFourOfAKind);
                    }
                    else if (diceFaceValue == 1 || diceFaceValue == 5)
                    {
                        score += ScoreOnesAndFives(diceFaceValue) * Pair;
                    }
                }
                else if(Single == count)
                {
                    score += ScoreOnesAndFives(diceFaceValue);
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

        private int ScoreThreePairsOrFourOfAKindAndAPair(bool foundFourOfAKind)
        {
            int score = 0;

            if (foundFourOfAKind)
            {
                score = ScoreForFourOfAKindAndAPair;
            }
            else
            {
                score = ScoreForThreePairs;
            }

            return score;
        }

        private int ScoreThreeOfAKindOrTwoSetsOfThree(int diceFaceValue, int threeOfAKindCounter)
        {
            int score = 0;

            if (threeOfAKindCounter == TwoSetsOfThreeOfAKind)
            {
                score = ScoreForTwoSetsOfThree;
            }
            else
            {
                score = ScoreThreeOfAKind(diceFaceValue);
            }

            return score;
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

        private int ScoreOnesAndFives(int diceFaceValue)
        {
            int score = 0;

            switch (diceFaceValue)
            {
                case 1:
                    score = 100;
                    break;
                case 2:

                case 5:
                    score = 50;
                    break;
            }


            return score;
        }
    }
}
