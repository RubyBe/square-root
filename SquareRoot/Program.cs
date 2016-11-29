using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class Program
    {
        /* A program that uses either that building MathSqrt or the Heron algorithm for computing the square root of a number N
        Guess number G = N/2
        If G*G is close enough to N
            return G
                Else
                    return G=(G+N/G)/2 and iterate
        example:
            25/5 = 5 (factor 5 + quotient 5)/2 = 5
            guess = 6 (in the program I will use n/2 as the first guess)
            25/6 = 4.12 (factor 6 + quotient 4.12)/2 = 5.06
            new guess = 5.06
            25/5.06 = 4.94 (factor 5.06 + quotient 4.94)/2 = 5.00    
        */
        static void Main(string[] args)
        {
            double error = 0.0001;
            // Create an instance of the Heron Calculator class
            HeronCalculator heronCalculator = new HeronCalculator(error);
            // Create an instance of the Standard Calculator class
            StandardCalculator standardCalculator = new StandardCalculator(error);
            // Run the Validation test
            double result = ValidateHeron(heronCalculator, standardCalculator, error);
            Console.WriteLine($"You ran a sample of 10,000 random numbers; numbers were within the accepted error in {result} cases.");
            Console.ReadLine();

        }
        private static double ValidateHeron(ISqrRt heronCalculator, ISqrRt standardCalculator, double error)
        {
            // A function to validate the accuracy of the Heron calculation vs. the internal Math.Sqrt function
            double resultHeron;
            double resultStandard;
            int resultTrue = 0;
            List<bool> resultList = new List<bool>();
            List<double> errorList = new List<double>();
            // Create random sample data to use for testing square root methods
            Random r = new Random();
            List<int> listNumbers = new List<int>();
            for(int i = 1; i < 10001; i++)
            {
                listNumbers.Add(r.Next(1, 100000));
            }
            // Run both square root methods on each of the random sample data numbers
            foreach(var num in listNumbers)
            {
                resultHeron = heronCalculator.GetSquareRoot(num);
                resultStandard = standardCalculator.GetSquareRoot(num);
                if (Math.Abs(resultHeron - resultStandard) < error)
                {
                    resultList.Add(true);
                    errorList.Add(Math.Abs(resultHeron - resultStandard));
                    resultTrue++;
                }
                else
                {
                    resultList.Add(false);
                    throw new Exception("The difference between the two methods is not within the accepted error rate.");
                }                 
            }
            return resultTrue;
        }
    }
}
