

using System.Diagnostics;

namespace AdventOfCode.Implementation._2023
{
    public class Day3Part1 : IDayPart
    {
        protected const string InputFile = "Day3";
        protected readonly IInputReader inputReader;
        public int GearRatio { get; set; }
        public Day3Part1(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }

        public List<EnginePart> FindAllEngineParts()
        {
            var engineParts = new Dictionary<string, EnginePart>();
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            var lineCount = lines.Count();
            char[][] chars = lines.Select(s => s.ToArray()).ToArray();
            var rowLimit = chars.Length;
            for (int row = 0; row < rowLimit; row++)
            {
                var columnLimit = chars[row].Length;
                for (int column = 0; column < columnLimit; column++)
                {
                    var item = chars[row][column];

                    if (char.IsDigit(item) || item == '.')
                    {
                        continue;
                    }
                    else
                    {
                        List<Tuple<int, int>> adjacentCoordinates = FindAdjacents(row, column, rowLimit, columnLimit);
                        var adjacentEngineParts = new Dictionary<string, EnginePart>();
                        foreach (var adjacent in adjacentCoordinates)
                        {
                            var possibleNumber = chars[adjacent.Item1][adjacent.Item2];
                            if (char.IsDigit(possibleNumber))
                            {
                                var enginePart = FindEnginePart(chars[adjacent.Item1], adjacent.Item2, item);

                                var coordinates = $"{adjacent.Item1},{enginePart.StartIndex} {adjacent.Item1},{enginePart.EndIndex}";
                                if (!adjacentEngineParts.ContainsKey(coordinates))
                                {
                                    adjacentEngineParts.Add(coordinates, enginePart);
                                }
                            }
                        }
                        var gearRatio = 1;
                        foreach (var part in adjacentEngineParts)
                        {
                            var isGearRatio = adjacentEngineParts.Count > 1 && part.Value.Name == '*';
                            part.Value.IsGearRatio = isGearRatio;
                            if (isGearRatio)
                            {
                                gearRatio *= part.Value.Code;
                            }
                            if (!engineParts.ContainsKey(part.Key))
                            {
                                engineParts.Add(part.Key, part.Value);
                            }
                        }
                        if (gearRatio > 1)
                        {
                            GearRatio += gearRatio;
                        }
                    }
                }
            }
            return engineParts.Select(ep => ep.Value).ToList();
        }

        public List<Tuple<int, int>> FindAdjacents(int row, int column, int rowLimit, int columnLimit)
        {
            var result = new List<Tuple<int, int>>();
            if (row != 0)
            {
                if (column != 0)
                {
                    result.Add(new Tuple<int, int>(row - 1, column - 1));
                }
                result.Add(new Tuple<int, int>(row - 1, column));
                if (column + 1 < columnLimit)
                {
                    result.Add(new Tuple<int, int>(row - 1, column + 1));
                }
            }
            if (column != 0)
            {
                result.Add(new Tuple<int, int>(row, column - 1));
            }
            if (column + 1 < columnLimit)
            {
                result.Add(new Tuple<int, int>(row, column + 1));
            }
            if (row < rowLimit)
            {
                if (column != 0)
                {
                    result.Add(new Tuple<int, int>(row + 1, column - 1));
                }
                result.Add(new Tuple<int, int>(row + 1, column));
                if (column + 1 < columnLimit)
                {
                    result.Add(new Tuple<int, int>(row + 1, column + 1));
                }
            }
            return result;
        }

        public EnginePart FindEnginePart(char[] chars, int adjecentOfASign, char name)
        {
            string numberStr = "";
            var newY = adjecentOfASign;

            while (newY >= 0 && char.IsDigit(chars[newY]))
            {
                numberStr = $"{chars[newY]}{numberStr}";
                newY--;
            }
            int startIndex = newY;
            newY = adjecentOfASign + 1;
            while (newY < chars.Length && char.IsDigit(chars[newY]))
            {
                numberStr = $"{numberStr}{chars[newY]}";
                newY++;
            }
            int endIndex = newY;
            return new EnginePart
            {
                EndIndex = endIndex,
                Code = int.Parse(numberStr),
                Name = name,
                StartIndex = startIndex,
            };
        }

        public virtual int FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            var engineParts = FindAllEngineParts();
            return engineParts.Sum(s => s.Code);
        }
        public void Execute()
        {
            var timer = Stopwatch.StartNew();
            var result = FindResult();
            Console.WriteLine($"Result: {result}, timeelapsed: {timer.ElapsedMilliseconds} ms");
        }
    }
    public class EnginePart
    {
        public char Name { get; set; }
        public int Code { get; set; }

        public int StartIndex { get; set; }

        public int EndIndex { get; set; }

        public bool IsGearRatio { get; set; }
    }
}
