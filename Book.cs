using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Book
    {

        // Creates the Book's private fields
        private List<double> grades;

        // Initializes the class variables
        public Book()
        {
            grades = new List<double>() { };
        }

        public void AddGrade(double grade)
        {
            // Pushes the item to the grades array
            grades.Add(grade);
        }

        public double getTotal()
        {
            double total = 0;

            // Loop through the array and add the number value to the total
            foreach (var number in grades)
            {
                total += number;
            }

            // Return the total (295.7)
            return total;
        }

        public double getAverage(double total)
        {
            // total number of items / count
            double average = total / grades.Count;

            // Return the average (73.92)
            return average;
        }

        public double getHighestGrade()
        {
            // Gets the lowest precision double value possible
            var highestGrade = double.MinValue;

            // Iterates over the grades and compares the current grade to the highest grade
            foreach (var number in grades)
            {
                // When the current number is higher than the highestGrade update the highestGrade with the current number
                if (number > highestGrade)
                {
                    highestGrade = number;
                }
            }

            // Return the highest grade (90.5)
            return highestGrade;
        }

        public double getLowestGrade()
        {
            // Gets the highest precision double value possible
            var lowestGrade = double.MaxValue;

            // Iterates over the grades and compares the current grade to the lowest grade
            foreach (var number in grades)
            {
                // When the current number is lower than the lowestGrade update the lowestGrade with the current number
                if (number < lowestGrade)
                {
                    lowestGrade = number;
                }
            }

            // Return the lowest grade (56.1)
            return lowestGrade;
        }
    }
}