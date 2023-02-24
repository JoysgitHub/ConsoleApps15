using System;
using System.Security.Cryptography.X509Certificates;
using ConsoleAppProject.Helpers;


namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This app will prompt the user to input a distance 
    /// measured in one unit (fromUnit) and it will calculate and
    /// output the equivalent distance in another unit (toUnit).
    /// </summary>
    /// <author>
    /// Joyson version 0.6
    /// </author>
    public class DistanceConverter
    {
        //Distance Conversion constants
        public const int FEET_IN_MILES = 5280;

        public const double METERS_IN_MILES = 1609.344;

        public const double FEET_IN_METERS = 3.280839895;

        //Distance Unit Names
        public const string FEET = "Feet";

        public const string METERS = "Meters";

        public const string MILES = "Miles";

        //Distance Variables
        private double fromDistance;

        private double toDistance;

        //Unit variables
        private string toUnit;

        private string fromUnit;


        //public DistanceConverter()
        //{
        //    fromUnit = MILES;
        //    toUnit = FEET;
        //}


        ///Prompt the user to enter the distance in miles
        ///Input the mukes as a double number

        public void ConvertDistance()
        {
            //Console.ForegroundColor = ConsoleColor.Green;
            fromUnit = SelectUnit("Please select the from distance unit > ");
            toUnit = SelectUnit("Please select the to distance unit> ");

            OutputHeading($"   Converting {fromUnit} to  {toUnit}                      ");

            fromDistance = InputDistance($"Please enter the number of {fromUnit} > ");

            CalculateDistance();

            OutputDistance();
        }

       //-------------unit Selection-----------------------------

        private string SelectUnit(string prompt)
        {
           
            string choice = DisplayChoices(prompt);
            return ExecuteChoice(choice);

        }
        //-----------execute choice-----------------------

        private static string ExecuteChoice(string choice)
        {
            if (choice.Equals("1"))
            {
                return FEET;
            }
            else if (choice == "2")
            {
                return METERS;
            }
            else if (choice.Equals("3"))
            {
                return MILES;
            }
            
            return null;
            
            
        }


        //------------display choice--------------------------
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($"1. {FEET}");
            Console.WriteLine($"2. {METERS}");
            Console.WriteLine($"3. {MILES}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }

        //------------Headings-------------------------------------

        private void  OutputHeading(String prompt)
        {
            

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine(prompt);
            Console.WriteLine("        by Joyson Cardoso                         ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

        }


        //-----------------Input-----------------

        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }


        //------------------Calculate------------------------
       
        private void CalculateDistance()
        {
            if(fromUnit == MILES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if(fromUnit == FEET && toUnit ==  MILES)
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }
            else if (fromUnit == MILES && toUnit == METERS)
            {
                toDistance = fromDistance * METERS_IN_MILES;
            }
            else if (fromUnit == METERS && toUnit == MILES)
            {
                toDistance = fromDistance / METERS_IN_MILES;
            }
            else if (fromUnit == METERS && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_METERS;
            }
            else if (fromUnit == FEET && toUnit == METERS)
            {
                toDistance = fromDistance / FEET_IN_METERS;
            }
        }


        //-------------------Outputs--------------

        private void OutputDistance()
        {
            Console.WriteLine();
            Console.WriteLine($"{fromDistance} {fromUnit} is {toDistance} {toUnit} !");
            Console.WriteLine();
        }

    }
}
