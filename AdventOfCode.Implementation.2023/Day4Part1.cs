using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day4Part1 : IDayPart
    {
        protected const string InputFile = "Day4";
        protected readonly IInputReader inputReader;

        public Day4Part1(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }

        public virtual double FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");

            var games = lines.Select(l => new Day4Card(l));
            return games.Sum(g => g.CalculatePoint());
        }

        public void Execute()
        {

            var timer = Stopwatch.StartNew();
            var result = FindResult();
            Console.WriteLine($"Result: {result}, timeelapsed: {timer.ElapsedMilliseconds} ms");
        }
    }
    public class Day4Card
    {
        public int CardNumber { get; private set; }
        private IEnumerable<int> WinningNumbersOfGame { get; }
        public IEnumerable<int> Numbers { get; }
        public IEnumerable<int> WinningNumbers { get { return FindWinningNumber(); } }

        public int CopyOfCard { get; set; } = 1;

        public Day4Card(string input)
        {
            var cardInfo = input.Split(':');
            CardNumber = int.Parse(cardInfo[0].Split(' ').Where(p => !string.IsNullOrWhiteSpace(p)).ElementAt(1).Trim());
            var numbersInfo = cardInfo[1].Trim().Split('|');
            var winningNumbers = numbersInfo[0];
            var numbers = numbersInfo[1];
            WinningNumbersOfGame = winningNumbers.Trim().Split(' ').Where(p => !string.IsNullOrWhiteSpace(p)).Select(s => int.Parse(s.Trim()));
            Numbers = numbers.Trim().Split(' ').Where(p => !string.IsNullOrWhiteSpace(p)).Select(s => int.Parse(s.Trim()));
        }

        public IEnumerable<int> FindWinningNumber()
        {
            return Numbers.Intersect(WinningNumbersOfGame);
        }

        public double CalculatePoint()
        {
            var winningNumbers = FindWinningNumber();
            var originalPoint = winningNumbers.Count() == 0 ? 0 : Math.Pow(2, winningNumbers.Count() - 1);
            return originalPoint;
        }
    }
}
