using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata;
using ConsoleAppProject.Helpers;
namespace ConsoleAppProject.App03
{
    /// <summary>
    ///This class allows the user to enter grades against pre entered and new
    ///student names and prints the marks and grades. Another function of this class is to
    ///calculates the mean,max and min of the marks. This class also outputs a grade profile. 
    /// </summary>
    public class StudentGrades
    {   
        //Constants (Grade Boundaries)
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
        public Grades[] CalculatedGrades { get; set; }
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
             "Emily", "Joshua", "Sophia",
             "Ethan", "Isabella", "Liam",
             "Mia", "Oliver", "Ava",
             "Benjamin"
            }; 

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
            CalculatedGrades = new Grades[Marks.Length];
        }

        /// <summary>
        /// This is the first function that is called when the student 
        /// grade program starts. It outputs the App heading and calls
        /// the main menu function.
        /// </summary>
        public void StudentGradesMain()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleHelper.OutputHeading("Student Grade App");
            MainMenu();

        }

        /// <summary>
        /// This function prints the main student grade menu and prompts the user 
        /// to select a choice from the menu and calls the execute choice function.
        /// </summary>
        /// <returns></returns>
        private string MainMenu()
        {
            ConsoleHelper.OutputTitle("-------Main Menu-------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string[] choices = { "Add Student","Input Marks", "Output Marks","Output Stats","Output Grade Profile","Exit" };
            int choice = ConsoleHelper.SelectChoice(choices);
            ExecuteChoice(choice);
            return null;

        }

        /// <summary>
        /// This method uses conditional statments and calls a function depending on the user choice.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        private string ExecuteChoice(int choice)
        {
            if (choice == 1)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Add Student selected");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                AddStudent();

            }
            else if (choice == 2)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Input Marks selected");
                Console.ForegroundColor = ConsoleColor.Cyan;
                InputMarks();
            }

            else if (choice == 3) 
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Output Marks selected");
                Console.ForegroundColor = ConsoleColor.Cyan;
                OutputMarks();
            }
            else if (choice == 4)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Output Stats selected");
                Console.ForegroundColor = ConsoleColor.Cyan;
                CalculateStats();
            }
            else if (choice == 5  )
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Output Grade Profile");
                Console.ForegroundColor = ConsoleColor.Cyan;
                CalculateGradeProfile(); 
            }

            return null;
        }

        /// <summary>
        /// This method is used to add a new student to the Students array.
        /// </summary>
        public void AddStudent()
        {
            Console.Write($" Enter the name of the student >  ");
            Students[0] = Console.ReadLine();
            MainMenu();
        }

        ///<Summary>        
        ///Input a mark between 0-100 for each 
        ///student and store it in the Marks array
        ///</Summary>
        public void InputMarks()
        {
            Console.WriteLine();
            for (int i = 0; i < Students.Length; i++)
            {
                Console.Write($" Enter the marks for {Students[i]} ");
                Marks[i] = (int)ConsoleHelper.InputIntegar("> ");
            }
            MainMenu();
        }

        /// <summary>
        /// This method converts the marks to a grade and stores it in the
        /// CalculatedGrade array.
        /// </summary>
        public void CalculateGrade()
        {
            for (int i = 0; i < Marks.Length; i++)
            {
                Grades a = ConvertToGrade(Marks[i]);
                CalculatedGrades[i] = a;
            }
            
        }

    


        ///<summary>
        ///List all the students and display their 
        ///name, current mark and the calculated grade.
        ///</Summary>
        public void OutputMarks()
          {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                CalculateGrade();
                Console.WriteLine(" Student Marks:");
                int j = 1;
                for (int i = 0; i < Students.Length; i++)
                {               
                    Console.WriteLine($" {j}) {Students[i]}: Marks: {Marks[i]} is Grade {CalculatedGrades[i]}");
                    j++;
                }
                MainMenu();
        }         

      
        
        ///<summary>
        ///Convert a student mark to a grade
        ///from F (Fail) to A (First Class)
        ///</summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= 0 && mark < LowestGradeD)
            {
                return Grades.F;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)                
            {
                return Grades.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grades.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grades.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                return Grades.A;
            }
            return Grades.F;


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
            Console.WriteLine($" Mean: {Mean} \n Minimum Mark: {Minimum} \n Maximum Mark: {Maximum}");
            MainMenu();
        }
        
        /// <summary>
        /// This calculates the grade profile based on the marks.
        /// </summary>
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
            OutputGradeProfile();
        }   

        /// <summary>
        /// This method outputs the grade profile calculated in the CalculateGradeProfile.
        /// </summary>
        public void OutputGradeProfile()
        {
            Grades grade = Grades.F;
            Console.WriteLine();
            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($" Grade {grade} {percentage}% Count {count}");
                grade++;
            }
            MainMenu(); 
        }
    }
}