namespace calculadora.tests;

using calculadora;
using FluentAssertions;

public class CalculadoraTest : IAsyncLifetime
{
    // Arrange
    // The System Under Test (SUT) is the instance of the class being tested.
    private readonly Calculadora _sut = new();
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
    [InlineData(1, 90, 91, Skip = "This InlineData's test is skipped for demonstration purposes.")]
    public void Add_DeveSomar_DoisNumerosInteiros_Theory(int a, int b, int expected)
    {
        // Act & Assert
        var result = _sut.Add(a, b);

        result.Should().Be(expected);
    }

    [Fact(Skip = "This test is skipped for demonstration purposes.")]
    public void Guid_MustBeDifferente_ForEachFact1()
    {
        Console.WriteLine($"Guid 1: {_guid}");
    }

    [Fact]
    public void Guid_MustBeDifferente_ForEachFact2()
    {
        Console.WriteLine($"Guid 2: {_guid}");
    }

    [Fact]
    public void Divide_MustThrow_DivideByZeroException_When_DividendEqualsZero()
    {
        Action result = () => _sut.Divide(10, 0);
        result.Should().Throw<DivideByZeroException>();
    }

    [Fact]
    public void Add_MustRaise_Event()
    {
        var eventWatcher = _sut.Monitor();
        _sut.Add(10, 10);

        eventWatcher
            .Should()
            .Raise(nameof(Calculadora.OperationExecuted));
    }

    public async Task InitializeAsync()
    {
        Console.WriteLine($"Setup InitializeAsync: {nameof(CalculadoraTest)}");
        await Task.Delay(300); // Simulating async setup work
    }

    public async Task DisposeAsync()
    {
        Console.WriteLine($"Teardown DisposeAsync: {nameof(CalculadoraTest)}");
        await Task.Delay(300); // Simulating async teardown work
    }
}
