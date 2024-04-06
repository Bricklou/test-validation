using SimulationCredits;

namespace SimulationCreditsTest;

public class FakeFileSystem : IFilesystem
{
    public Dictionary<string, string> KeyValuePairs { get; } = new();

    public void WriteText(string pathName, string content)
    {
        KeyValuePairs[pathName] = content;
    }

    public bool Exists(string filename)
    {
        return KeyValuePairs.ContainsKey(filename);
    }

    public string ReadText(string pathName)
    {
        return KeyValuePairs[pathName];
    }
}