// See https://aka.ms/new-console-template for more information
using day03;

Console.WriteLine("Hello, World!");

var sacks = Input.Sacks.Split('\n');
int totalScore = 0;
var elvesPerItem = new Dictionary<char, int>();
var totalScorePerItem = new Dictionary<char, int>();

foreach (var sack in sacks)
{
    var duplicate = GetDuplicate(sack);
    var score = GetScore(duplicate);
    Console.WriteLine($"{duplicate} = {score}");
    totalScore += score;
    foreach (var item in sack)
    {
        if (!totalScorePerItem.ContainsKey(item))
        {
            totalScorePerItem.Add(item, 0);
        }
        totalScorePerItem[item] += GetScore(item);
    }
    foreach (var item in sack.Distinct())
    {
        if (!elvesPerItem.ContainsKey(item))
        {
            elvesPerItem.Add(item, 0);
        }
        elvesPerItem[item] ++;
    }
}

Console.WriteLine($"Total score: {totalScore}");

var totalPart2Score = 0;
foreach (var keyValuePair in elvesPerItem
             .Where(kv => kv.Value == 3))
{
    var score = totalScorePerItem[keyValuePair.Key];
    totalPart2Score += score;
    Console.WriteLine($"{keyValuePair.Key}: {score}");
}

Console.WriteLine($"Total part 2: {totalPart2Score}");

char GetDuplicate(string sack)
{
    var l = sack.Length / 2;
    var compartment1 = sack.Substring(0, l);
    var compartment2 = sack.Substring(l);
    foreach (var item in compartment1)
    {
        if (compartment2.Contains(item))
        {
            return item;
        }
    }

    throw new Exception("No duplicates");
}


int GetScore(char c)
{
    if (c > 96)
    {
        return (int)c - 96;
    }

    return c - 38;
}
