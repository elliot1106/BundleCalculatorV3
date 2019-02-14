using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleCalculatorV3.Model
{
    public class ClientOrder
    {
        private List<MediaOrder> OrderList = new List<MediaOrder>();

        public int AddMediaOrder(MediaOrder mediaOrder)
        {
            this.OrderList.Add(mediaOrder);
            return OrderList.Count;
        }

        public int RemoveMediaOrder(MediaOrder mediaOrder)
        {
            this.OrderList.Remove(mediaOrder);
            return OrderList.Count;
        }

        public List<MediaOrder> GetList()
        {
            return this.OrderList;
        }


    }
}
