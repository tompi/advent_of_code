// See https://aka.ms/new-console-template for more information
using System.Globalization;
using advent_code_7;

Console.WriteLine("Hello, World!");

var lines = new Queue<string>();

    foreach (var s in Input.Commands.Split('\n'))
    {
        lines.Enqueue(s);
    }

var total = 0;
var root = new Folder();
lines.Dequeue();
PopulateSubFolder(root);

Console.WriteLine(root.Size);

PopulateTotalSize(root);
void PopulateTotalSize(Folder folder)
{
    foreach (var subFolder in folder.SubFolders)
    {
        PopulateTotalSize(subFolder);
    }
    folder.TotalSize = folder.Size + folder.SubFolders.Sum(s => s.TotalSize);
    if (folder.TotalSize <= 100_000)
    {
        total += folder.TotalSize;
    }
}

Console.WriteLine(total);


void PopulateSubFolder(Folder parent)
{
    var line = lines.Dequeue();
    while (line != "$ cd ..")
    {
        var parts = line.Split(' ');
        if (int.TryParse(parts[0], out int size))
        {
            parent.Size += size;
        }
        else if (line.StartsWith("$ cd "))
        {
            var child = new Folder
            {
                Name = parts[2]
            };
            parent.SubFolders.Add(child);
            PopulateSubFolder(child);
        }

        if (lines.Count > 0)
        {
            line = lines.Dequeue();
        }
        else
        {
            line = "$ cd ..";
        }
    }
}