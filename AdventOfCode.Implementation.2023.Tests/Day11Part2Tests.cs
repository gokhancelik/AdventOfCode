using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day11Part2Tests
    {
       

        [Theory]
        [InlineData(99, 8410)]
        [InlineData(9, 1030)]
        public void FindResult(int dist, int expResult)
        {
            var mockInputReader = new Mock<IInputReader>();

            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
               "...#......",
               ".......#..",
               "#.........",
               "..........",
               "......#...",
               ".#........",
               ".........#",
               "..........",
               ".......#..",
               "#...#....."
            });

            var sut = new Day11Part2(mockInputReader.Object);
            sut.GalaxyDistance = dist;
            var result = sut.FindResult();
            result.Should().Be(expResult);
        }
    }
}
