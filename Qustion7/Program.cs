using System;

class Program
{
    static void SwapUsingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    static void SwapUsingOut(int x, int y, out int a, out int b)
    {
        a = y;
        b = x;
    }

    static void Main()
    {
        int num1 = 10;
        int num2 = 20;

        SwapUsingRef(ref num1, ref num2);
        Console.WriteLine(num1 + " " + num2);

        int p, q;
        SwapUsingOut(num1, num2, out p, out q);
        Console.WriteLine(p + " " + q);
    }
}
