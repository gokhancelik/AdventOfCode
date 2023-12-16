using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day11Part2 : Day11Part1
    {
        public Day11Part2(IInputReader inputReader) : base(inputReader)
        {
        }
        public override int GalaxyDistance { get; set; } = 1000000 - 1;
    }
}
