using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Implementation._2023
{
    public class Day9Part1 : IDayPart
    {
        protected const string InputFile = "Day9";
        protected readonly IInputReader inputReader;

        public Day9Part1(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }
        public void Execute()
        {
            var timer = Stopwatch.StartNew();
            var result = FindResult();
            Console.WriteLine($"Result: {result}, timeelapsed: {timer.ElapsedMilliseconds} ms");
        }

        public virtual long FindResult()
        {
            var lines = inputReader.ReadFile($"{InputFile}.txt");
            var result = 0L;
            foreach (var line in lines)
            {
                var numbers = line.Split(' ').Select(long.Parse).ToList();
                var inputs = new List<OasisInput>();
                var history = new HistoryOfOasis(numbers);
                result += history.PredictLastValue();
            }
            return result;
        }
    }
    public class HistoryOfOasis
    {
        public HistoryOfOasis(List<long> numbers, HistoryOfOasis parent = null)
        {
            Inputs = new List<OasisInput>();
            Parent = parent;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                var number1 = numbers[i];
                var number2 = numbers[i + 1];
                var input = new OasisInput(number1, number2);
                Inputs.Add(input);
            }
            if (Inputs.Count(p => p.Difference == 0) != Inputs.Count)
            {
                Child = new HistoryOfOasis(Inputs.Select(i => i.Difference).ToList(), this);
            }
        }


        public HistoryOfOasis Child { get; set; }

        public List<OasisInput> Inputs { get; set; }

        public HistoryOfOasis Parent { get; }

        public long PredictLastValue(HistoryOfOasis history = null)
        {
            if (history == null)
            {
                history = FindLeafChild(this);
            }
            var lastInputOfLeaf = history.Inputs.Last().Last;
            if (history.Parent != null)
            {
                lastInputOfLeaf += PredictLastValue(history.Parent);
            }

            return lastInputOfLeaf;
        }

        public long PredictFirstValue(HistoryOfOasis history = null, long difference = 0)
        {
            if (history == null)
            {
                history = FindLeafChild(this);
            }
            var firstInput = history.Inputs.First();
            var firstInputOfLeaf = firstInput.First - difference;

            if (history.Parent != null)
            {
                firstInputOfLeaf = PredictFirstValue(history.Parent, firstInputOfLeaf);
            }
            return firstInputOfLeaf;
        }


        private HistoryOfOasis FindLeafChild(HistoryOfOasis history)
        {
            if (history.Child == null)
            {
                return history;
            }
            return FindLeafChild(history.Child);
        }
    }
    public class OasisInput
    {
        public OasisInput(long first, long last)
        {
            First = first;
            Last = last;
        }

        public long First { get; set; }

        public long Last { get; set; }

        public long Difference => Last - First;
    }
}
