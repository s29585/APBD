namespace ContainersManagenement;

public class GasContainer : Container, IHazardNotifier
{
    private static int _idCounter = 1;
    public double Pressure { get; set; }

    public GasContainer(double height, double depth, double tareWeight, double maxLoadCapacity)
        : base(height, depth, tareWeight, maxLoadCapacity)
    {
    }

    protected override string GenerateSerialNumber()
    {
        return $"KON-G-{_idCounter++}";
    }

    public void NotifyHazard(string serialNumber, string message)
    {
        Console.WriteLine($"Hazard Alert: Container {serialNumber} - {message}");
    }

    public override void Load(double mass)
    {
        Console.WriteLine($"\nAttempting to load {mass} kg of gas...");

        if (!CanLoadMore(mass))
        {
            NotifyHazard(SerialNumber, "Attempted to load more than the maximum capacity for gas container.");
            throw new OverfillException("Exceeded the container's maximum load capacity");
        }

        LoadMass += mass;
        Console.WriteLine(this);
    }

    public override void Unload()
    {
        Console.WriteLine("\nUnloading the container...");
        LoadMass = LoadMass * 0.05;
        NotifyHazard(SerialNumber, "Gas container has been unloaded. 5% of the load is retained.");
        Console.WriteLine(this);
    }
}