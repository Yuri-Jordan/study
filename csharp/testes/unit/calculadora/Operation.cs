namespace calculadora;

public class Operation
{
    public int Operand1 { get; set; }
    public int Operand2 { get; set; }
    public OperationType OperationType { get; set; }

    public Operation GetOp4Test()
    {
        return new Operation
        {
            Operand1 = 2,
            Operand2 = 2,
            OperationType = OperationType.Add
        };
    }
}