using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    public class TwoSumCalculator
    {
        private Dictionary<long, long> hashTable;

        private ConcurrentDictionary<int, KeyValuePair<long, long>> distinctSums = new ConcurrentDictionary<int, KeyValuePair<long, long>>();
 
        public TwoSumCalculator()
        {
            this.Complete = new TaskCompletionSource<bool>();
        }

        public TaskCompletionSource<bool> Complete
        {
            get; private set;
        } 

        public int Count
        {
            get { return this.distinctSums.Count; }
        }

        public void CalculateTwoSums(string fileName, int lowerBound, int upperBound)
        {
            this.ReadFromFile(fileName);
            this.CalculateTwoSums(lowerBound, upperBound);
        }

        private void ReadFromFile(string fileName)
        {
            this.hashTable = new Dictionary<long, long>();

            string[] numbers = File.ReadAllLines(@fileName);

            foreach (string newValue in numbers)
            {
                long intValue = Convert.ToInt64(newValue);

                if (!this.hashTable.ContainsKey(intValue))
                {
                    this.hashTable.Add(intValue, intValue);
                }
            }
        }

        private void CalculateTwoSums(int lowerBound, int upperBound)
        {
            for (int currentSum = lowerBound; currentSum <= upperBound; currentSum++)
            {
                Action twoSum = new Action(() =>
                {
                    foreach (long value in this.hashTable.Values)
                    {
                        if (!distinctSums.ContainsKey(currentSum))
                        {
                            long searchValue = currentSum - value;
                            long otherValue = 0;

                            if (searchValue != value && this.hashTable.TryGetValue(searchValue, out otherValue))
                            {
                                distinctSums.TryAdd(currentSum, new KeyValuePair<long, long>(value, otherValue));
                            }
                        }
                    }

                    if (currentSum == upperBound)
                    {
                        this.Complete.TrySetResult(true);
                    }
                });

                twoSum.BeginInvoke(null, null);
            }
        }
    }
}
