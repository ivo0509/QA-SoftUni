// Input
int amountOfNylon = int.Parse(Console.ReadLine());
int amountOfPaint = int.Parse(Console.ReadLine());
int amountOfThinner = int.Parse(Console.ReadLine());
int hoursWork = int.Parse(Console.ReadLine());

// Calculations
double protectiveNylonPerMeter = 1.50;
double paintPricePerLitter = 14.50;
double thinnerPricePerLitter = 5;
double bagsPrice = 0.4;

double priceForNylon = (amountOfNylon + 2) * protectiveNylonPerMeter;
double priceForPaint = amountOfPaint * 1.1 * paintPricePerLitter;
double priceForThinner = amountOfThinner * thinnerPricePerLitter;

double priceForMaterials = priceForNylon + priceForPaint + priceForThinner + bagsPrice;

double priceForOneHourWork = priceForMaterials * 0.3;
double priceForWorkers = priceForOneHourWork * hoursWork;

double finalPrice = priceForMaterials + priceForWorkers;

// Output
Console.WriteLine(finalPrice);
