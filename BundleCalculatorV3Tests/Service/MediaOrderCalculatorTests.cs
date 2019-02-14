using Microsoft.VisualStudio.TestTools.UnitTesting;
using BundleCalculatorV3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleCalculatorV3.Model;

namespace BundleCalculatorV3.Service.Tests
{
    [TestClass()]
    public class MediaOrderCalculatorTests
    {
        [TestMethod()]
        public void CalMediaOrderTest()
        {
            InitAllMediaBundleItem.Run();
            FilledMediaOrder filledMediaOrder = MediaOrderCalculator.CalMediaOrder(new MediaOrder("FLAC", 28));
            Assert.AreEqual(filledMediaOrder.offset, 2);

            List<int> actual = filledMediaOrder.filledBundleList.Select(item => item.CountNeeded).ToList();
            Assert.IsTrue(actual.SequenceEqual(new List<int> { 3, 0, 1 }));

        }
    }
}