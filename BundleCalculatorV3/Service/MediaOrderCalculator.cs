using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleCalculatorV3.Algorithm;
using BundleCalculatorV3.Model;

namespace BundleCalculatorV3.Service
{
    public static class MediaOrderCalculator
    {

        public static FilledMediaOrder CalMediaOrder(MediaOrder mediaOrderItem)
        {
            MediaBundles mediaBundles = AllMediaBundles.allBundles[mediaOrderItem.MediaType];
            FilledMediaOrder filledMediaOrder = new FilledMediaOrder(mediaOrderItem.MediaType, mediaOrderItem.TargetPosts);
            try
            {
                FilledResult filledResult = MiniumBundleCalculator.CalBundles(mediaOrderItem.TargetPosts, mediaBundles.BundleList.Select(item => item.PostsCount).ToList());
                filledMediaOrder.offset = filledResult.Offset;

                for (int i = 0; i < filledResult.filledNumbers.Count; i++)
                {
                    FilledSingleBundle filledSingleBundle = new FilledSingleBundle(mediaBundles.BundleList[i]);
                    filledSingleBundle.CountNeeded = filledResult.filledNumbers[i];
                    filledMediaOrder.filledBundleList.Add(filledSingleBundle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return filledMediaOrder;

        }

    }
}
