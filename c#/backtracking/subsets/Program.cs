public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> subset = new List<int>();

        void DFS(int idx)
        {
            if (idx >= nums.Length)
            {
                int[] aux = new int[subset.Count];
                for(int i=0; i<subset.Count;i++)
                {
                    aux[i] = subset[i];
                }
                result.Add(aux.ToList());
                return;
            }

            // include de num in the actual index
            subset.Add(nums[idx]);
            DFS(idx+1);

            // not include
            subset.RemoveAt(subset.Count-1);
            DFS(idx+1);
        }

        DFS(0);
        return result;
    }
}