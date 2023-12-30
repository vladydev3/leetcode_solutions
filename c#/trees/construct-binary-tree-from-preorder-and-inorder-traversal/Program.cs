// Definition for a binary tree node.
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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        var root = new TreeNode(preorder[0]);

        var leftSubTree = new List<int>();
        var rightSubTree = new List<int>();

        for (int i = 0; i < inorder.Length; i++)
        {
            if (inorder[i] == preorder[0])
            {
                leftSubTree = inorder.Take(i).ToList();
                rightSubTree = inorder.Skip(i + 1).ToList();
                break;
            }
        }

        if (leftSubTree.Count > 0)
        {
            root.left = BuildTree(preorder.Skip(1).Take(leftSubTree.Count).ToArray(), leftSubTree.ToArray());
        }

        if (rightSubTree.Count > 0)
        {
            root.right = BuildTree(preorder.Skip(1 + leftSubTree.Count).ToArray(), rightSubTree.ToArray());
        }

        return root;
    }
}