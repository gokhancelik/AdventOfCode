using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day7Part2Tests
    {
        [Fact]
        public void FindResult()
        {
            var mockInputReader = new Mock<IInputReader>();

            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
            "2345A 1",
            "Q2KJJ 13",
            "Q2Q2Q 19",
            "T3T3J 17",
            "T3Q33 11",
            "2345J 3 ",
            "J345A 2 ",
            "32T3K 5 ",
            "T55J5 29",
            "KK677 7 ",
            "KTJJT 34",
            "QQQJA 31",
            "JJJJJ 37",
            "JAAAA 43",
            "AAAAJ 59",
            "AAAAA 61",
            "2AAAA 23",
            "2JJJJ 53",
            "JJJJ2 41",
            //"32T3K 765",
            //"T55J5 684",
            //"KK677 28",
            //"KTJJT 220",
            //"QQQJA 483",
            //"JJJJJ 100"
            });
            var expectedResult = 6839;
            var sut = new Day7Part2(mockInputReader.Object);
            var result = sut.FindResult();
            result.Should().Be(expectedResult);
        }
    }
}
