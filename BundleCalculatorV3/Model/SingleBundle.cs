using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleCalculatorV3.Model
{

    [Serializable]
    public class SingleBundle
    {
        public int PostsCount { get; protected set; }
        public double BundleCost { get; protected set; }

        public SingleBundle()
        {
        }
        public SingleBundle(int postCount,double bundleCost)
        {
            this.PostsCount = postCount;
            this.BundleCost = bundleCost;
        }

    }
}
