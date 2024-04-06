using SimulationCredits;

namespace SimulationCreditsTest;

public class CsvOutputTest
{
    private const string CsvPath = "credit.csv";

    private const string ExpectedCsv =
        "200000\n1,40000,160000\n2,40000,120000\n3,40000,80000\n4,40000,40000\n5,40000,0\n";

    private static readonly Credit FakeCredit = new(200_000, 15 * 12, 2);

    private static readonly List<DueAmount> FakeAmounts =
    [
        new DueAmount(1, 40_000, FakeCredit.TotalAmount - 40_000 * 1),
        new DueAmount(2, 40_000, FakeCredit.TotalAmount - 40_000 * 2),
        new DueAmount(3, 40_000, FakeCredit.TotalAmount - 40_000 * 3),
        new DueAmount(4, 40_000, FakeCredit.TotalAmount - 40_000 * 4),
        new DueAmount(5, 40_000, FakeCredit.TotalAmount - 40_000 * 5)
    ];

    [Fact]
    public void CsvOutput_Should_ThrowError_When_Path_Is_Null()
    {
        var fileSystem = new FakeFileSystem();
        Assert.Throws<ArgumentNullException>(() => new CsvOutput(null, fileSystem));
    }

    [Fact]
    public void CsvOutput_Should_ThrowError_When_Path_Is_Empty()
    {
        var fileSystem = new FakeFileSystem();
        Assert.Throws<ArgumentNullException>(() => new CsvOutput("", fileSystem));
    }

    [Fact]
    public void CsvOutput_Serialize_ToString()
    {
        var fileSystem = new FakeFileSystem();

        var output = new CsvOutput(CsvPath, fileSystem);
        var csv = output.ToString(FakeCredit, FakeAmounts);

        Assert.NotEmpty(csv);
        Assert.Equal(ExpectedCsv, csv);
    }

    [Fact]
    public void CsvOutput_Should_Export_Csv()
    {
        var fileSystem = new FakeFileSystem();
        var output = new CsvOutput(CsvPath, fileSystem);
        output.Export(FakeCredit, FakeAmounts);

        Assert.True(fileSystem.Exists(CsvPath));
    }

    [Fact]
    public void CsvOutput_Should_Export_Csv_With_Expected_Values()
    {
        var fileSystem = new FakeFileSystem();
        var output = new CsvOutput(CsvPath, fileSystem);
        output.Export(FakeCredit, FakeAmounts);

        var csv = File.ReadAllText(CsvPath);

        Assert.NotEmpty(csv);
        Assert.Equal(ExpectedCsv, csv);
    }
}