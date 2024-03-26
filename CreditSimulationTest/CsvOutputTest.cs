using SimulationCredits;

namespace SimulationCreditsTest;

public class CsvOutputTest
{
    private const string CsvPath = "credit.csv";
    private static readonly Credit FakeCredit = new Credit(200_000, 15 * 12, 2);
    private static readonly List<DueAmount> FakeAmounts =
    [
        new DueAmount(1, 40_000, FakeCredit.TotalAmount - 40_000 * 1),
        new DueAmount(2, 40_000, FakeCredit.TotalAmount - 40_000 * 2),
        new DueAmount(3, 40_000, FakeCredit.TotalAmount - 40_000 * 3),
        new DueAmount(4, 40_000, FakeCredit.TotalAmount - 40_000 * 4),
        new DueAmount(5, 40_000, FakeCredit.TotalAmount - 40_000 * 5)
    ];

    private const string ExpectedCsv = "200000\n1,40000,160000\n2,40000,120000\n3,40000,80000\n4,40000,40000\n5,40000,0\n";

    [Fact]
    public void CsvOutput_Should_ThrowError_When_Path_Is_Null()
    {
        Assert.Throws<ArgumentNullException>(() => new CsvOutput(null));
    }

    [Fact]
    public void CsvOutput_Should_ThrowError_When_Path_Is_Empty()
    {
        Assert.Throws<ArgumentNullException>(() => new CsvOutput(""));
    }

    [Fact]
    public void CsvOutput_Serialize_ToString()
    {
        var output = new CsvOutput("credit.csv");
        var csv = output.ToString(FakeCredit, FakeAmounts);

        Assert.NotEmpty(csv);
        Assert.Equal(ExpectedCsv, csv);
    }
