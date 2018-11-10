using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var percentile = Students.Where(x => x.AverageGrade < averageGrade).Count() / System.Convert.ToDouble(Students.Count);

            if (percentile >= 0.8)
            {
                return 'A';
            }
            else if (percentile >= 0.6)
            {
                return 'B';
            }
            else if (percentile >= 0.4)
            {
                return 'C';
            }
            else if (percentile >= 0.2)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
