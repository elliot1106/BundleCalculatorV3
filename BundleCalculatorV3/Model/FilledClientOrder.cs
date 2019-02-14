using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleCalculatorV3.Model
{
    public class FilledClientOrder
    {
        private List<FilledMediaOrder> filledOrderList = new List<FilledMediaOrder>();

        public string GetResutlStr()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var one in filledOrderList)
            {
                sb.Append(one.GetOrderString());
            }
            return sb.ToString();
        }

        public int  AddFilledMediaOrder(FilledMediaOrder filledMediaOrder)
        {
            this.filledOrderList.Add(filledMediaOrder);
            return filledOrderList.Count;
        }

        public int RemoveFilledMediaOrder(FilledMediaOrder filledMediaOrder)
        {
            this.filledOrderList.Remove(filledMediaOrder);
            return filledOrderList.Count;
        }

        public List<FilledMediaOrder> GetList()
        {
            return this.filledOrderList;
        }

        public List<int> GetBundles(int index)
        {
            if (index >= this.filledOrderList.Count)
                return new List<int>();
            return this.filledOrderList[index].filledBundleList.Select(item => item.CountNeeded).ToList();
        }


    }
}
