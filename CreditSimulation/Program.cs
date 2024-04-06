namespace SimulationCredits;

public class Program
{
    public static void Main(string[] args)
    {
        var parser = new ArgumentsParser();

        var credit = parser.Parse(args);
        var calculator = new CreditComputer();

        var computedData = credit.ComputeDueAmounts(calculator);

        var fileSystem = new FileSystem();
        var output = new CsvOutput("credit.csv", fileSystem);
        output.Export(credit, computedData);
    }
}