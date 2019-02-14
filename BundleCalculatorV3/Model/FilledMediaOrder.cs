using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleCalculatorV3.Algorithm;

namespace BundleCalculatorV3.Model
{
    public class FilledMediaOrder:MediaOrder
    {
        public int offset { get; set; }
        public List<FilledSingleBundle> filledBundleList = new List<FilledSingleBundle>();


        public FilledMediaOrder(string mediaType, int targetPosts):base(mediaType,targetPosts)
        {

        }


        public string GetOrderString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(filledBundleList.Sum(item => item.CountNeeded * item.PostsCount)-offset);
            if (this.offset > 0)
                sb.Append("+"+offset.ToString());
            sb.Append(" ");
            sb.Append(this.MediaType);
            sb.Append(" $");
            sb.Append(filledBundleList.Sum(item => item.BundleCost * item.CountNeeded));
            sb.Append("\n");
            foreach (var oneBundle in filledBundleList)
            {
                if (oneBundle.CountNeeded > 0)
                {
                    sb.Append(oneBundle.GetBundleStr());
                }
            }
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
