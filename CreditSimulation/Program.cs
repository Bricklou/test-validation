namespace SimulationCredits;

public class Program
{
    public static void Main(string[] args)
    {
        var parser = new ArgumentsParser();

        var credit = parser.Parse(args);
        var calculator = new CreditCalculator();

        var computedData = credit.ComputeDueAmounts(calculator);
        
        var output = new CsvOutput("credit.csv");
        output.Export(credit, computedData);
    }
}