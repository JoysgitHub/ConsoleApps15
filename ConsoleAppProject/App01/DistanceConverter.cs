using System;
using ConsoleAppProject.Helpers;


namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Jouson version 0.1
    /// </author>
    public class DistanceConverter
    {
        private double miles;

        private double feet;

        public void Run()
        {
            OutputHeading();
            InputMiles();
            CalclateFeet();
            OutputFeet();

        }

        ///Prompt the user to enter the distance in miles
        ///Input the mukes as a double number

        private void  OutputHeading()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("   Convert Miles to Feet                          ");
            Console.WriteLine("        by Joyson Cardoso                         ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

        }
        private void InputMiles()
        {
            Console.Write("Please enter the number of miles: ");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

        private void CalclateFeet()
        {
            feet = miles * 5280;

        }

        private void OutputFeet()
        {
            Console.WriteLine();
            Console.WriteLine(miles + " miles is " + feet + " feet!");
            Console.WriteLine();
        }
    }
}
