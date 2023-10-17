// Find all valid combinations of k numbers that sum up to n such that the following conditions are true:
// Only numbers 1 through 9 are used.
// Each number is used at most once.
// Return a list of all possible valid combinations. The list must not contain the same combination twice, and the combinations may be returned in any order.

// Example 1:
// Input: k = 3, n = 7
// Output: [[1,2,4]]
// Explanation:
// 1 + 2 + 4 = 7
// There are no other valid combinations.

// Example 2:
// Input: k = 3, n = 9
// Output: [[1,2,6],[1,3,5],[2,3,4]]
// Explanation:
// 1 + 2 + 6 = 9
// 1 + 3 + 5 = 9
// 2 + 3 + 4 = 9
// There are no other valid combinations.

// Example 3:
// Input: k = 4, n = 1
// Output: []
// Explanation: There are no valid combinations.
// Using 4 different numbers in the range [1,9], the smallest sum we can get is 1+2+3+4 = 10 and since 10 > 1, there are no valid combination.

// Constraints:
// 2 <= k <= 9
// 1 <= n <= 60



public class Solution
{
    public static void Main(string[] args)
    {
        var result = CombinationSum3(3,9);
        foreach (var item in result)
        {
            Console.WriteLine(string.Join(",", item));
        }
        
    }
    public static IList<IList<int>> CombinationSum3(int k, int n)
    {
        HashSet<List<int>> result = new();
        List<int> actual = new(k);
        if (n == 1) return result.ToArray();

        void Solve(int k, int n, List<int> actual, int idx)
        {
            if (n == 0 && actual.Count == k)
            {
                result.Add(new List<int>(actual));
                return;
            }
            if (n < 0) return;
            if (actual.Count == k) return;

            for (int i = idx; i <= n; i++)
            {
                actual.Add(i);
                Solve(k, n - i, actual, i+1);
                actual.Remove(i);
            }
        }
        Solve(k, n, actual, 1);
        return result.ToArray();
    }
}