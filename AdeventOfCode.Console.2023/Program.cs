// See https://aka.ms/new-console-template for more information

using AdventOfCode.Implementation._2023;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


var services = new ServiceCollection();

var dayImps = typeof(IDayPart).Assembly.GetTypes()
    .Where(x => !x.IsAbstract && x.IsClass && x.GetInterface(nameof(IDayPart)) == typeof(IDayPart));

foreach (var dayImp in dayImps)
{
    services.Add(new ServiceDescriptor(typeof(IDayPart), dayImp, ServiceLifetime.Singleton));
}

services.AddSingleton<IInputReader, InputReader>();
var sp = services.BuildServiceProvider();
var days = sp.GetServices<IDayPart>();
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
    if (executeDay == "A")
    {
        foreach (var item in daysDictionary)
        {
            var dayToExecute = days.SingleOrDefault(p => p.GetType() == item.Value);
            if (dayToExecute != null)
            {
                dayToExecute.Execute();
            }
        }
    }
    if (int.TryParse(executeDay, out i))
    {
        var dayToExecute = days.SingleOrDefault(p => p.GetType() == daysDictionary[i]);
        if (dayToExecute != null)
        {
            dayToExecute.Execute();
        }
        else
        {
            Console.WriteLine("Not Implemented yet");
        }
    }
}