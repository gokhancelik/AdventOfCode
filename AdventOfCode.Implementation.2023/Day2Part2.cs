using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day2Part2 : Day2Part1
    {
        public Day2Part2(IInputReader inputReader) : base(inputReader)
        {

        }


        public override int FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            var games = lines.Select(l => new Day2Game(l, NumberOfCubes));
            return games.Select(s => s.CalculatePowerOfSets()).Sum(p => p);
        }
    }
}
