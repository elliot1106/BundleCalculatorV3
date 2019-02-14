using Microsoft.VisualStudio.TestTools.UnitTesting;
using BundleCalculatorV3.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleCalculatorV3.Algorithm.Tests
{
    [TestClass()]
    public class MiniumBundleCalculatorTests
    {

        [TestMethod()]
        public void CalBundlesTest()
        {
            FilledResult actual = MiniumBundleCalculator.CalBundles(28, new List<int> { 9, 6, 3 });
            Assert.AreEqual(2, actual.Offset);
            Assert.IsTrue(actual.filledNumbers.SequenceEqual(new List<int> { 3, 0, 1 }));
        }
    }
}