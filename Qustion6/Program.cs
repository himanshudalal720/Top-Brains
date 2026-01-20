using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        Dictionary<int, int> salaries = new Dictionary<int, int>()
        {
            {1,20000},
            {4,40000},
            {5,15000}
        };
        List<int> employeeIds = new List<int>() { 1, 4, 5 };
        int totalSalary = employeeIds
            .Where(id => salaries.ContainsKey(id))
            .Sum(id => salaries[id]);
        Console.WriteLine(totalSalary);
    }
}
