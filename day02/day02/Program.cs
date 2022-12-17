// See https://aka.ms/new-console-template for more information
using day02;

Console.WriteLine("Hello, World!");

var rounds = Input.Moves
    .Split('\n');

var score = 0;
var scorePart2 = 0;

foreach (var round in rounds)
{
    score += GetScore(round);
    scorePart2 += GetScorePart2(round);
}

Console.WriteLine($"Total score: {score}");
Console.WriteLine($"Total score part 2: {scorePart2}");

int GetScorePart2(string round)
{
    switch (round[0])
    {
        case 'A':
            return round[2] switch
            {
                'X' => 0 + GetShapeScore('Z'),
                'Y' => 3 + GetShapeScore('X'),
                'Z' => 6 + GetShapeScore('Y'),
                _ => throw new Exception("xxx")
            };
        case 'B':
            return round[2] switch
            {
                'X' => 0 + GetShapeScore('X'),
                'Y' => 3 + GetShapeScore('Y'),
                'Z' => 6 + GetShapeScore('Z'),
                _ => throw new Exception("xxx")
            };
        case 'C':
            return round[2] switch
            {
                'X' => 0 + GetShapeScore('Y'),
                'Y' => 3 + GetShapeScore('Z'),
                'Z' => 6 + GetShapeScore('X'),
                _ => throw new Exception("xxx")
            };
        default:
            throw new Exception("xxx");
    }
}

int GetScore(string round)
{
    var shapeScore = GetShapeScore(round[2]);
    var outComeScore = GetOutcomeScore(round);
    return shapeScore + outComeScore;
}

int GetOutcomeScore(string round)
{
    switch (round[0])
    {
        case 'A':
            return round[2] switch
            {
                'X' => 3,
                'Y' => 6,
                'Z' => 0,
                _ => throw new Exception("xxx")
            };
        case 'B':
            return round[2] switch
            {
                'X' => 0,
                'Y' => 3,
                'Z' => 6,
                _ => throw new Exception("xxx")
            };
        case 'C':
            return round[2] switch
            {
                'X' => 6,
                'Y' => 0,
                'Z' => 3,
                _ => throw new Exception("xxx")
            };
        default:
            throw new Exception("xxx");
    }
}

int GetShapeScore(char play)
{
    switch (play)
    {
        case 'X':
            return 1;
        case 'Y':
            return 2;
        case 'Z':
            return 3;
        default:
            throw new Exception("xxx");
    }
}
