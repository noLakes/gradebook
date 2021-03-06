using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {  
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage; 

            log += ReturnMessage;
            log += IncrementCount;

            var result = log("I am a log.");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count += 1;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count += 1;
            return message;
        }

        [Fact]
        public void Test1()
        {  
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
            
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveValueTypes()
        {
            string name = "Shan";
            var upper = MakeUppercase(name);

            Assert.Equal("Shan", name);
            Assert.Equal("SHAN", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void CSharpCanPassByRef()
        {  
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {  
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjs()
        {  
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanRefSameObj()
        {  
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }

        
        Book GetBook(string name)
        {
            return new Book(name);
        }

    }
}
