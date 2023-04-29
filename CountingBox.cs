namespace CloseTheBox
{
    internal class CountingBox
    {
        private Dictionary<int, bool> countingBox = new Dictionary<int, bool>(10);
        private int totalCount;
        private string state = "";

        public CountingBox()
        {
            for (int i = 1; i <= 10; i++)
            {
                countingBox.Add(i, true); //we start all integers are true and "open" or "up"
            }
            totalCount = 0;
        }

        public void DisplayCountingBox()
        {
            foreach (KeyValuePair<int, bool> pair in countingBox)
            {
                if (pair.Value) { state = "Up"; } 
                else            { state = "Down"; }                      

                Console.WriteLine("Number: {0}, State: {1}", pair.Key, state);
            }
            Console.WriteLine("---------------");
        }

        public bool CheckValue(int integer)
        {
            if (integer > 10)
            {
                return false;
            } else
            {
                return countingBox[integer];
            }
        }

        public void CloseNumber(int integer)
        {
            countingBox[integer] = false;
        }

        public int GetCount()
        {
            foreach (KeyValuePair<int, bool> pair in countingBox)
            {
                if(pair.Value)
                {
                    totalCount += pair.Key;
                }
            }
            return totalCount;
        }

        public void ResetCountingBox()
        {
            for (int i = 1; i <= 10; i++)
            {
                countingBox[i] = true; 
            }
            totalCount = 0;
        }
    }
}