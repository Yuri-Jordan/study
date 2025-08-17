using calculadora;

class Program
{
    static void Main()
    {
        var dateTimeProvider = new DateTimeProvider();
        var calc = new Calculadora(dateTimeProvider);

        // Subscribe to the event
        calc.OperationExecuted += (sender, msg) => Console.WriteLine($"Event: {msg}");

        // Use calculator methods
        calc.Add(2, 3);
        calc.Subtract(5, 1);
        calc.Multiply(3, 4);
        calc.Divide(10, 2);
    }
}