using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day4Part1Tests
    {
        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", "48 83 86 17")]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", "32 61")]
        [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", "1 21")]
        [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", "84")]
        [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", "")]
        [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", "")]
        public void FindWinningNumberInACard(string input, string winningNumber)
        {
            var wNmbers = string.IsNullOrEmpty(winningNumber) ? new List<int>() : winningNumber.Split(' ').Select(int.Parse);
            var sut = new Day4Card(input);
            IEnumerable<int> result = sut.FindWinningNumber();
            result.Should().BeEquivalentTo(wNmbers);
        }

        [Fact]
        public void FindResult()
        {
            var mockInputReader = new Mock<IInputReader>();

            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
              "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
             "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
             "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
             "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
             "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
             "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
            });
            var expectedResult = 13;
            var sut = new Day4Part1(mockInputReader.Object);
            var result = sut.FindResult();
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
        [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
        [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
        [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
        [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
        public void CalculatePoint(string input, double expectedPoint)
        {
            var sut = new Day4Card(input);
            double result = sut.CalculatePoint();
            result.Should().Be(expectedPoint);
        }
    }
}
