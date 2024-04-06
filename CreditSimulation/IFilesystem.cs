namespace SimulationCredits;

public interface IFilesystem
{
    public void WriteText(string pathName, string content);

    public bool Exists(string filename);

    public string ReadText(string pathName);
}