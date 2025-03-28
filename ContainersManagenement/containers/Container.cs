namespace ContainersManagenement;

public abstract class Container
{
    public double TareWeight { get; }
    public double Height { get; }
    public double Depth { get; }
    public double MaxLoadCapacity { get; }
    public double LoadMass { get; set; }
    public string SerialNumber { get; }

    public Container(double height, double depth, double tareWeight, double maxLoadCapacity)
    {
        Height = height;
        Depth = depth;
        TareWeight = tareWeight;
        MaxLoadCapacity = maxLoadCapacity;
        LoadMass = 0;
        SerialNumber = GenerateSerialNumber();
    }

    protected abstract string GenerateSerialNumber();
    public abstract void Load(double mass);
    public abstract void Unload();
    
    public bool CanLoadMore(double mass)
    {
        return mass + LoadMass <= MaxLoadCapacity;
    }

    public double countContainerWeight()
    {
        return TareWeight + LoadMass;
    }

    public override string ToString()
    {
        return $"{SerialNumber}: {LoadMass}/{MaxLoadCapacity} kg";
    }
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}

public interface IHazardNotifier
{
    void NotifyHazard(string serialNumber, string message);
}