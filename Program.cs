using System.Diagnostics;
using System.Globalization;

namespace CloseTheBox
{
    internal class Program
    {
        static void Main()
        {
            // we will count each time a single game closes the box (all numbers downed perfectly)
            var closeBoxWinCount = 0;

            // number of games we want to play
            var gamesToPlay = 150; // 1_000_000_000 = 1 Billion - takes about 20mins, on my computer, when not printing to the screen

            var Player1 = new Player { DisplayFullGameInfoToConsole = true };

            // timing things so we can estimate time for running more games
            var timer = new Stopwatch();
            timer.Start();

            for (long gameCount = 0; gameCount < gamesToPlay; gameCount++) {
                Player1.PlayAGame();
                if (Player1.GetFinalCount() == 0) // If they shut the box
                {
                    closeBoxWinCount++;
                }
                Player1.ResetPlayer(); // tell the player to reset their counting box back to all Up
            }

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Time taken: " + timeTaken.ToString(@"m\:ss\.fff"));

            Console.WriteLine("Close the box count = " + closeBoxWinCount);
            Console.WriteLine("Games played = " + (gamesToPlay).ToString("N0", new CultureInfo("en-US")));
            double percentageWinCount = Math.Round(((double)closeBoxWinCount / (double)gamesToPlay) * 100, 2);
            Console.WriteLine("Close the box percentage = " + percentageWinCount);
        }
    }
}