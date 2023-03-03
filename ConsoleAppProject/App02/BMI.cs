using System;
using System.Security.Cryptography.X509Certificates;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This app will allow the user to choose either imperial or metric units after which it 
    /// will prompt the user to input thier height and weight in the chosen units and then calculate
    /// their BMI(Body Mass Index) and tell the user if they are underweight, healthy, overweight 
    /// or Obese.
    /// </summary>
    /// <author>
    /// Student Name version 0.1
    /// </author>
    public class BMI
    {

        
        //private double bmi;

        public const double UNDERWIGHT = 18.5;

        public const int HEALTHY = 25;

        public const int OVERWEIGHT = 30;

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
            ExecuteChoice(choice);
            return null;

        }


        private string ExecuteChoice(int choice)
        {
            if (choice == 1)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Metric selected");
                Console.ForegroundColor = ConsoleColor.Cyan;
                InputMetric();

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
            double heightCM = ConsoleHelper.InputDecimal(" Enter Your Height In Centimeters > ");
            Console.WriteLine();
            CalculateMetric(weight, heightCM);


            return weight;
        }


        public double CalculateMetric(double weight, double heightCM)
        {
            double height = heightCM / 100;
            bmi = weight / (height * height);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Your BMI is: {bmi:f2}");
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
            CalculateImperial( weight, height);

            return weight;
        }


        public double CalculateImperial(double weight, double height)
        {
            bmi = (weight * 703) / (height * height);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Your BMI is: {bmi:f2}");
            Console.WriteLine();
            BMIResult();

            return bmi;
        }



        private string BMIResult()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (bmi < UNDERWIGHT)
            {
                Console.WriteLine(" You Are Underweight.");
            }
            else if (bmi < HEALTHY)
            {
                Console.WriteLine(" You Are At A Healthy Weight.");
            }
            else if (bmi < OVERWEIGHT)
            {
                Console.WriteLine(" You Are Overweight.");
            }
            else
            {
                Console.WriteLine(" You Are Obese.");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleHelper.OutputTitle("If Your Black, Asian or Other Minority \n Ethnic Groups, You Have A Higher Risk \n Adults 23.0 Or More Are At Increased Risk \n Adults 27.5 Or More Are At High Risk");

            Console.ReadLine();
            return null;

            
        }


             

    }
}