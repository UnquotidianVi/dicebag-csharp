namespace Dicebag {

    /// <summary>set of probability functions designed specifically for games</summary>
    public static class Dicebag
    {
        /// <summary>random gen used for rolls. Set a seed with: <code>Dicebag.R = new System.Random(seed);</code></summary>
        public static System.Random R = new System.Random();

#region Flip_Coin
        /// <summary>50% chance of returning true or false</summary>
        public static bool FlipCoin()
        {
            return R.Next(0, 2) == 1;
        }
#endregion

#region Roll_Dice
        /// <summary>6-sided dice roll. Returns roll value</summary>
        public static int RollDice()
        {
            return RollDice(1);
        }

        /// <summary>6-sided dice roll, rolls number of dice given. Returns resulting roll value</summary>
        public static int RollDice(int _numOfDice)
        {
            return RollDice(_numOfDice, 6);
        }

        /// <summary>custom-sided dice roll, for example 3d6. Returns resulting roll value.</summary>
        public static int RollDice(int _numOfDice, int _numOfSides)
        {
            return RollDice(_numOfDice, _numOfSides, 0);
        }

        /// <summary>D&D-style dice roll, for example 3d6+2. Returns resulting roll value.</summary>
        public static int RollDice(int _numOfDice, int _numOfSides, int _modifier)
        {
            int result = _modifier;
            for(int i = 0; i < _numOfDice; i++)
                result += R.Next(1, _numOfSides + 1);
            return result;
        }
#endregion

#region RollSpecialDice
        /// <summary>Roll two 6-sided dice with advantage. 
        /// Returns the highest roll from the two dice.</summary>
        public static int RollSpecialDice()
        {
            return RollSpecialDice(2, 1);
        }

        /// <summary>Roll one or more 6-sided dice with advantage. 
        /// Returns the _numOfResults sum of the highest value of all rolls.</summary>
        public static int RollSpecialDice(int _numOfDice, int _numOfResults)
        {
            return RollSpecialDice(_numOfResults, _numOfDice, true);
        }    

        /// <summary>Roll one or more 6-sided dice with advantage or disadvantage (if advantage is not true rolls are disadvantaged). 
        /// Returns the _numOfResults sum of the highest (advantage) or lowest (disadvantage) value of all rolls.</summary>
        public static int RollSpecialDice(int _numOfDice, int _numOfResults, bool _advantage)
        {
            return RollSpecialDice(_numOfDice, _numOfResults, _advantage, 6);
        }        

        /// <summary>Roll one or more dice with advantage or disadvantage (if advantage is not true rolls are disadvantaged). 
        /// Returns the _numOfResults sum of the highest (advantage) or lowest (disadvantage) value of all rolls.</summary>
        public static int RollSpecialDice(int _numOfDice, int _numOfResults,  bool _advantage,int _numOfSides)
        {
            int[] rolls = new int[_numOfResults];

            for(int diceIndex = 0; diceIndex < _numOfDice; diceIndex++)
            {
                int roll = RollDice(1, _numOfSides);

                if(diceIndex < _numOfResults)
                {
                    rolls[diceIndex] = roll;
                }
                else
                {
                    int rolldIndexToReplaceAt = -1;

                    if(_advantage)
                    {
                        int lowestRollInRolls = _numOfSides + 1;
                        for(int rollIndex = 0; rollIndex < rolls.Length; rollIndex++)
                        {
                            if(rolls[rollIndex] < lowestRollInRolls && rolls[rollIndex] < roll)
                            {
                                lowestRollInRolls = rolls[rollIndex];
                                rolldIndexToReplaceAt = rollIndex;
                            }
                        }
                    }
                    else
                    {
                        int highestRollInRolls = 0;
                        for(int rollIndex = 0; rollIndex < rolls.Length; rollIndex++)
                        {
                            if(rolls[rollIndex] > highestRollInRolls && rolls[rollIndex] > roll)
                            {
                                highestRollInRolls = rolls[rollIndex];
                                rolldIndexToReplaceAt = rollIndex;
                            }
                        }
                    }

                    if(rolldIndexToReplaceAt != -1)
                        rolls[rolldIndexToReplaceAt] = roll;
                }
            }

            int result = 0;
            for(int i = 0; i < rolls.Length; i++)
                result += rolls[i];
            return result;
        }
#endregion

#region RollCustomDice
        /// <summary>Roll one or more CustomDice. Returns the total value of the rolled Dice</summary>
        public static int RollCustomDice(Die.CustomDie _customDice, int _numOfDice)
        {
            int result = 0;
            for(int i = 0; i < _numOfDice; i++)
                result += RollCustomDice(_customDice);
            return result;
        }

        /// <summary>Roll a custom Die. Returns the value of the rolled side</summary>
        public static int RollCustomDice(Die.CustomDie _customDie)
        {
            float totalWeight = 0;
            for(int i = 0; i < _customDie.Sides.Length; i++)
                totalWeight += _customDie.Sides[i].W;

            float weightResult = (float)R.Next(0, 100) / 100 * totalWeight;

            float processedWeight = 0;
            for(int i = 0; i < _customDie.Sides.Length; i++)
            {
                processedWeight += _customDie.Sides[i].W;
                if(weightResult <= processedWeight)
                    return _customDie.Sides[i].V;
            }
            return 0;
        }
#endregion
    }
}