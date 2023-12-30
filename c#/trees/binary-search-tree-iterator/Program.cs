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

public class BSTIterator(TreeNode root)
{
    readonly int[] InOrder = InOrderTraversal(root).ToArray();
    int Pointer = 0;

    public int Next()
    {
        return InOrder[Pointer++];
    }

    public bool HasNext()
    {
        return Pointer < InOrder.Length - 1;
    }

    public static IEnumerable<int> InOrderTraversal(TreeNode root)
    {
        if (root == null) yield break;

        var left = InOrderTraversal(root.left);

        foreach (var item in left)
        {
            yield return item;
        }

        yield return root.val;

        var right = InOrderTraversal(root.right);

        foreach (var item in right)
        {
            yield return item;
        }
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */