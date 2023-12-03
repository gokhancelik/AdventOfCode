

using System.Diagnostics;
using System.Drawing;

namespace AdventOfCode.Implementation._2023
{
    public class Day2Part1 : IDayPart
    {
        protected const string InputFile = "Day2";
        protected IInputReader inputReader;
        private static string RedCube = "red";
        private static string GreenCube = "green";
        private static string BlueCube = "blue";

        public Day2Part1(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }

        public Dictionary<string, int> NumberOfCubes { get; set; } = new Dictionary<string, int>
            {
                { RedCube, 12 } ,
                { GreenCube, 13 } ,
                { BlueCube, 14 }
            };

        public void Execute()
        {
            var timer = Stopwatch.StartNew();
            var result = FindResult();
            Console.WriteLine($"Result: {result}, timeelapsed: {timer.ElapsedMilliseconds} ms");
        }

        public virtual int FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            var games = lines.Select(l => new Day2Game(l, NumberOfCubes));
            return games.Where(g => g.IsGamePossible()).Sum(p => p.GameId);
        }
    }
    public class Day2GameSet
    {
        public string Color { get; set; }
        public int Count { get; set; }
    }


    public class Day2Game
    {
        public Day2Game(string input, Dictionary<string, int> rules)
        {
            var gameData = input.Split(':');
            GameId = int.Parse(gameData[0].Replace("Game", "").Trim());
            Input = gameData[1];
            Rules = rules;
        }
        public string Input { get; set; }
        public Dictionary<string, int> Rules { get; }

        public IEnumerable<Day2GameSet> Sets
        {
            get
            {
                return ParseGameSets(Input);
            }
        }

        public Dictionary<string, int> MaxPossibleValues
        {
            get
            {
                return Sets.GroupBy(s => s.Color).Select(s => new { s.Key, Max = s.Max(gs => gs.Count) }).ToDictionary(x => x.Key, x => x.Max);
            }
        }

        public int GameId { get; set; }

        private IEnumerable<Day2GameSet> ParseGameSets(string input)
        {
            var gameSets = new List<Day2GameSet>();
            var sets = input.Split(';');
            foreach (var set in sets)
            {
                var cubesInSet = set.Trim().Split(',');
                foreach (var c in cubesInSet)
                {
                    var cubeSets = c.Trim().Split(" ");
                    var color = cubeSets[1];
                    var count = int.Parse(cubeSets[0]);
                    gameSets.Add(new Day2GameSet
                    {
                        Color = color,
                        Count = count
                    });

                }
            }
            return gameSets;
        }

        public bool IsGamePossible()
        {
            foreach (var gameSet in Sets)
            {
                if (gameSet.Count > Rules[gameSet.Color])
                {
                    return false;
                }
            }
            return true;
        }

        public int CalculatePowerOfSets()
        {
            var result = 1;
            foreach (var v in MaxPossibleValues.Select(s => s.Value))
            {
                result *= v;
            }
            return result;
        }
    }
}