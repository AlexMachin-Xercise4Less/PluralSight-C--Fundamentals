using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creates a book object
            var book = new Book();

            // Adds the grades to the Book's grades List
            book.AddGrade(56.1);
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(60);

            /*

              Formatting outputs notes:

              Resources:
              - https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

              Formatting options:

              - Math.round(yourValue, MidpointRounding.AwayFromZero)

              - yourValue.toString("N") - N, N[Number of decimal places e.g. 2, 4, 10 etc]

            */

            double total = book.getTotal();
            Console.WriteLine($"The total for the grades are {total}");

            double average = book.getAverage(total);
            Console.WriteLine($"The average grade is {average.ToString("N2")}");

            double lowestValue = book.getLowestGrade();
            Console.WriteLine($"The lowest grade is {lowestValue}");

            double highestGrade = book.getHighestGrade();
            Console.WriteLine($"The highest grade is {highestGrade}");
        }
    }
}
