//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;

//namespace SquareRootTest
//{
//    [TestClass]
//    public class ComparisonTest
//    {
//        [TestMethod]
//        public void ValidateAndCompareCalculationsWithinErrorLimits()
//        {
//            // Arrange
//            double error = 0.0001;
//            double resultHeron;
//            double resultStandard;
//            int resultTrue = 0;
//            List<bool> resultList = new List<bool>();
//            HeronCalculator heronCalculator = new HeronCalculator(error);
//            StandardCalculator standardCalculator = new StandardCalculator(error);
//            // Create random sample data to use for testing square root methods
//            Random r = new Random();
//            List<int> listNumbers = new List<int>();
//            for (int i = 1; i < 10001; i++)
//            {
//                listNumbers.Add(r.Next(1, 100000));
//            }
//            // Act

//            // Insert
//        }
//    }
//}

//// ------------------------------------------------------------
//private static double ValidateHeron()
//{
//    // A function to validate the accuracy of the Heron calculation vs. the internal Math.Sqrt function

//    // Run both square root methods on each of the random sample data numbers
//    foreach (var num in listNumbers)
//    {
//        resultHeron = heronCalculator.GetHeronRoot(num);
//        resultStandard = standardCalculator.GetStandardRoot(num);
//        if (Math.Abs(resultHeron - resultStandard) < error)
//        {
//            resultList.Add(true);
//            resultTrue++;
//        }
//        else
//        {
//            resultList.Add(false);
//            throw new Exception("The difference between the two methods is not within the accepted error rate.");
//        }
//    }

//    return resultTrue;
//}
