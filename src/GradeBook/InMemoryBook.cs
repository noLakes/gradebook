using System;
using System.Collections.Generic;

namespace GradeBook 
{
        public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
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

        public override void AddGrade(double grade) 
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }   
        }

        public override event GradeAddedDelegate GradeAdded;

        public List<double> GetGrades()
        {
            return grades;
        }

        public string GetName() 
        {
            return this.Name;
        }
        
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            result.ProcessGrades(grades);
            return result;
        }

        private List<double> grades;
  
        public const string CATEGORY = "Science";
    }
}
