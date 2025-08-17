namespace calculadora.tests;

using calculadora;
using FluentAssertions;
using Xunit;
using NSubstitute;

[Collection("GuidCollectionFixture")]
public class CalculadoraTest : IAsyncLifetime
{
    // Arrange
    // The System Under Test (SUT) is the instance of the class being tested.
    private readonly Calculadora _sut;
    private readonly Guid _guid = Guid.NewGuid();
    private readonly GuidClassFixture _fixture;
    private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();

    public CalculadoraTest(GuidClassFixture fixture)
    {
        _sut = new Calculadora(_dateTimeProvider);
        _fixture = fixture;
        Console.WriteLine($"Setup ctor: {nameof(CalculadoraTest)}");
    }

    [Fact]
    public void Add_DeveSomar_DoisNumerosInteiros()
    {
        Assert.Equal(3, _sut.Add(1, 2));
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
    public void Guid_MustBeEqual_ForEachTestInFixture1()
    {
        Console.WriteLine($"Guid fixture 1: {_fixture.Guid}");
    }

    [Fact]
    public void Guid_MustBeEqual_ForEachTestInFixture2()
    {
        Console.WriteLine($"Guid fixture 2: {_fixture.Guid}");
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

    [Fact]
    public void Test_Internals()
    {
        var result = _sut.InternalMethodTest();
        result.Should().BeTrue();
    }

    [Fact(Timeout = 2000)]
    public async Task Test_Timeout()
    {
        await Task.Delay(3000);
    }

    [Fact]
    public void GetGreetMessage_MustGenerateGoodMorning_InMorning()
    {
        var morningDate = new DateTime(2025, 8, 17, 5, 0, 0);
        _dateTimeProvider.DateTimeNow.Returns(morningDate);
        var result = _sut.GetGreetMessage();
        result.Should().Be("Good Morning");
    }

    [Fact]
    public void GetGreetMessage_MustGenerateGoodAfternoom_InAfternoom()
    {
        var morningDate = new DateTime(2025, 8, 17, 12, 0, 0);
        _dateTimeProvider.DateTimeNow.Returns(morningDate);
        var result = _sut.GetGreetMessage();
        result.Should().Be("Good Afternoom");
    }

    [Fact]
    public void GetGreetMessage_MustGenerateGoodEvening_InEvening()
    {
        var morningDate = new DateTime(2025, 8, 17, 18, 0, 0);
        _dateTimeProvider.DateTimeNow.Returns(morningDate);
        var result = _sut.GetGreetMessage();
        result.Should().Be("Good Evening");
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
