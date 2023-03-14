using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public string[] Students { get; set; }
        public int[] Marks { get; set; }

        public int[] GradeProfile { get; set; }

        public double Mean { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }


        public StudentGrades()
        {
            Students = new string[]
                 {
            "Daniel", "Dylan", "Eric",
            "Georgia", "Hasan", "Hamza",
            "Jack", "Liam", "Shan",
                     "Shamial"
            };


            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
        }


        public void InputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List all the students and display their /// name and current mark
        /// </summary>

        public void OutputMarks()
        {
            throw new NotImplementedException();
        }

        ﻿
        /// <summary>
        /// Convert a student mark to a grade /// from F (Fail) to A (First Class) /// </summary>
       
        public Grades ConvertToGrade(int mark)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Calculate and display the minimum, maximum /// and mean mark for all the students
        /// </summary>
       
        public void CalculateStats()
        {
         throw new NotImplementedException();
        }








    }      
}
