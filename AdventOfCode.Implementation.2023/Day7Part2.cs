using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day7Part2 : Day7Part1
    {

        public Day7Part2(IInputReader inputReader) : base(inputReader)
        {
        }

        public override int FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");

            var hands = new List<Day7Part2Hand>();
            foreach (var line in lines)
            {
                var input = line.Split(' ');
                var bet = int.Parse(input[1].Trim());
                var hand = new Day7Part2Hand(input[0], bet);
                hands.Add(hand);
            }
            var i = 1;
            foreach (var hand in hands.OrderBy(p => p.Power).ThenBy(p => p.CardsValue))
            {
                hand.Rank = i++;
            }
            var result = hands.OrderBy(p => p.Rank);
            var r = string.Join(Environment.NewLine, result.Select(s => $"{s.Cards} Rank:{s.Rank} Point: {s.Point} Power: {s.Power} Value: {s.CardsValue}"));
            return hands.Sum(p => p.Point);
        }


        public static Dictionary<char, Day7Card> Cards2 = new Dictionary<char, Day7Card>
        {
            {'A', new Day7Card { Strength=14 } },
            {'K', new Day7Card { Strength=13 } },
            {'Q', new Day7Card { Strength=12 } },
            {'T', new Day7Card { Strength=10 } },
            {'9', new Day7Card { Strength=9 } },
            {'8', new Day7Card { Strength=8 } },
            {'7', new Day7Card { Strength=7 } },
            {'6', new Day7Card { Strength=6 } },
            {'5', new Day7Card { Strength=5 } },
            {'4', new Day7Card { Strength=4 } },
            {'3', new Day7Card { Strength=3 } },
            {'2', new Day7Card { Strength=2 } },
            {'J', new Day7Card { Strength=1 } },
        };
    }
    public class Day7Part2Hand : Day7Hand
    {
        public Day7Part2Hand(string input, int bet) : base(input, bet)
        {
        }

        public override void AddCards()
        {
            base.AddCards();
            if (Cards == "JJJJJ")
                return;
            if (CardPairs.ContainsKey('J'))
            {
                var jCards = CardPairs['J'];
                var biggest = CardPairs.Where(p => p.Key != 'J').OrderByDescending(s => s.Value.Count).ThenByDescending(s => Day7Part2.Cards2[s.Key].Strength).FirstOrDefault();
                CardPairs.Remove('J');
                foreach (var jCard in jCards)
                {
                    jCard.Strength = Day7Part2.Cards2[biggest.Key].Strength;
                }
                biggest.Value.AddRange(jCards);
            }
        }
        protected override double CalculateCardsValues()
        {
            double power = 0;

            var cardCount = Cards.Count();
            for (int i = 1; i <= cardCount; i++)
            {
                var cardChar = Cards.ElementAt(i - 1);
                var card = Day7Part2.Cards2[cardChar];
                //KK677 13^15 + 13^15
                //KTJJT 13^15 + 10^15
                power += Math.Pow(15, (cardCount - i)) * card.Strength;
            }

            return power;
        }
    }
}
