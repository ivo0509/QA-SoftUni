
List<Box> boxes = new List<Box>();

string[] input = Console.ReadLine().Split();

while (input[0] != "end")
{
    string serialNumber = input[0];
    string itemName = input[1];
    int itemsQuantity = int.Parse(input[2]);
    double itemPrice = double.Parse(input[3]);

    Item currentItem = new Item(itemName, itemPrice);
    Box currentBox = new Box(serialNumber, currentItem, itemsQuantity);

    boxes.Add(currentBox);

    input = Console.ReadLine().Split();
}

foreach (Box box in boxes.OrderByDescending(b => b.PriceOfTheBox))
{
    Console.WriteLine(box.SerialNumber);
    Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
    Console.WriteLine($"-- ${box.PriceOfTheBox:F2}");
}

class Item
{

    public Item(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public double Price { get; set; }
}

class Box
{
    public Box(string serialNumber, Item item, int quantity)
    {
        SerialNumber = serialNumber;
        Item = item;
        ItemQuantity = quantity;
    }

    public string SerialNumber { get; set; }

    public Item Item { get; set; }

    public int ItemQuantity { get; set; }

    public double PriceOfTheBox => ItemQuantity * Item.Price;
}