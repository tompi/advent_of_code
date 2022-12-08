// See https://aka.ms/new-console-template for more information
using advent_code_5;

Console.WriteLine("Hello, World!");

var stacks = new List<Stack<string>>();

foreach (var s in Input.txtStackDefs.Split("   "))
{
    stacks.Add(new Stack<string>());
}

var noStacks = stacks.Count;
foreach (var line in Input.txtStacks.Split('\n').Reverse())
{
    for (var i = 0; i < noStacks; i++)
    {
        var element = line.Substring(i * 4, 3);
        if (!string.IsNullOrWhiteSpace(element))
        {
            stacks[i].Push(element);
        }
    }
}

foreach (var move in Input.txtMoves.Split('\n'))
{
    var commands = move.Split(' ');
    var moves = int.Parse(commands[1]);
    var fromIndex = int.Parse(commands[3]) - 1;
    var toIndex = int.Parse(commands[5]) - 1;
    Console.WriteLine($"move {moves} from {fromIndex} to {toIndex}");
    var els = new List<string>();
    for (var i = 0; i < moves; i++)
    {
        els.Add(stacks[fromIndex].Pop());
    }

    els.Reverse();
    foreach (var el in els)
    {
        stacks[toIndex].Push(el);
    }
}

foreach (var s in stacks)
{
    Console.Write(s.Pop()[1]);
}