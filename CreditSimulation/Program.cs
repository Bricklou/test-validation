namespace SimulationCredits;

public class Program
{
    public static void Main(string[] args)
    {
        var parser = new ArgumentsParser();

        var credit = parser.Parse(args);
        var calculator = new CreditCalculator();

        var monthlyPayment = calculator.Calculate(credit);
        var computedData = credit.ComputeDueAmounts(calculator);
        
        var output = new CsvOutput("credit.csv");
    }
}