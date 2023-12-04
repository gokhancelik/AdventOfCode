﻿using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023.Tests
{
    public class Day4Part2Tests
    {

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
            var expectedResult = 30;
            var sut = new Day4Part2(mockInputReader.Object);
            var result = sut.FindResult();
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void FindWinningNumberInACard()
        {
            var mockInputReader = new Mock<IInputReader>();

            mockInputReader.Setup(ir => ir.ReadFile(It.IsAny<string>())).Returns(new string[]
            {
             "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", //4    1   1   1   
             "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", //2    1   2   2
             "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", //2    1   2   4
             "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", //1    1   2   4
             "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", //0    1   2   2
             "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"  //0    1   1   1
            });
            var sut = new Day4Part2(mockInputReader.Object);
            var cards = sut.GetCards();
            cards.SingleOrDefault(c => c.CardNumber == 1).CopyOfCard.Should().Be(1);
            cards.SingleOrDefault(c => c.CardNumber == 2).CopyOfCard.Should().Be(2);
            cards.SingleOrDefault(c => c.CardNumber == 3).CopyOfCard.Should().Be(4);
            cards.SingleOrDefault(c => c.CardNumber == 4).CopyOfCard.Should().Be(8);
            cards.SingleOrDefault(c => c.CardNumber == 5).CopyOfCard.Should().Be(14);
            cards.SingleOrDefault(c => c.CardNumber == 6).CopyOfCard.Should().Be(1);
        }
    }
}
