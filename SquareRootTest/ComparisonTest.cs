using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SquareRoot;


namespace SquareRootTest
{
    [TestClass]
    public class ComparisonTest
    {
        [TestMethod]
        public void ValidateAndCompareCalculationsWithinErrorLimits(ISqrRt heronCalculator, ISqrRt standardCalculator, double error)
        {
            // Arrange
            double resultHeron;
            double resultStandard;
            bool resultComparison = false;
            // Create random sample data to use for testing square root methods
            Random r = new Random();
            List<int> listNumbers = new List<int>();
            for (int i = 1; i < 10001; i++)
            {
                listNumbers.Add(r.Next(1, 100000));
            }
            // Act
            // Run both square root methods on each of the random sample data numbers
            foreach (var num in listNumbers)
            {
                resultHeron = heronCalculator.GetSquareRoot(num);
                resultStandard = standardCalculator.GetSquareRoot(num);
                resultComparison = CompareRoots(resultHeron, resultStandard, error);
            }
            // Assert
            Assert.IsTrue(resultComparison);
        }
        public bool CompareRoots(double heron, double standard, double error)
        {        
            int resultTrue = 0;
            List<bool> resultList = new List<bool>();
            List<double> errorList = new List<double>();
            if (Math.Abs(heron - standard) < error)
            {
                resultList.Add(true);
                errorList.Add(Math.Abs(heron - standard));
                resultTrue++;
                return true;
            }
            else
            {
                resultList.Add(false);
                return false;
                //throw new Exception("The difference between the two methods is not within the accepted error rate.");
            }
        }
    }
}

