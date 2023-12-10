using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day7Part1: IDayPart
    {
        protected const string InputFile = "Day7";

        public Day7Part1(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }
        public static Dictionary<char, Day7Card> Cards = new Dictionary<char, Day7Card>
        {
            {'A', new Day7Card { Strength=14 } },
            {'K', new Day7Card { Strength=13 } },
            {'Q', new Day7Card { Strength=12 } },
            {'J', new Day7Card { Strength=11 } },
            {'T', new Day7Card { Strength=10 } },
            {'9', new Day7Card { Strength=9 } },
            {'8', new Day7Card { Strength=8 } },
            {'7', new Day7Card { Strength=7 } },
            {'6', new Day7Card { Strength=6 } },
            {'5', new Day7Card { Strength=5 } },
            {'4', new Day7Card { Strength=4 } },
            {'3', new Day7Card { Strength=3 } },
            {'2', new Day7Card { Strength=2 } },
        };
        protected readonly IInputReader inputReader;

        public virtual int FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");

            var hands = new List<Day7Hand>();
            foreach (var line in lines)
            {
                var input = line.Split(' ');
                var bet = int.Parse(input[1].Trim());
                var hand = new Day7Hand(input[0], bet);
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

        public void Execute()
        {

            var timer = Stopwatch.StartNew();
            var result = FindResult();
            Console.WriteLine($"Result: {result}, timeelapsed: {timer.ElapsedMilliseconds} ms");
        }
    }

    public class Day7Hand
    {
        public Day7Hand(string input, int bet)
        {
            CardPairs = new Dictionary<char, List<Day7Card>>();
            Kinds = new List<Kind>();
            Cards = input;
            AddCards();
            Bet = bet;
        }

        public virtual void AddCards()
        {
            foreach (var card in Cards)
            {
                AddCard(card, Day7Part1.Cards[card]);
            }
        }

        public Dictionary<char, List<Day7Card>> CardPairs { get; set; }

        public List<Kind> Kinds { get; set; }

        public int Bet { get; private set; }
        public string Cards { get; private set; }
        public int Rank { get; internal set; }
        public int Point => Bet * Rank;
        public double Power => CalculatePowerOfHand();
        public double CardsValue => CalculateCardsValues();

        protected virtual double CalculateCardsValues()
        {
            double power = 0;

            var cardCount = Cards.Count();
            for (int i = 1; i <= cardCount; i++)
            {
                var cardChar = Cards.ElementAt(i - 1);
                var card = Day7Part1.Cards[cardChar];
                //KK677 13^15 + 13^15
                //KTJJT 13^15 + 10^15
                power += Math.Pow(15, (cardCount - i)) * card.Strength;
            }

            return power;
        }

        public override string ToString()
        {
            return $"{Cards.ToString()} {Power}";
        }

        public virtual void AddCard(char cardId, Day7Card card)
        {
            if (!CardPairs.ContainsKey(cardId))
            {
                CardPairs.Add(cardId, new List<Day7Card>(5) { card });
            }
            else
            {
                CardPairs[cardId].Add(card);
            }
        }

        public virtual double CalculatePowerOfHand()
        {
            double power = 0;
            foreach (var item in CardPairs)
            {
                var pairs = item;
                power += Math.Pow(10, pairs.Value.Count);
            }
            return power;
        }
    }

    public enum Kind
    {
        Five = 7,
        Four = 6,
        FullHouse = 5,
        Three = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1

    }

    public class Day7Card
    {
        public int Strength { get; internal set; }
    }
}
