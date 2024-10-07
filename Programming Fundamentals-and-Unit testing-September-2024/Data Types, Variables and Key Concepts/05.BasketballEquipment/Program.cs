// Input
int basketballFeeForOneYEar = int.Parse(Console.ReadLine());

// Calculations
double priceForSneakers = basketballFeeForOneYEar * 0.6; // -40%
double priceForUniform = priceForSneakers * 0.8;         // -20%
double priceForBall = priceForUniform / 4;
double priceForAccessories = priceForBall / 5;

double finalPrice = basketballFeeForOneYEar + priceForSneakers + priceForUniform + priceForBall + priceForAccessories;

// Output
Console.WriteLine(finalPrice);
