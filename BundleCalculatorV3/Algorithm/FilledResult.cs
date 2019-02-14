using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleCalculatorV3.Model;

namespace BundleCalculatorV3.Algorithm
{
    public class FilledResult
    {
        public int Target { get; private set; }    
        public int Offset { get; set; }
        public List<int> filledNumbers { get; set; }

        public FilledResult(int target,int listLength)
        {
            this.Target = target;
            this.Offset = 0;
            this.filledNumbers = new List<int>(listLength);
            for (int i = 0; i < listLength; i++)
            {
                filledNumbers.Add(0);
            }
        }

    }
}
