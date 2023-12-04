using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day4Part2 : Day4Part1
    {
        public Day4Part2(IInputReader inputReader) : base(inputReader)
        {
        }

        public IEnumerable<Day4Card> GetCards()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");

            var games = lines.Select(l => new Day4Card(l)).ToList();
            for (var i = 0; i < games.Count(); i++)
            {
                var game = games.ElementAt(i);
                var currentGameWinningCount = game.WinningNumbers.Count();
                var addCopies = games.Skip(i + 1).Take(currentGameWinningCount);
                foreach (var ac in addCopies)
                {
                    ac.CopyOfCard += game.CopyOfCard;
                }
            }
            return games;
        }

        public override double FindResult()
        {

            return GetCards().Sum(g => g.CopyOfCard);
        }
    }
}
