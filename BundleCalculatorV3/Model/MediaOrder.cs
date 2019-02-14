using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleCalculatorV3.Model
{

    public class MediaOrder
    {
        public string MediaType { get;protected  set; }
        public int TargetPosts { get; protected set; }

        public MediaOrder(string mediaType, int targetPosts)
        {
            this.MediaType = mediaType;
            this.TargetPosts = targetPosts;
        }

    }
}
