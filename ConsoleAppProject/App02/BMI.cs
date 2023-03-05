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
    /// 

    public class BMI
    {

        //constants used to determine the condition of the user.

        public const double UNDERWIGHT = 18.5;

        public const double HEALTHY = 24.9;

        public const double OVERWEIGHT = 29.9;

        public const double OBESEI = 34.9;

        public const double OBESEII = 39.9;

        public string adult;

        public double age;

     

        ///This is the first function that is called in the BMI program.
        ///This method outputs the program heading and then calls the select unit
        ///method to allow the user to choose between Imperial and Metric units.
        public void BMICalculator()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleHelper.OutputHeading("BMI Calculator");
            AdultOrChild();            
        }

        public string AdultOrChild()
        {
            string[] choices = { "Adult", "Child", };
            int adultOrChild = ConsoleHelper.SelectChoice(choices);
            ExecuteAdultOrChild(adultOrChild);

            return Convert.ToString(adultOrChild);
        }

        ///This method uses a con
        public string ExecuteAdultOrChild(int adultOrChild)
        {
            if (adultOrChild == 1)
            {
                ConsoleHelper.OutputTitle("----You Have chosen Adult------");
                adult = "1";
                SelectUnit();


            }
            else
            {
                ConsoleHelper.OutputTitle("----You Have chosen Child------");
                adult = "2";
                Console.ForegroundColor = ConsoleColor.Cyan;
                age = ConsoleHelper.InputDecimal("Please Enter The Age Of Your Child> ");
                Console.WriteLine();
                SelectUnit();

            }

            return null;
        }

        //--------------------- Unit------------------------------
        ///This method uses the ConsoleHelpers.SelectChoice method to display the menu and 
        ///prompts the user to input either 1 or 2 to select the units and then assigns the 
        ///output to the choice variable. The function then calls the ExecuteChoice method to
        ///determine which units to use.
        private string SelectUnit()
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            string[] choices = { "Metric Units", "Imperial Units", };
            int choice = ConsoleHelper.SelectChoice(choices);
            ExecuteChoice(choice);
            return null;

        }
        
        
        //---------------------- Execute choice---------------------------
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

       
       
        //--------------------------Input Metric----------------------
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
            Console.WriteLine();

            if (adult == "1")
            {
                ConsoleHelper.OutputTitle($" Your BMI is: {bmi:f2}");
                BMIResult(bmi);
            }
            else
            {
                ConsoleHelper.OutputTitle($" Your BMI is: {bmi:f2}");
                BMIChildResult(bmi);
            }
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
            CalculateImperial(weight, heightFT, heightIN);

            return weight;
        }

        ///The calculateImperial method is called if the choses the Imperial system.
        ///It uses the height and weight entered in imperial units to calculate the BMI of the user.
        ///And then calls the BMIresult method to determine the conditon of the user using the bmi variable.
        public double CalculateImperial(double weight, double heightFT, double heightIN)
        {
            double heightFeet = (heightFT * 12) + heightIN;
            double bmi = weight * 703 / (heightFeet * heightFeet);
            Console.ForegroundColor = ConsoleColor.Green;            
            if (adult == "1")
            {
                ConsoleHelper.OutputTitle($" Your BMI is: {bmi:f2}");
                BMIResult(bmi);
            }
            else
            {
                ConsoleHelper.OutputTitle($" Your BMI is: {bmi:f2}");
                BMIChildResult(bmi);
            }
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
            else if (bmi < OBESEI)
            {
                Console.WriteLine(" You Are Obese Class I.");
            }
            else if (bmi <= OBESEII)
            {
                Console.WriteLine(" You Are Obese Class II.");
            }
            else
            {
                Console.WriteLine(" You Are Obese Class III.");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleHelper.OutputTitle("If Your Black, Asian or Other Minority \n Ethnic Groups, You Have A Higher Risk \n Adults 23.0 Or More Are At Increased Risk \n Adults 27.5 Or More Are At High Risk");
            Console.ReadLine();
            return null;
        }

        private double BMIChildResult(double bmi)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (age < 2)
            {
                if (bmi < 13.5)
                {
                    Console.WriteLine("You are in the 1st to 4th Percentile. You Are Underweight.");
                }
                else if (bmi >= 13.5 && bmi < 15)
                {
                    Console.WriteLine(" You are in the 5th Percentile. You Are At A Healthy Weight.");
                }
                else if (bmi >= 15 && bmi < 16)
                {
                    Console.WriteLine(" You are in the 10th Percentile.You Are At A Healthy Weight.");
                }
                else if (bmi >= 16 && bmi < 17)
                {
                    Console.WriteLine("You are in the 25th Percentile. You Are At A Healthy Weight.");
                }
                else if (bmi >= 17 && bmi < 18)
                {
                    Console.WriteLine(" You are in the 50th Percentile.You Are At A Healthy Weight.");
                }
                else if (bmi >= 18 && bmi < 19)
                {
                    Console.WriteLine(" You are in the 75th Percentile.You Are At A Healthy Weight.");
                }
                else if (bmi >= 19 && bmi < 20)
                {
                    Console.WriteLine(" You are in the 90th Percentile.You Are Overweight.");
                }
                else
                {
                    Console.WriteLine(" You are in the 95th Percentile.You Are Obese!!!");
                }
            }
            else
            {
                if (bmi < 15)
                {
                    Console.WriteLine(" You are in the 1-4th Percentile.You Are Underweight.");
                }
                else if (bmi >= 15 && bmi < 18.5)
                {
                    Console.WriteLine(" You are in the 5th Percentile.You Are At A Healthy Weight.");
                }
                else if (bmi >= 18.5 && bmi < 25)
                {
                    Console.WriteLine(" You are in the 50-84th Percentile.You Are At A Healthy Weight.");
                }
                else if (bmi >= 25 && bmi < 30)
                {
                    Console.WriteLine(" You are in the 85th Percentile.You Are Overweight.");
                }
                else
                {
                    Console.WriteLine(" You are in the 95th Percentile.You Are Obese!!!");
                }
            }
            ConsoleHelper.OutputTitle("If Your Black, Asian or Other Minority \n Ethnic Groups, You Have A Higher Risk \n Children 85th Or More Percentile Are At Increased Risk \n Children 95th Or More Percentile Are At High Risk");
            Console.ReadLine();
            return bmi;
        }
    }   
}