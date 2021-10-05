using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {   
            // arrange
            var book = new Book("Test");
            book.AddGrade(89.51);
            book.AddGrade(72.05);
            book.AddGrade(68.75);

            // act
            var result = book.GetStatistics();

            // assert 
            Assert.Equal(76.77, result.Average, 1);
            Assert.Equal(68.75, result.Low, 1);
            Assert.Equal(89.51, result.High, 1);
            Assert.Equal('C', result.Letter);
        }

        [Fact]
        public void GradeMustBeWithinZeroAndHundred()
        {
            var book = new Book("Test");

            try
            {
                book.AddGrade(89.0);
                book.AddGrade(105.0);
                book.AddGrade(-10.0);
            }
            catch{}
            
            var grades = book.GetGrades();
            Assert.Equal(1, grades.Count);
        }
    }
}
