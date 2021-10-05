using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Average = 0.0;            
        }

        public void ProcessGrades(List<double> grades)
        {
            ComputeStats(grades);
        }

        public void ProcessGrades(string path)
        {
           var reader = File.ReadAllLines(path);
           var grades = new List<double>();
           
           foreach(var line in reader)
           {
               grades.Add(double.Parse(line));
           }

           ComputeStats(grades);
        }

        private void ComputeStats(List<double> grades)
        {
            foreach(var grade in grades) {
                Low = Math.Min(Low, grade);
                High = Math.Max(High, grade); 
                Average += grade;
            }

            Average /= grades.Count;
        }

        public double Average { get; private set; }
        public double High { get; private set; }
        public double Low { get; private set; }
        public char Letter 
        { 
            get
            {
                switch(Average)
            {
                case var d when d >= 90.0:
                    return 'A';

                case var d when d >= 80.0:
                    return 'B';

                case var d when d >= 70.0:
                    return 'C';

                case var d when d >= 60.0:
                    return 'D';

                default:
                    return 'F';      
            }
            }
        }
    }
}