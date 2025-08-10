namespace calculadora.tests;
using calculadora;

public class CalculadoraTest
{
    [Fact]
    public void Add_DeveSomar_DoisNumerosInteiros()
    {
        Assert.Equal(3, new Calculadora().Add(1, 2));
    }
}
