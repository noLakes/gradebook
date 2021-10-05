using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook 
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"books\\{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            result.ProcessGrades($"books\\{Name}.txt");
            return result;
            
        }

        public override event GradeAddedDelegate GradeAdded;
    }
}