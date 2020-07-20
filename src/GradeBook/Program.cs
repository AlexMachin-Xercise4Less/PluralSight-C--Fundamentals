using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creates a book object with a unique id
            var book = new Book("Grade");

            // Constantly loops until q is typed
            while(true) {

                // Print out a user message
                Console.WriteLine("Enter the grade or 'q' to quite");
                
                // Reads the users console input
                var input = Console.ReadLine();

                // Exits the programme flow
                if(input == "q") 
                {
                    break;
                }

                // When an error occurs it throes an error to one of the catch blocks defined below
                try {
                    var grade = double.Parse(input);                
                    book.AddGrade(grade);
                }

                // Checks for a formatting exception (Formatting error e.g. ffggsasdsa or qwqeqqeq)
                catch(FormatException ex) {
                   Console.WriteLine(ex.Message);
                } 

                // Checks for expections which haven't been accounted for 
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }

                // Will always run, even if the grade is successfully added
                finally {
                    Console.WriteLine("Will execute regardless.........");
                }
            }


            // When the total is not 0 print out the results
            if(book.GetTotal() != 0) {
            /*

              Formatting outputs notes:

              Resources:
              - https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

              Formatting options:

              - Math.round(yourValue, MidpointRounding.AwayFromZero)

              - yourValue.toString("N") - N, N[Number of decimal places e.g. 2, 4, 10 etc]

            */


            Console.WriteLine(book.Name);

            double total = book.GetTotal();
            Console.WriteLine($"The total for the grades are {total}");

            double average = book.GetAverage(total);
            Console.WriteLine($"The average grade is {average.ToString("N2")}");

            double lowestValue = book.GetLowestGrade();
            Console.WriteLine($"The lowest grade is {lowestValue}");

            double highestGrade = book.GetHighestGrade();
            Console.WriteLine($"The highest grade is {highestGrade}");
            }
        }
    }
}
