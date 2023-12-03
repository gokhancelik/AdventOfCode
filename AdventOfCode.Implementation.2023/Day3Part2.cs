using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day3Part2 : Day3Part1
    {
        public Day3Part2(IInputReader inputReader) : base(inputReader)
        {
        }

        public override int FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            _ = FindAllEngineParts();
            return GearRatio;
        }
    }
}
