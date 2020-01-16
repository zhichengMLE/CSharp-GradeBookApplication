using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            List<double> grades = new List<double>();
            foreach(Student student in Students)
            {
                grades.Add(student.AverageGrade);
            }

            grades.Sort();
            grades.Reverse();

            if (averageGrade >= grades[threshold-1])
            {
                return 'A';
            }
            else if(averageGrade >= grades[threshold*2-1])
            {
                return 'B';
            }
            else if(averageGrade >= grades[threshold*3-1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[threshold * 4 - 1])
            {
                return 'D';
            }
            

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
