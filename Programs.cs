using System;
using System.Collections.Generic;

public class Program {
  public static List<int[]> FourNumberSum(int[] array, int targetSum)
    {
        // Initialize a dictionary to store pairs of numbers and their sums
        Dictionary<int, List<int[]>> pairSums = new Dictionary<int, List<int[]>>();
        // List to store the resulting quadruplets
        List<int[]> quadruplets = new List<int[]>();

        // Traverse through the array from the second element to the end
        for (int i = 1; i < array.Length - 1; i++)
        {
            // Check for pairs in the array to the right of the current element
            for (int j = i + 1; j < array.Length; j++)
            {
                int currentSum = array[i] + array[j];
                int difference = targetSum - currentSum;

                // If the difference is found in the dictionary, form quadruplets
                if (pairSums.ContainsKey(difference))
                {
                    foreach (var pair in pairSums[difference])
                    {
                        quadruplets.Add(new int[] { pair[0], pair[1], array[i], array[j] });
                    }
                }
            }

            // Add pairs from the left side of the current element to the dictionary
            for (int k = 0; k < i; k++)
            {
                int currentSum = array[i] + array[k];
                if (!pairSums.ContainsKey(currentSum))
                {
                    pairSums[currentSum] = new List<int[]>();
                }
                pairSums[currentSum].Add(new int[] { array[k], array[i] });
            }
        }

        return quadruplets;
    }
}
