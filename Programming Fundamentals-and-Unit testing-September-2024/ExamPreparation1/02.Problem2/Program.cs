
int[] numbers = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

int rightMiddleIndex = numbers.Length / 2;
int leftMiddleIndex = numbers.Length / 2 - 1;

int sum = numbers[leftMiddleIndex] + numbers[rightMiddleIndex];
double average = sum / 2.0;

Console.WriteLine($"{average:F2}");
