using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleCalculatorV3.Model;

namespace BundleCalculatorV3.Algorithm
{
    public static class MiniumBundleCalculator
    {

        public static List<int> BundleList;
        public static FilledResult filledResult;

        public static FilledResult CalBundles(int target, List<int> inputList)
        {
            filledResult = new FilledResult(target,inputList.Count);
            BundleList = inputList;

            while (!tryGetBundles(filledResult.Target+filledResult.Offset,0))
            {
                filledResult.Offset++;
                for (int i = 0; i < filledResult.filledNumbers.Count; i++)
                    filledResult.filledNumbers[i] = 0;
            }
            return filledResult;
        }
    
        private static bool tryGetBundles(int restPostsAll, int startIndex)
        {
            for (int i = startIndex; i < BundleList.Count;)
            {
                int restPosts = restPostsAll % BundleList[i];
                int times = restPostsAll / BundleList[i];
                if (times > 0)
                {
                    filledResult.filledNumbers[i] = times;
                }
                if (restPosts == 0 && times != 0)
                {
                    return true;
                }   
                else
                {
                    i++;
                    if (tryGetBundles(restPosts, i))  
                        return true;
                    else
                    {
                        return tryRollBack();
                    }
                }
            }
            return false;
        }

        private static bool tryRollBack()
        {
            int rollBackIndex = BundleList.Count - 1;
            for (int m = BundleList.Count - 1; m >= 0; m--)
            {
                if (filledResult.filledNumbers[m] > 0)
                {
                    rollBackIndex = m;
                    break;
                }
            }
            for (int rollbackStep = 1; rollbackStep <= filledResult.filledNumbers[rollBackIndex]; rollbackStep++)
            {
                if (rollBack(rollBackIndex))
                    return true;
            }
            return false;
        }

        private static bool rollBack(int rollBackIndex)
        {
            filledResult.filledNumbers[rollBackIndex] -= 1;
            for (int i = rollBackIndex + 1; i < filledResult.filledNumbers.Count; i++)
            {
                filledResult.filledNumbers[i] = 0;
            }
            int restPostsAll = filledResult.Target - BundleList.Select( (item,index)=>item*filledResult.filledNumbers[index] ).Sum();
            return tryGetBundles(restPostsAll, rollBackIndex + 1);
        }





    }
}
