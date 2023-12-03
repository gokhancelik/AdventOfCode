using FluentAssertions;
using Moq;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day1Part2Tests
    {
        [Theory]
        [InlineData("abconeightxyz", 18)]
        [InlineData("sixsrvldfour4seven", 67)]
        [InlineData("1abc2", 12)]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("treb7uchet", 77)]
        [InlineData("oneightwo", 12)]
        [InlineData("2oneight", 28)]
        [InlineData("twoneighthree", 23)]
        [InlineData("53hvhgchljnlxqjsgrhxgf1zfoureightmlhvvv", 58)]
        public void FindCalibrationValue(string input, int expectedValue)
        {
            var mockInputReader = new Mock<IInputReader>();
            var sut = new Day1Part2(mockInputReader.Object);
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
            var sut = new Day1Part2(mockInputReader.Object);
            int result = sut.FindResult();
            result.Should().Be(170);
        }

    }
}