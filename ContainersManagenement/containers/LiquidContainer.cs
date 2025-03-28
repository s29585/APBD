namespace ContainersManagenement;

public class LiquidContainer : Container, IHazardNotifier
{
    private static int _idCounter = 1;
    public CargoType? LoadedCargoType { get; private set; }

    public LiquidContainer(double height, double depth, double tareWeight, double maxLoadCapacity)
        : base(height, depth, tareWeight, maxLoadCapacity)
    {
        LoadedCargoType = null;
    }

    protected override string GenerateSerialNumber()
    {
        return $"KON-L-{_idCounter++}";
    }

    public void NotifyHazard(string serialNumber, string message)
    {
        Console.WriteLine($"Hazard Alert: Container {serialNumber} - {message}");
    }

    public override void Load(double mass)
    {
        Load(mass, CargoType.NonHazardous);
    }

    public void Load(double mass, CargoType cargoType)
    {
        Console.WriteLine($"\nAttempting to load {mass} kg of cargo {cargoType}...");

        if (LoadMass != 0 && cargoType != LoadedCargoType)
        {
            throw new InvalidOperationException("Cannot change the cargo type after the container has been loaded.");
        }

        if (!LoadedCargoType.HasValue)
        {
            LoadedCargoType = cargoType;
        }

        double maxAllowedLoad = LoadedCargoType == CargoType.Hazardous
            ? MaxLoadCapacity * 0.5
            : MaxLoadCapacity * 0.9;

        if (!CanLoadMore(mass))
        {
            NotifyHazard(SerialNumber,
                "Attempted to load more than the allowed capacity for hazardous or non-hazardous material.");
            throw new OverfillException("Exceeded the container's maximum load capacity");
        }

        LoadMass += mass;
        Console.WriteLine(this);
    }

    public override void Unload()
    {
        Console.WriteLine("\nUnloading the container...");
        LoadMass = 0;
        LoadedCargoType = null;
        Console.WriteLine(this);
    }
}

public enum CargoType
{
    Hazardous,
    NonHazardous
}