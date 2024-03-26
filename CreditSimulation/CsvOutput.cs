namespace SimulationCredits;

public class CsvOutput
{
    public CsvOutput(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentNullException(nameof(path));
    }
}