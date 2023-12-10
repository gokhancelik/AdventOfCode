using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day9Part1Tests
    {
        [Theory]
        [InlineData("0 3 6 9 12 15", 18)]
        [InlineData("1 3 6 10 15 21", 28)]
        [InlineData("10 13 16 21 30 45", 68)]
        public void HistoryOfOasis_Constr(string numbers, long expectedValue)
        {
            var history = new HistoryOfOasis(numbers.Split(' ').Select(long.Parse).ToList());
            var resilt = history.PredictLastValue();
            resilt.Should().Be(expectedValue);
        }

        [Fact]
        public void FindResult1()
        {
            var mockInputReader = new Mock<IInputReader>();

            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45",
            });
            var expectedResult = 114;
            var sut = new Day9Part1(mockInputReader.Object);
            var result = sut.FindResult();
            result.Should().Be(expectedResult);
        }
    }
}
