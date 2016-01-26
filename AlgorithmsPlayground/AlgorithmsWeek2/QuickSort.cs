using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsWeek2
{
    public class QuickSort
    {
        public QuickSort()
        {
            this.TotalComparisons = 0;
        }

        public long TotalComparisons { get; private set; }

        public int[] Data { get; private set; }

        public void Start()
        {
            this.MyQuickSort(this.Data, 0, this.Data.Length);
        }

        public void ReadFromFile(string fileName)
        {
            List<int> intsInFile = new List<int>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                // Read the stream to a string, and write the string to the console.
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    intsInFile.Add(Convert.ToInt32(line));
                }
            }

            this.Data = intsInFile.ToArray();
        }

        /// <summary>
        /// This uses the first element as the pivot for the array
        /// </summary>
        /// <param name="arrayInts"></param>
        /// <returns></returns>
        public int FirstElementPivot(int[] arrayInts)
        {
            if (arrayInts.Length == 1 || arrayInts.Length == 0)
            {
                return 0;
            }

            int totalComparisons = arrayInts.Length - 1;

            int pivot = arrayInts[0];
            int pivotPosition = 1;

            for (int index = 1; index < arrayInts.Length; index++)
            {
                if (pivot > arrayInts[index])
                {
                    int temp = arrayInts[pivotPosition];
                    arrayInts[pivotPosition] = arrayInts[index];
                    arrayInts[index] = temp;

                    pivotPosition++;
                }
            }

            arrayInts[0] = arrayInts[pivotPosition - 1];
            arrayInts[pivotPosition -1] = pivot;

            int[] firstHalf = arrayInts.Take(pivotPosition - 1).ToArray();
            int[] secondHalf = arrayInts.Skip(pivotPosition).ToArray();

            totalComparisons = totalComparisons + this.FirstElementPivot(firstHalf);
            totalComparisons = totalComparisons + this.FirstElementPivot(secondHalf);

            return totalComparisons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">starting index for partition</param>
        /// <param name="end">ending index for partition</param>
        /// <returns></returns>
        public int PartitionFirstElementPivot(int[] array, int left, int right)
        {
            int pivotPosition = left;
            int pivot = array[pivotPosition];
            this.TotalComparisons = this.TotalComparisons + right - left - 1;

            for (int index = left; index < right; index++)
            {
                if (pivot > array[index])
                {
                    pivotPosition++;
                    this.Swap(array, pivotPosition, index);
                }
            }

            this.Swap(array, pivotPosition, left);

            return pivotPosition;
        }

        public int PartitionLastElementPivot(int[] array, int left, int right)
        {
            this.Swap(array, left, right - 1);

            return this.PartitionFirstElementPivot(array, left, right);
        }

        public int PartitionMedianPivot(int[] array, int left, int right)
        {
            int length = right - left;
            int median;

            if (length%2 == 0)
            {
                median = left + length/2 - 1;
            }
            else
            {
                median = left + length/2;
            }

            int pivot;
            int currentPosition;
            if (length >= 3)
            {
                int first = array[left];
                int second = array[right - 1];
                int third = array[median];

                Dictionary<int, int> pivots = new Dictionary<int, int>()
                {
                    {first, left},
                    {second, right - 1},
                    {third, median}
                };

                List<int> sortedPivots = pivots.Keys.ToList();
                sortedPivots.Sort();

                pivot = sortedPivots[1];
                currentPosition = pivots[pivot];

                this.Swap(array, left, currentPosition);
            }

            return this.PartitionFirstElementPivot(array, left, right);
        }


        public void MyQuickSort(int[] array, int left, int right)
        {
            this.Data = array;

            if (array == null || array.Length <= 1 || right <= left)
                return;

            if (left < right)
            {
                int pivotIndex = this.PartitionMedianPivot(array, left, right);
                this.MyQuickSort(array, left, pivotIndex);
                this.MyQuickSort(array, pivotIndex + 1, right);
            }
        }

        private void Swap(int[] ar, int a, int b)
        {
            int temp = ar[a];
            ar[a] = ar[b];
            ar[b] = temp;
        }
    }
}
