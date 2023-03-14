using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Derek Peacock 05/02/2022
    /// </summary>
    public static class Program
    {   
        ///This is the main method fo the program.
        ///This method outputs the heading and displays the main menu.
        ///The main menu displays the choices and prompts the user to 
        ///input either 1 or 2 and opens the apps.
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

           
            ConsoleHelper.OutputHeading(" BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine();
            Console.Beep();

            string[] choices = { "Distance Converter", "BMI Converter","Student Grades" };
            int choiceNo = ConsoleHelper.SelectChoice(choices);

            if (choiceNo == 1 ) 
            {
                DistanceConverter converter = new DistanceConverter();
                converter.ConvertDistance();
            }
            else if (choiceNo == 2 )
            {
                BMI calculator = new BMI();
                calculator.BMICalculator();
            }      
            else if (choiceNo == 3 )
            {
                StudentGrades studentGrades = new StudentGrades();
                studentGrades.StudentGradesMain();
            }
        }
    }
}
