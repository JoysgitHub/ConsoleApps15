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
        
        //constants used to determine the condition of the user.

        public const double UNDERWIGHT = 18.5;

        public const int HEALTHY = 25;

        public const int OVERWEIGHT = 30;

        ///This is the first function that is called in the BMI program.
        ///This method outputs the program heading and then calls the select unit
        ///method to allow the user to choose between Imperial and Metric units.
        public void BMICalculator()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleHelper.OutputHeading("BMI Calculator");
            SelectUnit();
        }

        ///This method uses the ConsoleHelpers.SelectChoice method to display the menu and 
        ///prompts the user to input either 1 or 2 to select the units and then assigns the 
        ///output to the choice variable. The function then calls the ExecuteChoice method to
        ///determine which units to use.
        private string SelectUnit()
        {

            string[] choices = { "Metric Units", "Imperial Units", };
            int choice = ConsoleHelper.SelectChoice(choices);
            ExecuteChoice(choice);
            return null;

        }

        ///This method uses conditional statments to determine which units to use.
        ///If the user inputs 1 it calculates the BMI in metric units and if the user 
        ///inputs 2 it uses the Imerial units.
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

        ///This method is called if the user choses the metric units. It used the ConsoleHelper.InputDecimal
        ///method to validate the input by forcing the user to input either a Integar or a double. 
        ///this method also prints an error message if the user inputs anythig other then a number.
        ///after assigning the iputs to the height and weight it calls the calculateMetric method.
        ///
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

        ///The calculateMetric is called if the choses the metric system.
        ///This method converts the height from centimeters to meters and then
        ///uses the new height(m) and weight(kg) to calculate the BMI of the user.
        ///And then calls the BMIresult method to determine the conditon of the user.
        public double CalculateMetric(double weight, double heightCM)
        {
            double height = heightCM / 100;
            double bmi = weight / (height * height);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Your BMI is: {bmi:f2}");
            Console.WriteLine();
            BMIResult(bmi);

            return bmi;
        }


        ///This method is called if the user choses the imperial units. It used the ConsoleHelper.InputDecimal
        ///method to validate the input by forcing the user to input either a Integar or a double. 
        ///this method also prints an error message if the user inputs anythig other then a number.
        ///after assigning the iputs to the height and weight it calls the calculateImperial method.
        ///
        public double InputImperial()
        {
            Console.WriteLine();
            double weight = ConsoleHelper.InputDecimal(" Enter Your Weight In Pounds > ");
            Console.WriteLine();
            double heightFT = ConsoleHelper.InputDecimal(" Enter Your Height In Feet> ");
            double heightIN = ConsoleHelper.InputDecimal(" Enter The Remaining Inches Of Your Height > ");
            Console.WriteLine();
            CalculateImperial( weight, heightFT, heightIN);

            return weight;
        }

        ///The calculateImperial method is called if the choses the Imperial system.
        ///It uses the height and weight entered in imperial units to calculate the BMI of the user.
        ///And then calls the BMIresult method to determine the conditon of the user using the bmi variable.
        public double CalculateImperial(double weight, double heightFT, double heightIN)
        {
            double heightFeet = (heightFT * 12) + heightIN;            
            double bmi = weight * 703 / (heightFeet * heightFeet);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Your BMI is: {bmi:f2}");
            Console.WriteLine();
            BMIResult(bmi);

            return bmi;
        }


        ///The BMIResult method uses conditional statements to check if the BMI calculated is 
        ///under, healthy or overweight after which it outputs a message informing the user of 
        ///their condition. It also outputs a message for the BAME users at the end.
        
        private string BMIResult(double bmi)
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