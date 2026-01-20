using System;
class Program
{
    static double GetCircleArea(double radius)
    {
        double area = Math.PI * radius * radius;
        return Math.Round(area, 2, MidpointRounding.AwayFromZero);
    }
    static void Main()
    {
        double radius = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(GetCircleArea(radius));
    }
}
