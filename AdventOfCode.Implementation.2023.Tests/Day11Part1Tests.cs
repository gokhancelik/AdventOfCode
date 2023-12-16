using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day11Part1Tests
    {
        [Theory]
        [InlineData(1, 5, 5, 0, 9)]
        [InlineData(4, 11, 9, 1, 15)]
        [InlineData(0, 0, 0, 5, 5)]
        public void CalculateDistance(double g1x, double g1y, double g2x, double g2y, double expected)
        {

            double result = DistanceCalculator.CalculateDistance(new Galaxy { X = g1x, Y = g1y }, new Galaxy { X = g2x, Y = g2y });
            result.Should().Be(expected);
        }

        [Fact]
        public void FindResult()
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

            var sut = new Day11Part1(mockInputReader.Object);
            var result = sut.FindResult();
            result.Should().Be(374);
        }
    }
}
