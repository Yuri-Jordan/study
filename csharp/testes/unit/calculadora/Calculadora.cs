namespace calculadora;

public class Calculadora
{
    // Event triggered when any operation is executed
    public event EventHandler<string>? OperationExecuted;

    public int Add(int a, int b)
    {
        int result = a + b;
        OperationExecuted?.Invoke(this, $"Add: {a} + {b} = {result}");
        return result;
    }

    public int Subtract(int a, int b)
    {
        int result = a - b;
        OperationExecuted?.Invoke(this, $"Subtract: {a} - {b} = {result}");
        return result;
    }

    public int Multiply(int a, int b)
    {
        int result = a * b;
        OperationExecuted?.Invoke(this, $"Multiply: {a} * {b} = {result}");
        return result;
    }

    public double Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        double result = (double)a / b;
        OperationExecuted?.Invoke(this, $"Divide: {a} / {b} = {result}");
        return result;
    }
}