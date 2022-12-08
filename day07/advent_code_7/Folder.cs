namespace advent_code_7;

public class Folder
{
    public int Size { get; set; }
    public int TotalSize { get; set; }
    public string Name { get; set; }
    public Folder()
    {
        SubFolders = new List<Folder>();
    }
    public List<Folder> SubFolders { get; }
}