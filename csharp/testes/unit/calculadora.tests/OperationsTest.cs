namespace calculadora.tests;

using calculadora;
using FluentAssertions;

public class OperationsTest : IAsyncLifetime
{
    // Arrange
    // The System Under Test (SUT) is the instance of the class being tested.
    private readonly Operation _sut = new();
    private readonly Guid _guid = Guid.NewGuid();

    public OperationsTest()
    {
        Console.WriteLine($"Setup ctor: {nameof(OperationsTest)}");
    }

    [Fact]
    public void OperationsObjects_MustBe_Equals()
    {
        var expected = new Operation()
        {
            Operand1 = 2,
            Operand2 = 2,
            OperationType = OperationType.Add
        };

        _sut.GetOp4Test().Should().BeEquivalentTo(expected);
    }

    public async Task InitializeAsync()
    {
        Console.WriteLine($"Setup InitializeAsync: {nameof(OperationsTest)}");
        await Task.Delay(300); // Simulating async setup work
    }

    public async Task DisposeAsync()
    {
        Console.WriteLine($"Teardown DisposeAsync: {nameof(OperationsTest)}");
        await Task.Delay(300); // Simulating async teardown work
    }
}
