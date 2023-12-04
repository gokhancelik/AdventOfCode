// See https://aka.ms/new-console-template for more information

using AdventOfCode.Implementation._2023;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
      .AddSingleton<IDayPart, Day1Part1>()
      .AddSingleton<IDayPart, Day1Part2>()
      .AddSingleton<IDayPart, Day2Part1>()
      .AddSingleton<IDayPart, Day2Part2>()
      .AddSingleton<IDayPart, Day3Part1>()
      .AddSingleton<IDayPart, Day3Part2>()
      .AddSingleton<IDayPart, Day4Part1>()
      .AddSingleton<IDayPart, Day4Part2>()
      .AddSingleton<IInputReader, InputReader>()
      .BuildServiceProvider();
var days = serviceProvider.GetServices<IDayPart>();
var i = 0;
var daysDictionary = new Dictionary<int, Type>();
foreach (var day in days)
{
    i++;
    Console.WriteLine($"{i} - {day.GetType()}");
    daysDictionary.Add(i, day.GetType());
}
while (true)
{
    var executeDay = Console.ReadLine();
    if (int.TryParse(executeDay, out i))
    {
        var dayToExecute = days.SingleOrDefault(p => p.GetType() == daysDictionary[i]);
        if( dayToExecute != null)
        {
            dayToExecute.Execute();
        }
        else
        {
            Console.WriteLine("Not Implemented yet");
        }
    }
}