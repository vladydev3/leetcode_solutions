// Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sum to target.
// Each number in candidates may only be used once in the combination.
// Note: The solution set must not contain duplicate combinations.

// Example 1:
// Input: candidates = [10,1,2,7,6,1,5], target = 8
// Output: 
// [
// [1,1,6],
// [1,2,5],
// [1,7],
// [2,6]
// ]


// Example 2:
// Input: candidates = [2,5,2,1,2], target = 5
// Output: 
// [
// [1,2,2],
// [5]
// ]

using System.Collections;

class Solution
{
    public static void Main(string[] args)
    {
        int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };

        var result = CombinationSum2(candidates, 8);

        foreach (var item in result)
        {
            foreach (var num in item)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("");
        }
    }
    public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        List<int[]> result = new List<int[]>();
        List<int> temp = new List<int>(target);

        Array.Sort(candidates);

        CombinationSum2(candidates, target, 0, result, temp);
        return result.ToArray();
    }
    public static void CombinationSum2(int[] candidates, int target, int p, List<int[]> result, List<int> temp)
    {
        if (target == 0)
        {
            result.Add(temp.ToArray());
            return;
        }
        if (p == candidates.Length) return;
        if (target < 0) return;

        temp.Add(candidates[p]);
        CombinationSum2(candidates, target - candidates[p], p + 1, result, temp);
        temp.RemoveAt(temp.Count - 1);

        while (p + 1 < candidates.Length && candidates[p] == candidates[p + 1])
            {
                p++;
            }

        CombinationSum2(candidates, target, p + 1, result, temp);

        return;
    }
}