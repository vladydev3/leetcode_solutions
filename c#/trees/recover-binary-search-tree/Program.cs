// You are given the root of a binary search tree (BST), where the values of exactly two nodes of the tree were swapped by mistake. Recover the tree without changing its structure.

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public void RecoverTree(TreeNode root)
    {
        var nodes = InOrderTraversal(root).ToList();
        TreeNode first = null;
        TreeNode second = null;
        int idx = 0;

        for (var i = 0; i < nodes.Count - 1; i++)
        {
            if (nodes[i].val > nodes[i + 1].val)
            {
                if (first == null)
                {
                    first = nodes[i];
                    idx = i + 1;
                }
                second = nodes[i + 1];
            }
        }

        if (first != null && second != null)
        {
            Swap(first, second);
        }
        if (first != null && second == null)
        {
            Swap(first, nodes[idx]);
        }
    }

    private IEnumerable<TreeNode> InOrderTraversal(TreeNode root)
    {
        if (root == null)
        {
            yield break;
        }

        foreach (var node in InOrderTraversal(root.left))
        {
            yield return node;
        }

        yield return root;

        foreach (var node in InOrderTraversal(root.right))
        {
            yield return node;
        }
    }

    private void Swap(TreeNode first, TreeNode second)
    {
        var temp = first.val;
        first.val = second.val;
        second.val = temp;
    }
}