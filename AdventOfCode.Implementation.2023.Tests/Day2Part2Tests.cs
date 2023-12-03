using FluentAssertions;
using Moq;

namespace AdventOfCode.Implementation._2023.Tests
{

    public class Day2Part2Tests
    {
        [Theory]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
        public void IsGamePossible(string input, int expectedValue)
        {
            var numberOfCubes = new Dictionary<string, int>
            {
                { "red", 12 } ,
                { "green", 13 } ,
                { "blue", 14 }
            };
            var sut = new Day2Game(input, numberOfCubes);
            int result = sut.CalculatePowerOfSets();
            result.Should().Be(expectedValue);
        }

        [Fact]
        public void FindResult()
        {
            var mockInputReader = new Mock<IInputReader>();
            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
            });
            var sut = new Day2Part2(mockInputReader.Object);
            int result = sut.FindResult();
            result.Should().Be(2286);
        }
    }
}
