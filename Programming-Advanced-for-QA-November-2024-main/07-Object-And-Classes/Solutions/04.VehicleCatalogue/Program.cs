
Catalog myCatalog = new Catalog(); 

string[] input = Console.ReadLine().Split('/');

while (input[0] != "end")
{
    string typeOfVehicle = input[0];
    string brand = input[1];
    string model = input[2];

    if (typeOfVehicle == "Car")
    {
        int horsePower = int.Parse(input[3]);
        Car currentCar = new Car(brand, model, horsePower);
        myCatalog.Cars.Add(currentCar);
    }
    else if (typeOfVehicle == "Truck")
    {
        int weight = int.Parse(input[3]);
        Truck currentTruck = new Truck(brand, model, weight);
        myCatalog.Trucks.Add(currentTruck);
    }

    input = Console.ReadLine().Split('/');
}

if (myCatalog.Cars.Count > 0)
{
    Console.WriteLine("Cars:");

    foreach (Car car in myCatalog.Cars.OrderBy(c => c.Brand))
    {
        Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
    }
}

if (myCatalog.Trucks.Count > 0)
{
    Console.WriteLine("Trucks:");

    foreach (Truck truck in myCatalog.Trucks.OrderBy(t => t.Brand))
    {
        Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
    }
}

class Truck
{
    public Truck(string brand, string model, int weight)
    {
        Brand = brand;
        Model = model;
        Weight = weight;
    }

    public string Brand { get; set; }

    public string Model { get; set; }

    public int Weight { get; set; }

}

class Car
{
    public Car(string brand, string model, int horsePower)
    {
        Brand = brand;
        Model = model;
        HorsePower = horsePower;
    }

    public string Brand { get; set; }

    public string Model { get; set; }

    public int HorsePower { get; set; }

}

class Catalog
{
    public Catalog()
    {
        Cars = new List<Car>();
        Trucks = new List<Truck>();
    }

    public List<Car> Cars { get; set; }

    public List<Truck> Trucks { get; set; }
}
