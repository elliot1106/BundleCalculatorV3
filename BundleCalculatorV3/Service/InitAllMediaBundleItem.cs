using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleCalculatorV3.Model;
using BundleCalculatorV3.Utility;

namespace BundleCalculatorV3.Service
{
    public static class InitAllMediaBundleItem
    {
        public static void Run()
        {
            AllMediaBundles.allBundles = new SortedDictionary<string, MediaBundles>();
            List<string> sections = IniHelper.ReadSections();
            foreach (var FormatType in sections)
            {
                List<SingleBundle> bundleTempList = new List<SingleBundle>();
                List<string> keys = IniHelper.ReadKeys(FormatType);
                foreach (var one in keys)
                {
                    string value = IniHelper.ReadValue(FormatType, one);

                    int posts = 0;
                    double charge = 0;
                    if (int.TryParse(one, out posts) && double.TryParse(value, out charge))
                    {
                        SingleBundle bundleEntity = new SingleBundle(posts, charge);
                        if (!bundleTempList.Contains(bundleEntity))
                            bundleTempList.Add(bundleEntity);
                    }
                    else
                    {
                        Console.WriteLine("error occured while getting bundles from ini ");
                    }
                }
                MediaBundles mediaBundles = new MediaBundles(FormatType);
                mediaBundles.BundleList=bundleTempList;
                mediaBundles.SortListByDecend();

                if (!AllMediaBundles.allBundles.ContainsKey(FormatType) && bundleTempList.Count > 0)
                {
                    AllMediaBundles.allBundles.Add(FormatType, mediaBundles);
                }
            }
        }


    }
}
