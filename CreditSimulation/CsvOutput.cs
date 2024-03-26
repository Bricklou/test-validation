namespace SimulationCredits;

public class CsvOutput
{
    private readonly string _path;

    public CsvOutput(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentNullException(nameof(path));

        _path = path;
    }

    public string ToString(Credit credit, List<DueAmount> computedData)
    {
        var output = $"{credit.TotalAmount}\n";
        output += computedData.Aggregate("", (current, dueAmount) => current + $"{dueAmount.Month},{dueAmount.PaidAmount},{dueAmount.RemainingAmount}\n");

        return output;
    }

    public void Export(Credit credit, List<DueAmount> computedData)
    {
        File.WriteAllText(_path, ToString(credit, computedData));
    }
}