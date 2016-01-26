using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsClassWeek1
{
    public class CountInversions
    {
        public CountInversions()
        {
            
        }

        public SortedArray WeekOneAssignment()
        {
            List<int> intsInFile = new List<int>();

            using (StreamReader sr = new StreamReader("IntegerArray.txt"))
            {
                // Read the stream to a string, and write the string to the console.
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    intsInFile.Add(Convert.ToInt32(line));
                }
            }

            int[] assignment = intsInFile.ToArray();
            return this.CalculateInversions(assignment);
        }

        public SortedArray CalculateInversions(int[] array)
        {
            long totalInversions = 0;

            if (array.Length == 1)
            {
                return new SortedArray(array, totalInversions);
            }

            int[] firstHalf = array.Take(array.Length/2).ToArray();
            int[] secondHalf = array.Skip(array.Length/2).ToArray();

            SortedArray sortedFirstHalf = this.CalculateInversions(firstHalf);
            SortedArray sortedSecondHalf = this.CalculateInversions(secondHalf);

            int firstIndex = 0;
            int secondIndex = 0;

            int[] newArray = new int[array.Length];

            for (int newIndex = 0; newIndex < newArray.Length; newIndex++)
            {
                //TODO clean up this if statement
                if (secondIndex >= sortedSecondHalf.Array.Length || (firstIndex < sortedFirstHalf.Array.Length && sortedFirstHalf.Array[firstIndex] <= sortedSecondHalf.Array[secondIndex]))
                {
                    newArray[newIndex] = sortedFirstHalf.Array[firstIndex];
                    firstIndex++;
                }
                else
                {
                    totalInversions = totalInversions + (sortedFirstHalf.Array.Length - firstIndex);
                    newArray[newIndex] = sortedSecondHalf.Array[secondIndex];
                    secondIndex++;
                }
            }

            return new SortedArray(newArray, totalInversions + sortedFirstHalf.Inversions + sortedSecondHalf.Inversions);
        }
    }
}
