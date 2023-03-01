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

        public const int METERS_IN_KILOMETERS = 1000;

        public const double FEET_IN_KILOMETERS = 3280.839895;

        public const double MILES_IN_KILOMETERS = 1.60935;

        public const int CENTIMETERS_IN_METERS = 100;

        public const int CENTIMETERS_IN_KILOMETERS = 100000;

        public const int CENTIMETERS_IN_MILES = 160935;

        public const double CENTIMETERS_IN_FEET = 30.48;

        public const int METERS_IN_MILIMETERS = 1000;

        public const int MILIMETERS_IN_KILOMETERS = 1000000;

        public const int CENTIMETERS_IN_MILIMETERS = 10;

        public const int MILE_IN_MILIMETERS = 1609350;

        public const double MILIMETERS_IN_FEET = 304.8;




        //Distance Unit Names
        public const string FEET = "Feet";

        public const string METERS = "Meters";

        public const string MILES = "Miles";

        public const string KILOMETERS = "Kilometers";

        public const string CENTIMETERS = "Centimeters";

        public const string MILIMETERS = "Milimeters";

        //Distance Variables
        private double fromDistance;

        private double toDistance;

        //Unit variables
        private string toUnit;

        private string fromUnit;

        ///Prompt the user to enter the distance in miles
        ///Input the mukes as a double number

        public void ConvertDistance()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleHelper.OutputHeading("Distance Converter");
            fromUnit = SelectUnit(" Please select the from distance unit > ");
            toUnit = SelectUnit(" Please select the to distance unit> ");

            Console.WriteLine($" Converting {fromUnit} to  {toUnit}");
            Console.WriteLine($" ---------------------------------------------");

            fromDistance = InputDistance($" Please enter the number of {fromUnit} > ");

            CalculateDistance();
            Console.ForegroundColor = ConsoleColor.Green;
            OutputDistance();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        //-------------unit Selection-----------------------------

        private string SelectUnit(string prompt)
        {

            string choice = DisplayChoices();
            string unit = ExecuteChoice(choice);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n You have chosen {unit}");
            Console.WriteLine($"          ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            return unit;

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
            else if (choice.Equals("4"))
            {
                return KILOMETERS;
            }
            else if (choice.Equals("5"))
            {
                return CENTIMETERS;
            }
            else if (choice.Equals("6"))
            {
                return MILIMETERS;
            }

            return null;
            
            
        }


        //------------display choice--------------------------
        private static string DisplayChoices()
        {
           
            Console.ForegroundColor = ConsoleColor.Cyan;
                
            string[] choices = { "Feet", "Meters", "Miles", "Kilometers", "Centimeters", "Milimeters" };
            int choice = ConsoleHelper.SelectChoice(choices);

            return Convert.ToString(choice);
 
        }


        //-----------------Input-----------------

        private double InputDistance(string prompt)
        {
            double value = ConsoleHelper.InputDecimal(prompt);

            return value;
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
            else if (fromUnit == METERS && toUnit == KILOMETERS)
            {
                toDistance = fromDistance * METERS_IN_KILOMETERS;
            }
            else if (fromUnit == KILOMETERS && toUnit == METERS)
            {
                toDistance = fromDistance / METERS_IN_KILOMETERS;
            }
            else if (fromUnit == KILOMETERS && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_KILOMETERS;
            }
            else if (fromUnit == FEET && toUnit == KILOMETERS)
            {
                toDistance = fromDistance / FEET_IN_KILOMETERS;
            }
            else if (fromUnit == MILES && toUnit == KILOMETERS)
            {
                toDistance = fromDistance * MILES_IN_KILOMETERS;
            }
            else if (fromUnit == KILOMETERS && toUnit == MILES)
            {
                toDistance = fromDistance / MILES_IN_KILOMETERS;
            }
            else if (fromUnit == CENTIMETERS && toUnit == METERS)
            {
                toDistance = fromDistance / CENTIMETERS_IN_METERS;
            }
            else if (fromUnit == METERS && toUnit == CENTIMETERS)
            {
                toDistance = fromDistance * CENTIMETERS_IN_METERS;
            }
            else if (fromUnit == CENTIMETERS && toUnit == KILOMETERS)
            {
                toDistance = fromDistance / CENTIMETERS_IN_KILOMETERS;
            }
            else if (fromUnit == KILOMETERS && toUnit == CENTIMETERS)
            {
                toDistance = fromDistance * CENTIMETERS_IN_KILOMETERS;
            }
            else if (fromUnit == CENTIMETERS && toUnit == MILES )
            {
                toDistance = fromDistance / CENTIMETERS_IN_MILES;
            }
            else if (fromUnit == MILES && toUnit == CENTIMETERS)
            {
                toDistance = fromDistance * CENTIMETERS_IN_MILES;
            }
            else if (fromUnit == CENTIMETERS && toUnit == FEET)
            {
                toDistance = fromDistance / CENTIMETERS_IN_FEET;
            }
            else if (fromUnit == FEET && toUnit == CENTIMETERS)
            {
                toDistance = fromDistance * CENTIMETERS_IN_FEET;
            }
            else if (fromUnit == MILIMETERS && toUnit == METERS)
            {
                toDistance = fromDistance / METERS_IN_MILIMETERS;
            }
            else if (fromUnit == METERS && toUnit == MILIMETERS)
            {
                toDistance = fromDistance * METERS_IN_MILIMETERS;
            }
            else if (fromUnit == MILIMETERS && toUnit == KILOMETERS)
            {
                toDistance = fromDistance / MILIMETERS_IN_KILOMETERS;
            }
            else if (fromUnit == KILOMETERS && toUnit == MILIMETERS)
            {
                toDistance = fromDistance * MILIMETERS_IN_KILOMETERS;
            }
            else if (fromUnit == MILIMETERS && toUnit == CENTIMETERS)
            {
                toDistance = fromDistance / CENTIMETERS_IN_MILIMETERS;
            }
            else if (fromUnit == CENTIMETERS && toUnit == MILIMETERS)
            {
                toDistance = fromDistance * CENTIMETERS_IN_MILIMETERS;
            }
            else if (fromUnit == MILIMETERS && toUnit == MILES)
            {
                toDistance = fromDistance / MILE_IN_MILIMETERS;
            }
            else if (fromUnit == MILES && toUnit == MILIMETERS)
            {
                toDistance = fromDistance * MILE_IN_MILIMETERS;
            }
            else if (fromUnit == MILIMETERS && toUnit == FEET)
            {
                toDistance = fromDistance / MILIMETERS_IN_FEET;
            }
            else if (fromUnit == FEET && toUnit == MILIMETERS)
            {
                toDistance = fromDistance * MILIMETERS_IN_FEET;
            }
        }


        //-------------------Outputs--------------

        private void OutputDistance()
        {
            Console.WriteLine();
            Console.WriteLine($" {fromDistance} {fromUnit} is {toDistance} {toUnit} !");
            Console.WriteLine();
        }

    }
}
   