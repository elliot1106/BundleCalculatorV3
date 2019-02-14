using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleCalculatorV3.Model
{
    public class MediaBundles
    {
        public string MediaType { get; private set; }
        public List<SingleBundle> BundleList = new List<SingleBundle>();

        public MediaBundles(string mediaType)
        {
            this.MediaType = MediaType;
        }

        public void SortListByDecend()
        {
            if (this.BundleList != null && this.BundleList.Count > 1)
            {
                BundleList.Sort((x,y)=>-x.BundleCost.CompareTo(y.BundleCost));
            }
        }

    }
}
