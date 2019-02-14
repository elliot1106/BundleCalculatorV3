using Microsoft.VisualStudio.TestTools.UnitTesting;
using BundleCalculatorV3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleCalculatorV3.Service.Tests
{
    [TestClass()]
    public class InitAllMediaBundlesTests
    {
        [TestMethod()]
        public void RunTest()
        {
            InitAllMediaBundleItem.Run();
            Assert.IsTrue(Model.AllMediaBundles.allBundles.Count == 3);
        }
    }
}