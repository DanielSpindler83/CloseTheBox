namespace CloseTheBox
{
    internal class Dice
    {
        private Random random = new();

        public int RollTheDice()
        {
            int num = random.Next(1,7);
            return num;
        }
    }
}