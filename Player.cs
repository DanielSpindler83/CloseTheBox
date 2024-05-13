namespace CloseTheBox
{
    internal class Player
    {
        private CountingBox countingBox = new();
        private Dice dice1 = new();
        private Dice dice2 = new();
        private bool playerCanTakeAnotherTurn;

        public bool DisplayFullGameInfoToConsole { get; set; } = true; 

        public bool PlayerCanTakeAnotherTurn()
        {
            // we get a rollResult - tuple of two ints representing the Die rolls
            // we need to do the main app logic to update the countingbox as needed

            // first we add the die numbers together and check if that integer is true
            // If true then we make it false and set another turn flag to true
            // else we evaluate each die seperatley (order doesnt matter)
            // If countingbox item Die1 result is true then set it to false and set another turn flag to true
            // if countingbox item Die2 reslult is true then set it to false and set another turn flag to true
            // return anotherturn flag (bool)

            playerCanTakeAnotherTurn = false;

            var rollResult = RollTheDie();

            int rollAddition = rollResult.Item1 + rollResult.Item2;
            if(countingBox.CheckValue(rollAddition))
            {
                countingBox.CloseNumber(rollAddition);
                playerCanTakeAnotherTurn = true;
            }else
            {
                if (countingBox.CheckValue(rollResult.Item1))
                {
                    countingBox.CloseNumber(rollResult.Item1);
                    playerCanTakeAnotherTurn = true;
                }
                if (countingBox.CheckValue(rollResult.Item2))
                {
                    countingBox.CloseNumber(rollResult.Item2);
                    playerCanTakeAnotherTurn = true;
                }
            }

            if (DisplayFullGameInfoToConsole)
            {
                Console.WriteLine($"Dice roll = {rollResult.Item1} and {rollResult.Item2}");
                countingBox.DisplayCountingBox();
            }

            return playerCanTakeAnotherTurn;
        }

        public (int, int) RollTheDie()
        {
            var diceRoll1 = dice1.RollTheDice();
            var diceRoll2 = dice2.RollTheDice();
            return (diceRoll1, diceRoll2);
        }

        public void PlayAGame()
        {
            while (PlayerCanTakeAnotherTurn()) ;
        }

        public int GetFinalCount()
        {
            var finalCount = countingBox.GetCount();

            if (DisplayFullGameInfoToConsole)
            {
                Console.WriteLine($"Final count = {finalCount}");
                Console.WriteLine("######## End of Game ########");
                Console.WriteLine(" ");
            }
            return finalCount;
        }

        public void ResetPlayer()
        {
            countingBox.ResetCountingBox();
        }
    }
}