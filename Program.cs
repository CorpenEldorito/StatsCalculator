/// Created by Oliver Hitchcock (Corpen)
/// Version 1.0

using System;
using System.Collections.Generic;

namespace StatsCalculator
{
    class Program
    {
        /// <summary>
        /// Main: Handles the main thread for calling the functions and outputting the the values to the console window.
        /// </summary>
        static void Main(string[] args)
        {
            int[] values = GetValues();

            Console.Write("Numbers Entered: ");
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write("{0}", values[i]);
                if (i != values.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("\n");

            Console.WriteLine("Mean: {0},\nMedian: {1},\nLowest {2}", Mean(values), Median(values), LowestVal(values));

            Console.ReadKey();
        }

        /// <summary>
        /// GetValues: Creates a list then adds values through user input in a while loop until the point the user does not want to input any further values.
        /// This list is then returned as an array using the ToArray method.
        /// </summary>
        public static int[] GetValues()
        {
            List<int> vals = new List<int>();

            bool isAddingVals = true;
            while (isAddingVals == true)
            {
                Console.WriteLine("Input a integer value.");
                int num;
                bool correct = int.TryParse(Console.ReadLine(), out num);
                if(correct == true)
                {
                    vals.Add(num);
                    Console.WriteLine("Would you like to add another value: Yes or No.");
                    string option = Console.ReadLine();

                    switch (option.ToLower())
                    {
                        case "no":
                            isAddingVals = false;
                            break;

                        case "n":
                            isAddingVals = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please input a valid integer.");
                }
            }

            return vals.ToArray();
        }

        /// <summary>
        /// Mean: Calculates the mean vlaue from the passed integer array.
        /// </summary>
        public static float Mean(int[] p)
        {
            int sum = 0;

            for (int i = 0; i < p.Length; i++)
            {
                sum += p[i];
            }

            return sum / p.Length;
        }

        /// <summary>
        /// LowestValue: Finds the lowest value in the array by starting with the largest possible integer and then itterating trhrough the array.
        /// </summary>
        public static int LowestVal(int[] p)
        {
            int lowest = int.MaxValue;

            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] < lowest)
                {
                    lowest = p[i];
                }
            }

            return lowest;
        }

        /// <summary>
        /// Median: Sorts the array and then returns the middle value of the array.
        /// </summary>
        public static float Median(int[] p)
        {
            Array.Sort(p);

            if (IsEven(p.Length) == true)
            {
                float i = ((p.Length + 1) / 2) - 1;
                return (p[(int)i] + p[Floor(i)]) / 2;
            }
            else
            {
                int i = ((p.Length + 1) / 2) - 1;
                return p[i];
            }
        }

        /// <summary>
        /// IsEven: Returns whether the passed value is even by checking the remainder when devided by 2.
        /// </summary>
        public static bool IsEven(int p)
        {
            int rem = p % 2;
            return rem == 0 ? true : false;
        }

        /// <summary>
        /// Floor: Floors the passed value by rounding it explicitly then making sure it is smaller than the orginal value.
        /// </summary>
        public static int Floor(float p)
        {
            int pi = (int)p;
            return p < pi ? pi - 1 : pi;
        }
    }
}
