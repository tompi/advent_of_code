// See https://aka.ms/new-console-template for more information
using day01;

Console.WriteLine("Hello, World!");

var elves = ParseCalories(Input.Calories);

var maxCal = elves.Max(e => e.Sum());
var maxElf = elves.First(e => e.Sum(c => c) == maxCal);
Console.WriteLine($"Maxcal: {maxCal}, Maxelf index: {elves.IndexOf(maxElf) + 1}");

var totalCals = elves
    .Select(e => e.Sum())
    .OrderDescending()
    .ToList();

Console.WriteLine(totalCals[0] + totalCals[1] + totalCals[2]);

List<List<int>> ParseCalories(string calories)
{
    var lines = calories.Split("\n");
    var elves = new List<List<int>>();
    var currentElf = new List<int>();
    elves.Add(currentElf);

    foreach (var line in lines)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            currentElf = new List<int>();
            elves.Add(currentElf);
        }
        else
        {
            currentElf.Add(int.Parse(line));
        }
    }

    return elves;
}