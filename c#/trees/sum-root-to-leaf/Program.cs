public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution
{
    public int SumNumbers(TreeNode root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return root.val;

        return SumNumbers(root, 0);
    }
    public int SumNumbers(TreeNode root, int sum)
    {
        if (root == null) return 0;
        if (root.right == null && root.left == null) return sum * 10 + root.val;

        sum += root.val;

        return SumNumbers(root.left, sum) + SumNumbers(root.right, sum);
    }
}