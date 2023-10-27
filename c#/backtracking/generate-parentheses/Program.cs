// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

// Example 1:
// Input: n = 3
// Output: ["((()))","(()())","(())()","()(())","()()()"]

// Example 2:
// Input: n = 1
// Output: ["()"]

// Constraints:
// 1 <= n <= 8

public class Solution
{
    public static void Main(string[] args)
    {
        var result = GenerateParenthesis(3);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
    public static IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        GenerateParenthesis(n, n, "", result);
        return result;
    }
    public static void GenerateParenthesis(int left, int right, string actual, List<string> result)
    {
        if (left == 0 && right == 0)
        {
            result.Add(actual);
            return;
        }
        if (left == right) GenerateParenthesis(left - 1, right, actual + "(", result);
        else if (left < right)
        {
            if (left > 0) GenerateParenthesis(left - 1, right, actual + "(", result);
            GenerateParenthesis(left, right - 1, actual + ")", result);
        }
    }
}