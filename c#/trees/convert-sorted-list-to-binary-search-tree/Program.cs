// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

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
    public TreeNode SortedListToBST(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        if (head.next == null)
        {
            return new TreeNode(head.val);
        }

        ListNode pointer1 = head;
        ListNode pointer2 = head;
        ListNode prev = null;

        while (pointer2.next != null && pointer2.next.next != null)
        {
            prev = pointer1;
            pointer1 = pointer1.next;
            pointer2 = pointer2.next.next;
        }

        ListNode mid = pointer1;

        var root = new TreeNode(mid.val);

        if (prev != null)
        {
            prev.next = null;
            root.left = SortedListToBST(head);
        }

        root.right = SortedListToBST(mid.next);

        return root;
    }
}