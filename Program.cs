using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            if (args.Length != 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello stranger :D");
            }


            // Data references
            double total = 0;
            double mean = 0;
            List<double> grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            grades.Add(56.1);


            // Generate the total of the grades
            foreach (var number in grades)
            {
                total += number;
            }

            // Calculates the avergage (total of the group of items / length of the items)
            mean = total / grades.Count;

            // Outputs the total
            Console.WriteLine(total);

            /*

            Formatting outputs notes:

            Resources:
            - https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

            Formatting options:

            - Math.round(yourValue, MidpointRounding.AwayFromZero)

            - yourValue.toString("N") - N, N[Number of decimal places e.g. 2, 4, 10 etc]

            */
            Console.WriteLine(Math.Round(mean, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine(mean.ToString("N"));
        }
    }
}
