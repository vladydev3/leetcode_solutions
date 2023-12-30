//   Definition for a binary tree node.
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
    public void Flatten(TreeNode root)
    {
        var bfs = BFS(root).ToArray();
        Array.Sort(bfs);
        if (bfs == null || bfs.Length == 0) return;

        var current = root;
        current.val = bfs[0];

        for (var i = 1; i < bfs.Length; i++)
        {
            current.right = new TreeNode(bfs[i]);
            current.left = null;
            current = current.right;
        }
    }
    private IEnumerable<int> BFS(TreeNode tree)
    {

        if (tree == null)
        {
            yield break;
        }

        var queue = new Queue<TreeNode>();
        var visited = new HashSet<TreeNode>();

        queue.Enqueue(tree);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (!visited.Add(current)) continue;

            yield return current.val;

            if (current.right != null) queue.Enqueue(current.right);
            if (current.left != null) queue.Enqueue(current.left);
        }
    }
}