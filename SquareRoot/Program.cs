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
            guess = 6:
            25/6 = 4.12 (factor 6 + quotient 4.12)/2 = 5.06
            new guess = 5.06
            25/5.06 = 4.94 (factor 5.06 + quotient 4.94)/2 = 5.00    
        */
        static void Main(string[] args)
        {
            double validateTest = ValidateHeron();
            // Create an instance of the Heron Calculator class
            HeronCalculator rootCalculator = new HeronCalculator(0.01);
            // Create an instance of the Standard Calculator class
            StandardCalculator standardCalculator = new StandardCalculator(0.01);

            // Get input from user
            Console.WriteLine("Enter a positive integer for which you'd like a square root: ");
            double number =  Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a positive integer which you think might be the square root: ");
            double factor = Double.Parse(Console.ReadLine());

            // Call the Heron calculator
            double HeronResult = rootCalculator.GetHeronRoot(number, factor);
            // Call the standard calculator
            double MathResult = standardCalculator.GetStandardRoot(number, factor);

            // Write the results
            Console.WriteLine($"Square root by Heron is: {HeronResult}");
            Console.WriteLine($"Square root by Math.Sqrt is: {MathResult}");
            Console.ReadLine();
        }
        private static double ValidateHeron()
        {
            // A function to validate the accuracy of the Heron calculation vs. the internal Math.Sqrt function
            double error = 0.0001;
            double resultHeron;
            double resultStandard;
            int resultTrue = 0;
            List<bool> resultList = new List<bool>();
            HeronCalculator heronCalculator = new HeronCalculator(error);
            StandardCalculator standardCalculator = new StandardCalculator(error);
            // Create random sample data to use for testing square root methods
            Random r = new Random();
            List<int> listNumbers = new List<int>();
            for(int i = 1; i < 10001; i++)
            {
                listNumbers.Add(r.Next(0, 100000));
            }
            // Run both square root methods on each of the random sample data numbers
            foreach(var num in listNumbers)
            {
                resultHeron = heronCalculator.GetHeronRoot(num, 1);
                resultStandard = standardCalculator.GetStandardRoot(num, 1);
                if (Math.Abs(resultHeron - resultStandard) < error)
                {
                    resultList.Add(true);
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
