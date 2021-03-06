using System.Collections.Generic;
using System;

namespace GradeBook
{

    // An event - notification
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public delegate void GradeAddedDelegateException(object sender, EventArgs args);

    public class Book
    {
        // Creates the Book's private fields
        private List<double> grades;
        // public string Name;

        public string Name { get; set; }

        // Initializes the class variables
        public Book(string name)
        {
            grades = new List<double>() { };
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100) {
                // Pushes the item to the grades array
                grades.Add(grade);

                // When the programme is listening set a notification (Triggers success message)
                // book.GradeAdded += OnGradeAdded (Must be a static method as the program.cs main is a static member)
                if(GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }

            } else {

                // When the programme is listening and an error has occurred send a notification (Triggers error message)
                // book.GradeAddedError += OnGradeAddedError (Must be a static method as the program.cs main is a static member)
                if(GradeAddedError != null) {
                    GradeAddedError(this, new EventArgs());
                }

                // Throws an ArgumentException (Will be caught by the try/catch block in Progam.cs)
                throw new ArgumentException("Invalid Grade: Please enter a grade between 0 and 100");
            }
        } 

        /* 
        
        Event delegate event setups
        
        - event keyword adds restrictions and extra capabilities (Will be continued in the OOP section )

        */

        // Setup an Success event
        public event GradeAddedDelegate GradeAdded;

        // Setup an Error event
        public event GradeAddedDelegateException GradeAddedError;

        public double GetTotal()
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

        public double GetAverage(double total)
        {
            // total number of items / count
            double average = total / grades.Count;

            // Return the average (73.92)
            return average;
        }

        public void AddGrade(char letter) 
        {
            switch(letter) {
                case 'A':
                    AddGrade(90);
                break;

                case 'B':
                    AddGrade(80);
                break;

                case 'C':
                    AddGrade(70);
                break;

                default: 
                    AddGrade(0);
                    break;
            }
        }

        public double GetHighestGrade()
        {
            // Gets the lowest precision double value possible
            var highestGrade = double.MinValue;

            // For loop
            for(int index = 0; index < grades.Count; index+= 1)
            {
                if (grades[index] > highestGrade)
                {
                    highestGrade = grades[index];
                }
            }

            // While loop
            // var index = 0;
            // // Iterates over the grades and compares the current grade to the highest grade
            // while(index < grades.Count) {
            //     // When the current number is higher than the highestGrade update the highestGrade with the current number
            //     if (grades[index] > highestGrade)
            //     {
            //         highestGrade = grades[index];
            //     }

            //     index += 1;

            // }

            // foreach loop
            // foreach (var number in grades)
            // {
            //     // When the current number is higher than the highestGrade update the highestGrade with the current number
            //     if (number > highestGrade)
            //     {
            //         highestGrade = number;
            //     }
            // }

            // Return the highest grade (90.5)
            return highestGrade;
        }

        public double GetLowestGrade()
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