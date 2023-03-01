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

        //Distance Unit Names
        public const string FEET = "Feet";

        public const string METERS = "Meters";

        public const string MILES = "Miles";

        public const string KILOMETERS = "Kilometers";

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
            OutputHeading();
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

            string choice = DisplayChoices(prompt);
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

            return null;
            
            
        }


        //------------display choice--------------------------
        private static string DisplayChoices(string prompt)
        {
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine($" 1. {FEET}");
                Console.WriteLine($" 2. {METERS}");
                Console.WriteLine($" 3. {MILES}");
                Console.WriteLine($" 4. {KILOMETERS}");
                Console.WriteLine();

                Console.Write(prompt);
                string choice = Console.ReadLine();

                if(choice == "1"|| choice =="2"|| choice == "3" || choice == "4")
                {
                    return choice;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine(" Please Enter A Number between 1-3");
                }
            }
            
            
        }

        //------------Headings-------------------------------------

        private void  OutputHeading()
        {
            

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("        Distance Converter ");
            Console.WriteLine("        by Joyson Cardoso                         ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

        }
         

        //-----------------Input-----------------

        private double InputDistance(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                if(int.TryParse(value,out int num1) || double.TryParse(value, out double num2))
                {
                    return Convert.ToDouble(value);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine(" Please Enter An Integar or A Double");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;

                }
            }
            
            //return Convert.ToDouble(value);
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
   