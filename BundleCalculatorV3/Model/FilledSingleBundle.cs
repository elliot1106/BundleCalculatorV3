using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleCalculatorV3.Model
{
    public class FilledSingleBundle:SingleBundle
    {
        public int CountNeeded { get; set; }

        public FilledSingleBundle(int postCount, double bundleCost):base(postCount,bundleCost)
        {

        }

        public FilledSingleBundle(SingleBundle singleBundle)
        {
            this.BundleCost = singleBundle.BundleCost;
            this.PostsCount = singleBundle.PostsCount;
        }

        public string GetBundleStr()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  ");
            sb.Append(CountNeeded);
            sb.Append(" x ");
            sb.Append(PostsCount);
            sb.Append(" $");
            sb.Append(BundleCost * CountNeeded);
            sb.Append("\n");
            return sb.ToString();
        }

    }
}
