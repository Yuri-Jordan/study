namespace calculadora.tests;

using calculadora;

public class CalculadoraTest : IAsyncLifetime
{
    private readonly Calculadora _sut = new(); // System Under Test
    private readonly Guid _guid = Guid.NewGuid();

    public CalculadoraTest()
    {
        Console.WriteLine($"Setup ctor: {nameof(CalculadoraTest)}");
    }

    [Fact]
    public void Add_DeveSomar_DoisNumerosInteiros()
    {
        Assert.Equal(3, new Calculadora().Add(1, 2));
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(5, 0, 5)]
    [InlineData(1, 90, 91)]
    public void Add_DeveSomar_DoisNumerosInteiros_Theory(int a, int b, int expected)
    {
        Assert.Equal(expected, new Calculadora().Add(a, b));
    }

    [Fact]
    public void Guid_MustBeDifferente_ForEachFact1()
    {
        Console.WriteLine($"Guid 1: {_guid}");
    }

    [Fact]
    public void Guid_MustBeDifferente_ForEachFact2()
    {
        Console.WriteLine($"Guid 2: {_guid}");
    }

    public async Task InitializeAsync()
    {
        Console.WriteLine($"Setup InitializeAsync");
        await Task.Delay(300); // Simulating async setup work
    }

    public async Task DisposeAsync()
    {
        Console.WriteLine($"Teardown DisposeAsync");
        await Task.Delay(300); // Simulating async teardown work
    }
}
