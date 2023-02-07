using System;
using ConsoleAppProject.Helpers;


namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This app will prompt the user to input a distance 
    /// using the chosen unit and it will calculate and
    /// output the equivalent distance in another unit
    /// </summary>
    /// <author>
    /// Jouson version 0.1
    /// </author>
    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;

        public const double METERS_IN_MILES = 1609.344;

        private double miles;

        private double feet;

        private double meters;

        public void Run()
            
        {
            DisplayMenu();
        }

        ///This function creates an infinite loop which prints the converter menu
        ///and prompts the user to enter a value between 1 to 3. 

        private void DisplayMenu()
        {
            bool quit = false;

            while (!quit)
            {
                ConverterMenu();
                int input = int.Parse(Console.ReadLine());
           

                switch (input)
                {
                    case 1:
                        MilesToFeet();
                        break;

                    case 2:
                        FeetToMiles();
                        break;

                    case 3:
                        MilesToMeters();
                        break;

                    case 4:
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            }


        }


        private void ConverterMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("      Enter 1 to Convert Miles to Feet:           ");
            Console.WriteLine("      Enter 2 to Convert Feet to Miles :           ");
            Console.WriteLine("      Enter 3 to Convert Miles to Meters:         ");
            Console.WriteLine("      Enter 4 to Exit:                            ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

        }

        ///Prompt the user to enter the distance in miles
        ///Input the mukes as a double number

        public void MilesToFeet()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            OutputHeading("   Convert Miles to Feet                          ");

            miles = InputDistance("Please enter the number of miles: ");

            CalculateFeet();

            OutputDistance(miles, nameof(miles), feet, nameof(feet));
        }

        public void FeetToMiles()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            OutputHeading("   Convert Feet to Miles                          ");

            feet = InputDistance("Please enter the number of feet: ");

            CalculateMiles();

            OutputDistance(feet, nameof(feet), miles, nameof(miles));

        }

        public void MilesToMeters()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            OutputHeading("   Convert Miles to Meters                          ");

            miles = InputDistance("Please enter the number of miles: ");

            CalculateMeters();

            OutputDistance(miles, nameof(miles), meters, nameof(meters));
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
        private void CalculateFeet()
        {
            feet = miles * FEET_IN_MILES;

        }

        private void CalculateMiles()
        {
            miles = feet / FEET_IN_MILES;

        }

        private void CalculateMeters()
        {
            meters = miles * METERS_IN_MILES;

        }
        //-------------------Outputs--------------

        private void OutputDistance(double fromDistance, string fromUnit,
            double toDistance, string toUnit)
        {
            Console.WriteLine();
            Console.WriteLine($"{fromDistance} {fromUnit} is {toDistance} {toUnit} !");
            Console.WriteLine();
        }

    }
}
