using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using ConsoleAppProject.Helpers;
namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {         //Constants (Grade Boundaries)
        public const int LowestMark = 0;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;         
        //properties 
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }         
        /// <summary>
                                                         /// Class Constructor called when an object 
                                                         /// is created and sets up an array of students.
                                                         /// </summary>
        public StudentGrades()
        {
            Students = new string[]
            {
             "Jacob", "Dion", "Christina",
             "Alice", "Sam", "Daniel",
             "Rocky", "Phebe", "Adi",
             "Jamal"
            }; 
            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
        }         ///<Summary>
                          ///Input a mark between 0-100 for each 
                          ///student and store it in the Marks array
                          ///</Summary>
        public void InputMarks()
        {
            throw new NotImplementedException();
        }         ///<summary>
                          ///List all the students and display their 
                          ///name and current mark
                          ///</Summary>
        public void OutputMarks()
        {
            throw new NotImplementedException();
        }         ///<summary>
                          ///Convert a student mark to a grade
                          ///from F (Fail) to A (First Class)
                          ///</summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= 0 && mark < LowestGradeD)
            {
                return Grades.F;
            }
            else if (mark < 50)
            {
                return Grades.D;
            }
            else if (mark < 60)
            {
                return Grades.C;
            }
            else if (mark < 70)
            {
                return Grades.B;
            }
            else if (mark < 100)
            {
                return Grades.A;
            }
            else return Grades.A;
            
                
        }         
        ///<summary>                         
        ///Calculate and display the minimum, maximum                           
        ///and mean mark for all students                          
        ///</summary
        public void CalculateStats()
        {
            Minimum = Marks[0]; 
            Maximum = Marks[0];
            double total = 0;
            foreach (int mark in Marks)
            {
                if (mark > Maximum) Maximum = mark; 
                if (mark < Minimum) Minimum = mark; 
                total += mark;
            }
           
            Mean = total / Marks.Length;
            //double total = 0;
            //foreach(int mark in Marks)
            //{
            //    total += mark;
            //}
            //Mean = total / Marks.Length;
        }
        ///<summary>

        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }

        }   
    }
}