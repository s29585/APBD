using ContainersManagenement;

class Program
{
    static void Main()
    {
        // liquid containters
       //
       //  var liquidContainer = new LiquidContainer(300, 500, 1500, 10000);
       //  
       //  Console.WriteLine("Initial state:");
       //  Console.WriteLine(liquidContainer);
       //  
       //  liquidContainer.Load(4000);
       //  
       //  try
       //  {
       //      liquidContainer.Load(6000, CargoType.Hazardous);
       //  }
       //  catch (Exception ex)
       //  {
       //      Console.WriteLine($"Error: {ex.Message}");
       //  }
       //  
       //  liquidContainer.Unload();
       //  
       //  liquidContainer.Load(3000, CargoType.Hazardous);
       //  
       //  try
       //  {
       //      liquidContainer.Load(3000, CargoType.Hazardous);
       //  }
       //  catch (Exception ex)
       //  {
       //      Console.WriteLine($"Error: {ex.Message}");
       //  }
       //  
       //  try
       //  {
       //      liquidContainer.Load(9500); 
       //  }
       //  catch (Exception ex)
       //  {
       //      Console.WriteLine($"Error: {ex.Message}");
       //  }
       //  
       //  // // gas containers
       //  
       //  var gasContainer = new GasContainer(300, 500, 1500, 10000);
       //  gasContainer.Pressure = 5;
       //  
       //  Console.WriteLine("\nInitial state:");
       //  Console.WriteLine(gasContainer);
       //  
       //  gasContainer.Load(8000);
       //  
       //  try
       //  {
       //      gasContainer.Load(4000);
       //  }
       //  catch (Exception ex)
       //  {
       //      Console.WriteLine($"Error: {ex.Message}");
       //  }
       //  
       //  gasContainer.Unload();
       //  
       //  try
       //  {
       //      gasContainer.Load(12000);
       //  }
       //  catch (Exception ex)
       //  {
       //      Console.WriteLine($"Error: {ex.Message}");
       //  }
       //
       //  // refrigerated containers
       //  
       // var refrigeratedContainer = new RefrigeratedContainer(100, 100, 100, 1000);
       //      Console.WriteLine("Initial state:");
       //      Console.WriteLine(refrigeratedContainer);
       //      
       //      refrigeratedContainer.StoredProductType = ProductType.Bananas;
       //      refrigeratedContainer.Temperature = 13.3;
       //
       //      try
       //      {
       //          refrigeratedContainer.Temperature = 10.0;
       //      }
       //      catch (InvalidOperationException ex)
       //      {
       //          Console.WriteLine($"Błąd: {ex.Message}");
       //      }
       //
       //      refrigeratedContainer.Load(50);
       //
       //      refrigeratedContainer.Unload();
       //
       //      refrigeratedContainer.StoredProductType = ProductType.Bananas;
       //      refrigeratedContainer.Temperature = 13.3;
       //      refrigeratedContainer.Load(50);
       //      
       //      try
       //      {
       //          refrigeratedContainer.Load(30, ProductType.Chocolate); 
       //      }
       //      catch (InvalidOperationException ex)
       //      {
       //          Console.WriteLine($"Błąd: {ex.Message}");
       //      }
       //
       //      try
       //      {
       //          var container2 = new RefrigeratedContainer(100, 100, 100, 1000);
       //          container2.StoredProductType = ProductType.Bananas;
       //          container2.Load(50);
       //      }
       //      catch (InvalidOperationException ex)
       //      {
       //          Console.WriteLine($"Błąd: {ex.Message}");
       //      }
            
            // managing containers
            
            var liquidContainer1 = new LiquidContainer(2.5, 2.5, 1000, 5000);
            liquidContainer1.Load(1500);

            var liquidContainer2 = new LiquidContainer(2.7, 3.0, 1200, 6000);
            liquidContainer2.Load(2000, CargoType.Hazardous);

            var liquidContainer3 = new LiquidContainer(3.0, 2.8, 1100, 5500);
            liquidContainer3.Load(1800);
            
            var gasContainer1 = new GasContainer(2.5, 2.5, 800, 4000);
            gasContainer1.Pressure = 50;
            gasContainer1.Load(1200);

            var gasContainer2 = new GasContainer(2.7, 3.0, 950, 4500);
            gasContainer2.Pressure = 60;
            gasContainer2.Load(1600);

            var gasContainer3 = new GasContainer(3.0, 2.8, 900, 4200);
            gasContainer3.Pressure = 55;
            gasContainer3.Load(1400);
            
            var refrigeratedContainer1 = new RefrigeratedContainer(2.5, 2.5, 1000, 5000);
            refrigeratedContainer1.StoredProductType = ProductType.Bananas;
            refrigeratedContainer1.Temperature = 13.3;
            refrigeratedContainer1.Load(1500);

            var refrigeratedContainer2 = new RefrigeratedContainer(2.7, 3.0, 1200, 6000);
            refrigeratedContainer2.StoredProductType = ProductType.Meat;
            refrigeratedContainer2.Temperature = -15.0;
            refrigeratedContainer2.Load(2000);

            var refrigeratedContainer3 = new RefrigeratedContainer(3.0, 2.8, 1100, 5500);
            refrigeratedContainer3.StoredProductType = ProductType.IceCream;
            refrigeratedContainer3.Temperature = -18.0;
            refrigeratedContainer3.Load(1800);
            
            var ship1 = new Ship(25.0, 100, 100000);
            var ship2 = new Ship(20.0, 80, 80000);
            
            ship1.LoadContainer(liquidContainer1);
            ship1.LoadContainer(gasContainer1);
            ship1.LoadContainer(refrigeratedContainer1);

            Console.WriteLine(ship1.GetShipInfo());

            ship2.LoadContainer(gasContainer2);
            ship2.LoadContainer(refrigeratedContainer2);
            
            Console.WriteLine(ship2.GetShipInfo());

            ship1.TransferContainer(ship2, gasContainer1);

            Console.WriteLine(ship1.GetShipInfo());
            Console.WriteLine(ship2.GetShipInfo());

            ship2.UnloadContainer(gasContainer2);

            Console.WriteLine(ship2.GetShipInfo());

    }

// pyatnia
// czy nie mozna interfejsu jakos jednak zaimplementowac skoro robi to samo?
// czy można jakoś częsciowo przeciążyć metody - ostatecznie część wspólna jest
}