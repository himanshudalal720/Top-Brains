using System;
class Program
{
    static string GetHeightCategory(int heightCm)
    {
        if (heightCm < 150)
            return "Short";
        else if (heightCm < 180)
            return "Average";
        else
            return "Tall";
    }

    static void Main()
    {
        int heightCm = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(GetHeightCategory(heightCm));
    }
}
