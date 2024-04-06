namespace SimulationCredits;

public class FileSystem : IFilesystem
{
    public void WriteText(string pathName, string content)
    {
        File.WriteAllText(pathName, content);
    }

    public bool Exists(string filename)
    {
        return File.Exists(filename);
    }

    public string ReadText(string pathName)
    {
        return File.ReadAllText(pathName);
    }
}