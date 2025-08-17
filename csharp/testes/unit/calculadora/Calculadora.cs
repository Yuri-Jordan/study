namespace calculadora;

public class Calculadora
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public Calculadora(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
        var greet = GetGreetMessage();
        Console.WriteLine($"{greet}! Welcome to calculator: {nameof(Calculadora)}");
    }

    // Event triggered when any operation is executed
    public event EventHandler<string>? OperationExecuted;
    internal bool InternalMethodTest()
    {
        Console.WriteLine($"Internal method of: {nameof(Calculadora)}");
        return true;
    }

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

    public string GetGreetMessage()
    {
        var currentDate = _dateTimeProvider.DateTimeNow;
        return currentDate.Hour switch
        {
            >= 5 and < 12 => "Good Morning",
            >= 12 and < 18 => "Good Afternoom",
            _ => "Good Evening"
        };
    }
}