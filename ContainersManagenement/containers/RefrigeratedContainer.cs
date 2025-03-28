namespace ContainersManagenement
{
    public class RefrigeratedContainer : Container
    {
        private static int _idCounter = 1;
        public ProductType? StoredProductType { get; set; }
        private static readonly double Epsilon = 0.0001;

        private double _temperature;

        public double Temperature
        {
            get { return _temperature; }
            set
            {
                Console.WriteLine($"\nAttempting to set temperature {value}°C for container {SerialNumber}.");
                ValidateTemperature(value);
                _temperature = value;
                Console.WriteLine($"Temperature set to {_temperature}C.");
            }
        }

        private static readonly Dictionary<ProductType, double> ProductTemperature = new Dictionary<ProductType, double>
        {
            { ProductType.Bananas, 13.3 },
            { ProductType.Chocolate, 18.0 },
            { ProductType.Fish, 2.0 },
            { ProductType.Meat, -15.0 },
            { ProductType.IceCream, -18.0 },
            { ProductType.FrozenPizza, -30.0 },
            { ProductType.Cheese, 7.2 },
            { ProductType.Sausages, 5.0 },
            { ProductType.Butter, 20.5 },
            { ProductType.Eggs, 19.0 }
        };

        public RefrigeratedContainer(double height, double depth, double tareWeight, double maxLoadCapacity)
            : base(height, depth, tareWeight, maxLoadCapacity)
        {
            StoredProductType = null;
            Temperature = 0;
        }

        protected override string GenerateSerialNumber()
        {
            return $"KON-C-{_idCounter++}";
        }

        public void NotifyHazard(string serialNumber, string message)
        {
            Console.WriteLine($"Hazard Alert: Container {serialNumber} - {message}");
        }

        public override void Load(double mass)
        {
            if (StoredProductType == null)
            {
                throw new InvalidOperationException("Product type must be specified before loading.");
            }

            Load(mass, StoredProductType.Value);
        }

        public void Load(double mass, ProductType productType)
        {
            Console.WriteLine($"\nAttempting to load {mass} kg of {productType} at {Temperature}°C...");

            if (StoredProductType.HasValue && StoredProductType != productType)
            {
                throw new InvalidOperationException("Cannot store different types of products in the same container.");
            }

            ValidateTemperature(Temperature);

            if (!StoredProductType.HasValue)
            {
                StoredProductType = productType;
            }

            if (!CanLoadMore(mass))
            {
                NotifyHazard(SerialNumber,
                    "Attempted to load more than the maximum capacity for refrigerated container.");
                throw new OverfillException("Exceeded the container's maximum load capacity");
            }

            LoadMass += mass;
            Console.WriteLine(this);
        }

        public override void Unload()
        {
            Console.WriteLine("\nUnloading the container...");
            LoadMass = 0;
            StoredProductType = null;
            Temperature = 0;
            Console.WriteLine(this);
        }
        
        private void ValidateTemperature(double temperature)
        {
            if (StoredProductType.HasValue)
            {
                var requiredTemperature = ProductTemperature[StoredProductType.Value];
                if (Math.Abs(temperature - requiredTemperature) > Epsilon)
                {
                    throw new InvalidOperationException(
                        $"Temperature not suitable for {StoredProductType}. Required: {requiredTemperature}°C.");
                }
            }
        }
    }

    public enum ProductType
    {
        Bananas,
        Chocolate,
        Fish,
        Meat,
        IceCream,
        FrozenPizza,
        Cheese,
        Sausages,
        Butter,
        Eggs
    }
}