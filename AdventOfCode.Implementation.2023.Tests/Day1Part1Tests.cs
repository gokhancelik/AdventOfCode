using FluentAssertions;
using Moq;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day1Part1Tests
    {
        [Theory]
        [InlineData("sixsrvldfour4seven", 44)]
        [InlineData("1abc2", 12)]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("treb7uchet", 77)]
        [InlineData("2oneight", 22)]
        [InlineData("53hvhgchljnlxqjsgrhxgf1zfoureightmlhvvv", 51)]
        public void FindCalibrationValue(string input, int expectedValue)
        {
            var mockInputReader = new Mock<IInputReader>();
            var sut = new Day1Part1(mockInputReader.Object);
            int result = sut.FindCalibrationValue(input);
            result.Should().Be(expectedValue);
        }

        [Fact]
        public void FindResult()
        {
            var mockInputReader = new Mock<IInputReader>();
            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
                "2oneight",
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet"
            });
            var sut = new Day1Part1(mockInputReader.Object);
            int result = sut.FindResult();
            result.Should().Be(164);
        }

    }
}