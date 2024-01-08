public class Solution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();
        var current = new List<int>();
        SubsetsWithDup(nums, 0, current, result);
        return result;
    }
    public void SubsetsWithDup(int[] nums, int start, List<int> current, List<IList<int>> result)
    {
        result.Add(new List<int>(current));
        for (int i = start; i < nums.Length; i++)
        {
            if (i > start && nums[i] == nums[i - 1]) continue;
            current.Add(nums[i]);
            SubsetsWithDup(nums, i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}