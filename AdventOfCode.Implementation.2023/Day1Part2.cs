
using System.Diagnostics;

namespace AdventOfCode.Implementation._2023
{
    public class Day1Part2 : IDayPart
    {
        private const string InputFile = "Day1";
        private readonly IInputReader inputReader;
        private Dictionary<string, string> _numberMappings = new Dictionary<string, string>
        {
            //{ "oneight", 18 },
            //{ "nineight", 98 },
            //{ "fiveight", 58 },
            //{ "sevenine", 79 },
            //{ "eighthree", 83 },
            //{ "eightwo", 82 },
            //{ "twone", 21 },
            //{ "oneightwo", 12 },
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "f4r" },
            { "five", "f5e" },
            { "six", "s6x" },
            { "seven", "s7n" },
            { "eight", "e8t" },
            { "nine", "n9e" },
        };

        public Day1Part2(IInputReader inputReader)
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
            input = ReplaceNumberStringsToDigits(input);
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

        private string ReplaceNumberStringsToDigits(string input)
        {
            for (int i = 0; i < _numberMappings.Count;)
            {
                var maping = _numberMappings.ElementAt(i);
                if (input.Contains(maping.Key))
                {
                    input = input.Replace(maping.Key, maping.Value.ToString());
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            return input;
        }

        public void Execute()
        {
            var timer = Stopwatch.StartNew();
            var result = FindResult();
            Console.WriteLine($"Result: {result}, timeelapsed: {timer.ElapsedMilliseconds} ms");
        }
    }
}
