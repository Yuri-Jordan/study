public class GuidClassFixture : IDisposable
{
    public GuidClassFixture()
    {
        Console.WriteLine($"Setup ctor: {nameof(GuidClassFixture)}");
    }

    public Guid Guid { get; set; } = Guid.NewGuid();

    public void Dispose()
    {
        Console.WriteLine($"Dispose: {nameof(GuidClassFixture)} - {Guid}");
    }
}