public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        var temp = new List<int>();
        Backtrack(result, temp, n, k, 1);
        return result;
    }
    void Backtrack(List<IList<int>> result, List<int> temp, int n, int k, int start)
    {
        if (temp.Count == k)
        {
            result.Add(new List<int>(temp));
            return;
        }
        for (int i = start; i <= n; i++)
        {
            temp.Add(i);
            Backtrack(result, temp, n, k, i + 1);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}