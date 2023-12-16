using System.Data.Common;
using System.Diagnostics;
using System.Drawing;

namespace AdventOfCode.Implementation._2023
{
    public class Day11Part1(IInputReader inputReader) : IDayPart
    {
        private const string InputFile = "Day11";
        public virtual int GalaxyDistance { get; set; } = 1;
        public void Execute()
        {
            var timer = Stopwatch.StartNew();
            var result = FindResult();
            Console.WriteLine($"Result: {result}, timeelapsed: {timer.ElapsedMilliseconds} ms");
        }

        public double FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            var lineCount = lines.Count();
            var columnCount = lines.First().Length;
            char[,] chars = new char[lineCount, columnCount];
            for (int i = lineCount - 1; i >= 0; i--)
            {
                var line = lines.ElementAt(i);
                for (int j = 0; j < line.Length; j++)
                {
                    chars[(lineCount - i - 1), j] = line[j];
                }
            }

            var rowLimit = chars.Length;
            var galaxies = new List<Galaxy>();
            var galaxyNumber = 1;
            var yOffset = 0;

            for (int row = 0; row < chars.GetLength(1); row++)
            {
                if (!GetRow(chars, row).Any(p => p == '#'))
                {
                    yOffset += GalaxyDistance;
                }
                var xOffset = 0;
                for (int col = 0; col < chars.GetLength(0); col++)
                {
                    if (!GetColumn(chars, col).Any(p => p == '#'))
                    {
                        xOffset += GalaxyDistance;
                    }
                    var point = chars[row, col];
                    if (point == '#')
                    {
                        galaxies.Add(new Galaxy { Number = galaxyNumber, X = col + xOffset, Y = row + yOffset });
                        galaxyNumber++;
                    }

                }
            }
            double result = 0;
            for (int i = 0; i < galaxies.Count; i++)
            {
                var galaxy = galaxies[i];
                var otherGalaxies = galaxies.Where(p => p.Number != galaxy.Number);
                foreach (var item in otherGalaxies)
                {
                    result += DistanceCalculator.CalculateDistance(galaxy, item);
                }
            }
            return result / 2;
        }
        public char[] GetColumn(char[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public char[] GetRow(char[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }

    public class Galaxy
    {
        public int Number { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public override string ToString()
        {
            return $"{Number} - ({X},{Y})";
        }
    }

    public static class DistanceCalculator
    {
        public static double CalculateDistance(Galaxy galaxy1, Galaxy galaxy2)
        {
            return Math.Abs(galaxy1.Y - galaxy2.Y) + Math.Abs(galaxy1.X - galaxy2.X);
        }

    }
}
