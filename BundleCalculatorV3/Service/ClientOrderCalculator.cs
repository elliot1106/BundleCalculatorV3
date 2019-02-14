using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleCalculatorV3.Algorithm;
using BundleCalculatorV3.Model;

namespace BundleCalculatorV3.Service
{
    public static class ClientOrderCalculator
    {
        public static FilledClientOrder CalClientOrder(ClientOrder clientOrder)
        {
            FilledClientOrder filledClientOrder = new FilledClientOrder();
            try
            {
                foreach (var oneMediaOrder in clientOrder.GetList())
                {
                    if (AllMediaBundles.allBundles.ContainsKey(oneMediaOrder.MediaType))
                    {
                        FilledMediaOrder filledMediaOrder = MediaOrderCalculator.CalMediaOrder(oneMediaOrder);
                        filledClientOrder.AddFilledMediaOrder(filledMediaOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return filledClientOrder;
        }

    }
}
