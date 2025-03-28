namespace ContainersManagenement;

public class Ship
{
    private static int _idCounter = 1;
    private static List<Ship> _ships = new List<Ship>();

    public int ShipId { get; private set; }
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; }
    private List<Container> _containers;

    public Ship(double maxSpeed, int maxContainers, double maxWeight)
    {
        ShipId = _idCounter++;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        _containers = new List<Container>();

        _ships.Add(this);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void LoadContainer(Container container)
    {
        if (IsContainerLoadedOnOtherShip(container))
        {
            throw new InvalidOperationException("The container is already loaded on another ship.");
        }

        if (_containers.Count >= MaxContainers)
            throw new InvalidOperationException("The ship has reached its maximum number of containers.");

        if (_containers.Sum(c => c.countContainerWeight()) + container.countContainerWeight() > MaxWeight)
            throw new InvalidOperationException(
                "The total weight exceeds the maximum cargo weight allowed on the ship.");

        _containers.Add(container);
        Console.WriteLine($"\nContainer {container.SerialNumber} loaded onto the ship {ShipId}.");
    }

    public void UnloadContainer(Container container)
    {
        if (_containers.Contains(container))
        {
            _containers.Remove(container);
            Console.WriteLine($"Container {container.SerialNumber} removed from the ship {ShipId}.");
        }
        else
        {
            throw new InvalidOperationException($"The container is not present on the ship {ShipId}.");
        }
    }

    public void ReplaceContainer(Container oldContainer, Container newContainer)
    {
        if (_containers.Contains(oldContainer))
        {
            _containers.Remove(oldContainer);
            UnloadContainer(newContainer);
            Console.WriteLine(
                $"Container {oldContainer.SerialNumber} has been replaced with container {newContainer.SerialNumber}.");
        }
        else
        {
            throw new InvalidOperationException("The container to replace is not present on the ship.");
        }
    }

    public void TransferContainer(Ship targetShip, Container container)
    {
        this.UnloadContainer(container);
        targetShip.LoadContainer(container);
        Console.WriteLine($"Container {container.SerialNumber} has been transferred to ship {targetShip.ShipId}.");
    }

    private bool IsContainerLoadedOnOtherShip(Container container)
    {
        foreach (var ship in _ships)
        {
            if (ship != this && ship._containers.Any(c => c.SerialNumber == container.SerialNumber))
            {
                Console.WriteLine($"Container {container.SerialNumber} is already loaded on ship {ship.ShipId}.");
                return true;
            }
        }

        return false;
    }

    public string GetShipInfo()
    {
        double totalWeight = _containers.Sum(c => c.countContainerWeight());
        int containerCount = _containers.Count;

        return $"\nShip ID: {ShipId}\n" +
               $"Max Speed: {MaxSpeed} knots\n" +
               $"Max Containers: {MaxContainers}\n" +
               $"Max Weight: {MaxWeight} tons\n" +
               $"Current Containers: {containerCount}/{MaxContainers}\n" +
               $"Current Cargo Weight: {totalWeight} tons";
    }
}