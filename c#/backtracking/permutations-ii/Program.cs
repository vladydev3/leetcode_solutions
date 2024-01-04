public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        List<IList<int>> results = [];
        List<int> perm = [];
        Dictionary<int, int> count = [];

        foreach (var num in nums)
        {
            if (count.ContainsKey(num))
            {
                count[num] += 1;
            }
            else
            {
                count[num] = 1;
            }
        }

        void DFS()
        {
            if (perm.Count == nums.Length)
            {
                List<int> result = [];
                foreach (var item in perm)
                {
                    result.Add(item);
                }
                results.Add(result);
            }
            foreach (int key in count.Keys)
            {
                if (count[key] > 0)
                {
                    perm.Add(key);
                    count[key] -= 1;
                    DFS();
                    count[key] += 1;
                    perm.RemoveAt(perm.Count - 1);
                }
            }
        }

        DFS();
        return results;
    }
}