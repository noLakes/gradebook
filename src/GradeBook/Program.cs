using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Shan's grade book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Lowest Grade: {stats.Low}");
            Console.WriteLine($"Highest Grade: {stats.High}");
            Console.WriteLine($"Average Grade: {stats.Average}");
            Console.WriteLine($"Letter grade is: {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter grades below (or 'q' to finish).");
                Console.Write("Grade: ");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade Was Added");
        }
    }
}
