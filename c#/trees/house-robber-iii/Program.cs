// The thief has found himself a new place for his thievery again.There is only one entrance to this area, called root.

// Besides the root, each house has one and only one parent house.After a tour, the smart thief realized that all houses in this place form a binary tree.It will automatically contact the police if two directly - linked houses were broken into on the same night.

// Given the root of the binary tree, return the maximum amount of money the thief can rob without alerting the police.

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    // DFS Traversal
    public List<int> DFS(TreeNode root)
    {
        List<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();
            result.Add(node.val);

            if (node.right != null)
            {
                stack.Push(node.right);
            }

            if (node.left != null)
            {
                stack.Push(node.left);
            }
        }

        return result;
    }
}

public class Program
{
    static Dictionary<TreeNode, List<TreeNode>> nodeConnections = new Dictionary<TreeNode, List<TreeNode>>();

    static void Main()
    {
        TreeNode root = new TreeNode();
        // Populate the tree
        DFS(root, null);    
    }

    static void DFS(TreeNode node, TreeNode parent)
    {
        if (node != null)
        {
            if (!nodeConnections.ContainsKey(node))
            {
                nodeConnections[node] = new List<TreeNode>();
            }

            if (parent != null)
            {
                nodeConnections[node].Add(parent);
                if (!nodeConnections.ContainsKey(parent))
                {
                    nodeConnections[parent] = new List<TreeNode>();
                }
                nodeConnections[parent].Add(node);
            }

            DFS(node.left, node);
            DFS(node.right, node);
        }
    }
}