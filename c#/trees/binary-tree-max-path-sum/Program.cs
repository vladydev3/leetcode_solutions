class Solution
{
    private int maxSum = int.MinValue;

    public int MaxPathSum(TreeNode root)
    {
        MaxGain(root);
        return maxSum;
    }

    private int MaxGain(TreeNode node)
    {
        if (node == null) return 0;

        // Calculate the maximum sum on the left and right subtrees
        int leftGain = Math.Max(MaxGain(node.left), 0);
        int rightGain = Math.Max(MaxGain(node.right), 0);

        // Update maxSum if it's smaller than the new path sum
        int newPathSum = node.val + leftGain + rightGain;
        maxSum = Math.Max(maxSum, newPathSum);

        // For the recursion return only the max gain the node and one of its subtrees could add
        return node.val + Math.Max(leftGain, rightGain);
    }
}