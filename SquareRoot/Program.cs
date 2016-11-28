using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class Program
    {
        /* A program that uses the Heron algorithm for computing the square root of a number N
        Guess number G = N/2
        If G*G is close enough to N
            return G
                Else
                    return G=(G+N/G)/2 and iterate
        example:
            25/5 = 5 (factor 5 + quotient 5)/2 = 5
            guess = 6:
            25/6 = 4.12 (factor 6 + quotient 4.12)/2 = 5.06
            new guess = 5.06
            25/5.06 = 4.94 (factor 5.06 + quotient 4.94)/2 = 5.00    
        */
        static void Main(string[] args)
        {
            // Create an instance of the HeronRoot class
            HeronRoot root = new HeronRoot(0.01);

            // Get input from user
            Console.WriteLine("Enter a positive integer for which you'd like a square root: ");
            double number =  Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a positive integer which you think might be the square root: ");
            double factor = Double.Parse(Console.ReadLine());
            double result = root.GetHeronRoot(number, factor);

            Console.WriteLine($"Square root is: {result}");
            Console.ReadLine();
        }

        // A class that computers the square root of numbers
        public class HeronRoot
        {
            // A property which is the acceptable error limit
            private double _error { get; set; }

            // A constructor which takes a double as the error limit
            public HeronRoot(double error)
            {
                _error = error;
            }

            // A method which computers the square root for an arbitrary number
            public double GetHeronRoot(double number, double factor)
            {
                double quotient;
                double newGuess;
                double result = 0;
                double initialDiff = 0;
                // If not positive integers, ask user to re-enter numbers
                if (number < 1 || factor < 1)
                    throw new Exception("Please enter positive numbers"); // TODO

                // If the user guess is within the margin of error, return the user guess as correct
                initialDiff = Math.Abs((number / factor) - (Math.Sqrt(number)));
                if (initialDiff < _error)
                {
                    return factor;
                }
                // If the user guess is not within the margin of error, calculate the square root using the Heron method
                while (initialDiff >= _error) 
                {
                    quotient = number / factor;
                    newGuess = (factor + quotient) / 2;
                    result = number / newGuess;
                    factor = result;
                    initialDiff = Math.Abs(result - (Math.Sqrt(number)));
                }
                return result;
            }
        }
    }
}
