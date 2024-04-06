namespace SimulationCredits;

public class CsvOutput
{
    private readonly string _path;
    private readonly IFilesystem _fileSystem;

    public CsvOutput(string path, IFilesystem fileSystem)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentNullException(nameof(path));

        _path = path;
        _fileSystem = fileSystem;
    }

    public string ToString(Credit credit, IEnumerable<DueAmount> computedData)
    {
        var output = $"{credit.TotalAmount}\n";
        output += computedData.Aggregate("",
            (current, dueAmount) =>
                current + $"{dueAmount.Month},{dueAmount.PaidAmount},{dueAmount.RemainingAmount}\n");

        return output;
    }

    public void Export(Credit credit, List<DueAmount> computedData)
    {
        _fileSystem.WriteText(_path, ToString(credit, computedData));
    }
}