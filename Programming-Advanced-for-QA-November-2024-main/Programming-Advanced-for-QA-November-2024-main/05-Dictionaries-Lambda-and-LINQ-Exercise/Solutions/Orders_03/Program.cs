//продукт -> ед. цена
Dictionary<string, double> productsPrice = new Dictionary<string, double>();

//продукт -> количество
Dictionary<string, int> productsQuantity = new Dictionary<string, int>();

//входни данни
string input = Console.ReadLine();

while (input != "buy")
{
    //input = "{name} {price} {quantity}"
    //input = "Beer 2.20 100".Split(" ") -> ["Beer", "2.20", "100"]

    string[] productData = input.Split(" ");
    string productName = productData[0]; //"Beer"
    double price = double.Parse(productData[1]); //"2.20" -> 2.20
    int quantity = int.Parse(productData[2]); //"100" -> 100

    //вече сме срещали такъв продукт
    if (productsPrice.ContainsKey(productName) && productsQuantity.ContainsKey(productName))
    {
        //заменяме текущата ед. цена на продукта с новата въведена
        productsPrice[productName] = price;

        //увеличаваме наличното количество с новото
        productsQuantity[productName] += quantity;
    }
    //не сме срещали такъв продукт
    else
    {
        productsPrice.Add(productName, price);
        productsQuantity.Add(productName, quantity);
    }

    input = Console.ReadLine();
}

//productsPrice: key(product) -> value(price)
//productsQuantity: key(product) -> value(quantity)

foreach(KeyValuePair<string, double> entry in productsPrice)
{
    //всеки един запис се съхранява в променлива entry
    //entry.Key -> име на продукта
    //entry.Value -> ед. цена на продукта
    string productName = entry.Key;
    double productPrice = entry.Value;
    int quantity = productsQuantity[productName];
    double totalPrice = productPrice * quantity;

    Console.WriteLine($"{productName} -> {totalPrice:F2}");
}


