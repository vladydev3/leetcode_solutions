// Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
// Input: nums = [1,2,3]
// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

public class Solution
{
    public static void Main(string[] args)
    {
        var s = new Solution();
        var result = s.Permute(new int[] { 1, 2, 3 });
        foreach (var item in result)
        {
            Console.WriteLine(string.Join(",", item));
        }
    }
    public IList<IList<int>> Permute(int[] nums)
    {
        var a = nums.ToList();
        return Permute(a);
    }
    public IList<IList<int>> Permute(List<int> nums)
    {
        if (nums.Count == 0) return new List<IList<int>>();
        if (nums.Count == 1) return new List<IList<int>> { new List<int> { nums[0] } };

        List<IList<int>> result = new();

        for (int i = 0; i < nums.Count; i++)
        {
            int temp = nums[0];
            nums.RemoveAt(0);
            var subResult = Permute(nums);
            foreach (var item in subResult)
            {
                item.Add(temp);
                result.Add(item);
            }
            nums.Add(temp);
        }

        return result;
    }

}