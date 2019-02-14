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
    public class ClientOrderCalculatorTests
    {
        [TestMethod()]
        public void CalClientOrderTest()
        {
            InitAllMediaBundleItem.Run();
            ClientOrder cli = new ClientOrder();
            cli.AddMediaOrder(new MediaOrder("IMG", 28));
            cli.AddMediaOrder(new MediaOrder("FLAC", 28));
            cli.AddMediaOrder(new MediaOrder("VID", 28));
            FilledClientOrder actual = ClientOrderCalculator.CalClientOrder(cli);

            Assert.IsTrue(actual.GetBundles(0).SequenceEqual(new List<int> { 3, 0 }));
            Assert.IsTrue(actual.GetBundles(1).SequenceEqual(new List<int> { 3, 0, 1 }));
            Assert.IsTrue(actual.GetBundles(2).SequenceEqual(new List<int> { 2, 2, 0 }));

            Assert.AreEqual(actual.GetList()[0].offset, 2);
            Assert.AreEqual(actual.GetList()[1].offset, 2);
            Assert.AreEqual(actual.GetList()[2].offset, 0);
        }
    }
}