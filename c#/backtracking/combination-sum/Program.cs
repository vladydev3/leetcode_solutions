// Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

// The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.
// The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

// Example 1:
// Input: candidates = [2,3,6,7], target = 7
// Output: [[2,2,3],[7]]
// Explanation:
// 2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
// 7 is a candidate, and 7 = 7.

// Example 2:
// Input: candidates = [2,3,5], target = 8
// Output: [[2,2,2,2],[2,3,3],[3,5]]

// Example 3:
// Input: candidates = [2], target = 1
// Output: []

using System.Formats.Tar;
using System.Xml.XPath;

class Solution
{
    public static void Main(string[] args)
    {
        int[] candidates = { 2, 3, 6, 7 };

        var result = CombinationSum(candidates, 7);

        foreach (var item in result)
        {
            foreach (var num in item)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("");
        }
    }
    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<int[]> result = new List<int[]>(150);
        List<int> temp = new List<int>(target/2);

        CombinationSum(candidates, target, 0, result, temp);
        return result.ToArray();
    }
    public static void CombinationSum(int[] candidates, int target, int p, List<int[]> result, List<int> temp)
    {
        if (p >= candidates.Length && result.Count == 0 && temp.Count == 0) return;
        if (target == 0)
        {
            result.Add(temp.ToArray());
            return;
        }
        if (p >= candidates.Length) return;
        if (target < 0)
        {
            return;
        }

        // One
        temp.Add(candidates[p]);
        CombinationSum(candidates, target - candidates[p], p, result, temp);
        temp.RemoveAt(temp.Count - 1);

        // Zero
        CombinationSum(candidates, target, p + 1, result, temp);

        return;
    }
}