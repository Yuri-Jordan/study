namespace calculadora.tests;

using calculadora;

public class CalculadoraTest
{
    private readonly Calculadora _sut = new(); // System Under Test
    private readonly Guid _guid = Guid.NewGuid();

    [Fact]
    public void Add_DeveSomar_DoisNumerosInteiros()
    {
        Assert.Equal(3, new Calculadora().Add(1, 2));
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
}
