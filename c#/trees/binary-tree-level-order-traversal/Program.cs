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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var bfs = BFS(root).ToArray();

        if (!bfs.Any()) // Comprueba si 'bfs' está vacío
        {
            return new List<IList<int>>(); // Si está vacío, devuelve una lista vacía
        }

        IList<IList<int>> toReturn = new List<IList<int>>();

        int maxLevel = bfs.Max(x => x.Item2);

        for (int i = 0; i <= maxLevel; i++)
        {
            toReturn.Add(new List<int>());
        }

        for (int i = 0; i < bfs.Length; i++)
        {
            var (value, level) = bfs[i];

            toReturn[level].Add(value);
        }

        return toReturn;
    }

    private IEnumerable<(int, int)> BFS(TreeNode tree)
    {
        int level = 0;

        if (tree == null)
        {
            yield break;
        }

        var queue = new Queue<(TreeNode, int)>();
        var visited = new HashSet<TreeNode>();

        queue.Enqueue((tree, level));

        while (queue.Count > 0)
        {
            var (current, currentLevel) = queue.Dequeue();

            if (!visited.Add(current)) continue;

            yield return (current.val, currentLevel);

            if (current.right != null) queue.Enqueue((current.right, currentLevel + 1));
            if (current.left != null) queue.Enqueue((current.left, currentLevel + 1));
        }
    }

}