using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        //  String text        
        [Fact]
        public void stringsBehaveLikeValueTypes()
        {
            string name = "Alex";

            // Without capturing the string
            MakeUpperCase(name); // Won't change the string, it returns a copy, but it doesn't modify the value
            Assert.Equal("Alex", name); // Won't be uppercase, ToUpper() returns a copy, it doesn't directly modify the string
            
            
            // Capturing the copied string            
            var upperCaseName = MakeUpperCase(name); // Stores the copied string
            Assert.Equal("ALEX", upperCaseName); // Should be ALEX as the modified string is  stored above
        }

        
        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }






        // Value type, but insread of passing by value we pass by reference
        [Fact]
        public void PassByValueTypeWithRef() 
        {
            int x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        // Value types (What you see is what you get) e.g. GetInt returns 3
        [Fact]
        public void PassByValueType() 
        {
            int x = GetInt();
            Assert.Equal(3, x);
        }

        private int GetInt()
        {
            return 3;
        }

        // When passing by reference you can directly modify the value
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");

            // In CSharpIsPassByValue this block didn't get affected, but since we are passing by reference we don't get a copy instead we get the object memory reference, allowing the value to be updated
            GetBookSetName(ref book1, "New Name");

            // Since you can update by reference when the GetBookSetName was called it updated the name value, meaning it wil be "New Name"
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name) 
        {
         book = new Book(name);
        }


        // When passing by value you can't directly modify the value 
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            
            // Doesn't get set, when passing by value e.g. book1 (Object) you can't modify the name value
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name) 
        {
         book = new Book(name); // Creates a new object, but doesn't directly modify the existing "book" object
        }

        // book1 is passed by reference, so we can make changes to the reference
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");

            setName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void setName(Book book, string name) 
        {
            book.Name = name;
        }

        // Since two different objects are created then they will have two different memory references ("Book 2" and "Book 2")
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);


            // book 1 and book2 have unique ids, so they shouldn't not be the same 
            Assert.NotSame(book1, book2);
        }

        // book1 references book2, so book2 will always reference the book1 object
        [Fact]
        public void GetBookReturnsSameObjects()
        {
            // Both book1 and book2 store the same memory reference
            var book1 = GetBook("Book 1");
            var book2 = book1;
            Assert.Same(book1, book2);
        }



        Book GetBook(string name) {
            return new Book(name);
        }
    }
}
