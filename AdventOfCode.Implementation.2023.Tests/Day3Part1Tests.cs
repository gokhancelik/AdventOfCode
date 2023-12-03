using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day3Part1Tests
    {

        [Fact]
        public void FindAllEngineParts()
        {
            var mockInputReader = new Mock<IInputReader>();

            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
               "467..114..",
               "...*......",
               "..35..633.",
               "......#...",
               "617*......",
               ".....+.58.",
               "..592.....",
               "......755.",
               "...$.*....",
               ".664.598.."
            });
            var expectedResult = new List<int>()
            {
                467,
                35,
                633,
                617,
                592,
                755,
                664,
                598
            };
            var sut = new Day3Part1(mockInputReader.Object);
            var result = sut.FindAllEngineParts();
            result.Select(s => s.Code).Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void FindResult()
        {
            var mockInputReader = new Mock<IInputReader>();

            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
               "467..114..",
               "...*......",
               "..35..633.",
               "......#...",
               "617*......",
               ".....+.58.",
               "..592.....",
               "......755.",
               "...$.*....",
               ".664.598.."
            });
            var expectedResult = 4361;
            var sut = new Day3Part1(mockInputReader.Object);
            var result = sut.FindResult();
            result.Should().Be(expectedResult);
        }

        /*
         o  o  o
         o  o  o
         o  o  o
         */

        [Theory]
        [InlineData(0, 0, 2, 2, "0,1 1,0 1,1")]
        [InlineData(1, 1, 3, 3, "0,0 0,1 0,2 1,0 1,2 2,0 2,1 2,2")]
        [InlineData(2, 2, 3, 3, "1,1 1,2 2,1 3,1 3,2")]
        public void FindAdjacents(int row, int column, int rowLimit, int columnLimit, string expectedResult)
        {
            var mockInputReader = new Mock<IInputReader>();
            var sut = new Day3Part1(mockInputReader.Object);
            var result = sut.FindAdjacents(row, column, rowLimit, columnLimit);
            expectedResult.Should().Be(string.Join(" ", result.Select(s => $"{s.Item1},{s.Item2}")));
        }
    }
}
