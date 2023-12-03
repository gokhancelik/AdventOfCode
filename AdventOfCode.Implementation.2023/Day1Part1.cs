
using System.Diagnostics;

namespace AdventOfCode.Implementation._2023
{
    public class Day1Part1 : IDayPart
    {
        private const string InputFile = "Day1";
        private readonly IInputReader inputReader;

        public Day1Part1(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }
        public int FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            var result = 0;

            foreach (var line in lines)
            {
                var calValue = FindCalibrationValue(line);
                result += calValue;
            }
            return result;
        }
        public int FindCalibrationValue(string input)
        {
            int? firstNumber = null;
            int? secondNumber = null;
            for (int i = 0; i < input.Length; i++)
            {
                var firstChar = input[i];
                if (!firstNumber.HasValue && char.IsDigit(firstChar))
                {
                    firstNumber = firstChar - '0';
                    break;
                }
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                var lastChar = input[i];
                if (!secondNumber.HasValue && char.IsDigit(lastChar))
                {
                    secondNumber = lastChar - '0';
                    break;
                }
            }
            if (!firstNumber.HasValue)
            {
                firstNumber = 0;
            }
            if (!secondNumber.HasValue)
            {
                secondNumber = 0;
            }
            return firstNumber.Value * 10 + secondNumber.Value;
        }

        public void Execute()
        {
            var timer = Stopwatch.StartNew();
            var result = FindResult();
            Console.WriteLine($"Result: {result}, timeelapsed: {timer.ElapsedMilliseconds} ms");
        }
    }
}
