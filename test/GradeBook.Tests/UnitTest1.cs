using Xunit;

namespace GradeBook.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var x = 5;
            var y = 2;
            var expect = 10;

            // Act
            var actual = x * y;

            // Assert
            Assert.Equal(expect, actual);
        }
    }

    public class BookTests
    {
        [Fact]
        public void LowestGrade()
        {
            // Arrange
            var book = new Book("Grade");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act
            var expect = book.GetLowestGrade();
    
            //Assert
            Assert.Equal(77.3, expect);
        }

        [Fact]
        public void HighestGrade()
        {
            // Arrange
            var book = new Book("Grade");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act
            var expect = book.GetHighestGrade();
    
            //Assert
            Assert.Equal(90.5, expect);
        }

        [Fact]
        public void AddGradeWithLetter()
        {
            // Arrange
            var book = new Book("Grade book");
            book.AddLetterGrade('A');
            book.AddLetterGrade('C');

            // Act
            double total = book.GetTotal();
            double actual = book.GetAverage(total);

            // Assert
            Assert.Equal(80, actual);
            
        }

        [Fact]
        public void AddGrade() 
        {
            // Arrange
            var book = new Book("Grade");
            book.AddGrade(10);

            // Act
            var expect = book.GetTotal();

            // Assert
            Assert.Equal(10, expect);
        }

        [Fact]
        public void GetAverage()
        {
            // Arrange
            var book = new Book("Grade");
            book.AddGrade(56.1);
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(60);

            // Act
            double total = book.GetTotal();
            double expect = book.GetAverage(total);

            // Assert
            Assert.Equal(73.9, expect, 1);
        }
    }
}
