using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day7Part1Tests
    {
        [Fact]
        public void FindResult()
        {
            var mockInputReader = new Mock<IInputReader>();

            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483",
            });
            var expectedResult = 6440;
            var sut = new Day7Part1(mockInputReader.Object);
            var result = sut.FindResult();
            result.Should().Be(expectedResult);
        }
    }
}
