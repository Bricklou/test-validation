namespace SimulationCredits;

public class CsvOutput
{
    public CsvOutput(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentNullException(nameof(path));
    public string ToString(Credit credit, List<DueAmount> computedData)
    {
        var output = $"{credit.TotalAmount}\n";
        output += computedData.Aggregate("", (current, dueAmount) => current + $"{dueAmount.Month},{dueAmount.PaidAmount},{dueAmount.RemainingAmount}\n");

        return output;
    }
    }
}