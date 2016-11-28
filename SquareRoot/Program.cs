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
            int number =  Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter a positive integer which you think might be the square root: ");
            int factor = Int32.Parse(Console.ReadLine());
            double result = root.GetHeronRoot(25, 5);

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
            public double GetHeronRoot(int number, int factor)
            {
                if (number < 1 || factor < 1)
                    throw new Exception("Please enter positive numbers"); // TODO
                if ((number / factor) - (Math.Sqrt(number)) < _error)
                {
                    return factor;
                }

                return 0;
            }
        }
    }
}
