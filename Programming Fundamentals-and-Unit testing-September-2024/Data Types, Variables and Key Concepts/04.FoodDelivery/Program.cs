// Input
int numberOfChickenMenus = int.Parse(Console.ReadLine());
int numberOfFishMenus = int.Parse(Console.ReadLine());
int numberOfVegetarianMenus = int.Parse(Console.ReadLine());

// Calculations
double priceForOneChickenMenu = 10.35;
double priceForOneFishMenu = 12.40;
double priceForOneVegetarianMenu = 8.15;
double deliveryPrice = 2.50;

double priceForAllChickenMenus = priceForOneChickenMenu * numberOfChickenMenus;
double priceForaAllFishMenus = priceForOneFishMenu * numberOfFishMenus;
double priceForAllVegetarianMenus = priceForOneVegetarianMenu * numberOfVegetarianMenus;

double orderPrice = priceForAllChickenMenus + priceForaAllFishMenus + priceForAllVegetarianMenus;

double priceForDessert = orderPrice * 0.2;

double finalPrice = orderPrice + priceForDessert + deliveryPrice;

// Output
Console.WriteLine(finalPrice);