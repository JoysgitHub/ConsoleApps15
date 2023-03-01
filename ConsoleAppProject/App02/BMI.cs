using System;
using System.Security.Cryptography.X509Certificates;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Student Name version 0.1
    /// </author>
    public class BMI
    {

        //private string unitChoice;
        private double bmi;

        public void BMICalculator()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleHelper.OutputHeading("BMI Calculator");
            SelectUnit();
            
        }

        private string SelectUnit()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            string[] choices = { "Metric Units", "Imperial Units", };
            int choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1 )
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Metric selected");
                Console.ForegroundColor = ConsoleColor.Cyan;
                double bmiResult = InputMetric();

            }
            else 
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Imperial selected");
                Console.ForegroundColor = ConsoleColor.Cyan;

                InputImperial();
            }

            return null;
         
        }

        public double InputMetric()
        {
            Console.WriteLine();
            double weight = ConsoleHelper.InputDecimal(" Enter Your Weight In Kg > ");
            Console.WriteLine();
            double height = ConsoleHelper.InputDecimal(" Enter Your Height In Meters > ");
            Console.WriteLine();
            bmi = weight / (height * height);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Your BMI is: {bmi}");
            Console.WriteLine();
            BMIResult();
            
            return bmi;
        }


        public double InputImperial()
        {
            Console.WriteLine();
            double weight = ConsoleHelper.InputDecimal(" Enter Your Weight In Lbs > ");
            Console.WriteLine();
            double height = ConsoleHelper.InputDecimal(" Enter Your Height In Inches > ");
            Console.WriteLine();
            bmi = (weight * 703) / (height * height);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Your BMI is: {bmi}");
            Console.WriteLine();
            BMIResult();

            return bmi;
        }

        private string BMIResult()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (bmi < 18.5)
            {
                Console.WriteLine(" You are underweight.");
            }
            else if (bmi < 25)
            {
                Console.WriteLine(" You are at a healthy weight.");
            }
            else if (bmi < 30)
            {
                Console.WriteLine(" You are overweight.");
            }
            else
            {
                Console.WriteLine(" You are obese.");
            }

            Console.ReadLine();
            return null;

            
        }
             

    }
}