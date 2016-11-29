using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class StandardCalculator
    {
        private double _error { get; set; }

        // A constructor that takes the desired margin of error
        public StandardCalculator(double error)
        {
            _error = error;
        }

        // A method that returns the the square root of a number calculated using internal Math function
        public double GetStandardRoot(double number, double factor)
        {
            // If not positive integers, ask user to re-enter numbers
            if (number < 1 || factor < 1)
                throw new Exception("Please enter positive numbers");
            return Math.Sqrt(number);
        }
    }
}
