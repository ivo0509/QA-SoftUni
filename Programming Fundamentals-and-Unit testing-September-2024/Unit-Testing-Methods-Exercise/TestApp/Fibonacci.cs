using System;

namespace TestApp;

public class Fibonacci
{   
    public static int CalculateFibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
    }
}
