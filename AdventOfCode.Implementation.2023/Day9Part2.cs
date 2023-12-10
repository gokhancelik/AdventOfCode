using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day9Part2 : Day9Part1
    {
        public Day9Part2(IInputReader inputReader) : base(inputReader)
        {
        }
        public override long FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            var result = 0L;
            foreach (var line in lines)
            {
                var numbers = line.Split(' ').Select(long.Parse).ToList();
                var inputs = new List<OasisInput>();
                var history = new HistoryOfOasis(numbers);
                result += history.PredictFirstValue();
            }
            return result;
        }
    }
}
