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

        private double meters;

        public void Run()
            
        {
            ExecuteMenu();
        }

        ///This function creates an infinite loop which prints the converter menu
        ///and prompts the user to enter a value between 1 to 3. 

        private void ExecuteMenu()
        {
            bool quit = false;

            while (!quit)
            {
                ConverterMenu();
                int input = int.Parse(Console.ReadLine());
           

                switch (input)
                {
                    case 1:
                        FeetOutputHeading();
                        InputMiles();
                        CalclateFeet();
                        OutputFeet();
                        break;

                    case 2:
                        MetersOutputHeading();
                        InputMiles();
                        CalclateMeters();
                        OutputMeters();
                        break;

                    case 3:
                        quit= true;
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
            Console.WriteLine("      Enter 2 to Convert Miles to Meters:         ");
            Console.WriteLine("      Enter 3 to Exit:                            ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

        }

        ///Prompt the user to enter the distance in miles
        ///Input the mukes as a double number

        private void  FeetOutputHeading()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("   Convert Miles to Feet                          ");
            Console.WriteLine("        by Joyson Cardoso                         ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

        }

        private void MetersOutputHeading()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("   Convert Miles to Meters                         ");
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

        private void CalclateMeters()
        {
            meters = miles * 1609.344;

        }

        private void OutputFeet()
        {
            Console.WriteLine();
            Console.WriteLine(miles + " miles is " + feet + " feet!");
            Console.WriteLine();
        }

        private void OutputMeters()
        {
            Console.WriteLine();
            Console.WriteLine(miles + " miles is " + meters + " meters!");
            Console.WriteLine();
        }
    }
}
