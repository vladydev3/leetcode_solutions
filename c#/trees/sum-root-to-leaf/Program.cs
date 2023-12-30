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
class Program
{
    public static void Main()
    {
        var tree = new TreeNode(4, new TreeNode(9, new TreeNode(5), new TreeNode(1)), new TreeNode(0));

        Console.WriteLine(SumRootToLeaf(tree));
    }
    public static int SumRootToLeaf(TreeNode root)
    {
        if (root == null) return 0;
        var enumerable = SumRootToLeafHelper(root, root.val, string.Empty);
        var listNums = new List<int>(enumerable.Count());

        foreach (var num in enumerable)
        {
            listNums.Add(int.Parse(num));
        }

        return listNums.Sum();
    }
    public static IEnumerable<string> SumRootToLeafHelper(TreeNode tree, int root, string str)
    {
        // Base case (tree is leaf)
        if (tree.left == null && tree.right == null) yield return str + root.ToString();

        str += root.ToString();
        IEnumerable<string> left;
        IEnumerable<string> right;

        if (tree.left != null)
        {
            left = SumRootToLeafHelper(tree.left, tree.left.val, str);

            foreach (var item in left)
            {
                yield return item;
            }
        }
        if (tree.right != null)
        {
            right = SumRootToLeafHelper(tree.right, tree.right.val, str);

            foreach (var item in right)
            {
                yield return item;
            }
        }

    }
}