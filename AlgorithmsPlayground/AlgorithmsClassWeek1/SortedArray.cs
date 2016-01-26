using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsClassWeek1
{
    public class SortedArray
    {
        public SortedArray(int[] sortedArray, long inversions)
        {
            this.Array = sortedArray;
            this.Inversions = inversions;
        }

        public int[] Array
        {
            get; private set;
        }

        public long Inversions
        {
            get; private set;
        }
    }
}
