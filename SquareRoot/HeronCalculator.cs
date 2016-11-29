using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class HeronCalculator : ISqrRt
    {
        // A property which is the acceptable error limit
        private double _error { get; set; }

        // A constructor which takes a double as the error limit
        public HeronCalculator(double error)
        {
            _error = error;
        }

        // A method which computers the square root for an arbitrary number
        public double GetSquareRoot(double number)
        {
            double factor = number / 2;
            double quotient;
            double newGuess;
            double result = 0;
            double initialDiff = 0;
            // If not positive integers, ask user to re-enter numbers
            if (number < 1 || factor < 1)
                throw new Exception("Please enter positive numbers"); 

            // If the user guess is within the margin of error, return the user guess as correct
            initialDiff = Math.Abs((number / factor) - (Math.Sqrt(number)));
            if (initialDiff < _error)
            {
                return factor;
            }
            // If the user guess is not within the margin of error, calculate the square root using the Heron method
            while (initialDiff >= _error)
            {
                // get the current quotient
                quotient = number / factor;
                // calculate the new guess as an average of the old factor and quotient
                newGuess = (factor + quotient) / 2;
                // get the new quotient
                result = number / newGuess;
                // set the new factor to the new quotient
                factor = result;
                // calculate the new diff to compare with margin of error
                initialDiff = Math.Abs(result - (Math.Sqrt(number)));
            }
            return result;
        }
    }
}
