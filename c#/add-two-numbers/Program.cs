﻿// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
// You may assume the two numbers do not contain any leading zero, except the number 0 itself.

// Example 1:
// Input: l1 = [2,4,3], l2 = [5,6,4]
// Output: [7,0,8]
// Explanation: 342 + 465 = 807.

// Example 2:
// Input: l1 = [0], l2 = [0]
// Output: [0]

// Example 3:
// Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
// Output: [8,9,9,9,0,0,0,1]
 
// Constraints:
// The number of nodes in each linked list is in the range [1, 100].
// 0 <= Node.val <= 9
// It is guaranteed that the list represents a number that does not have leading zeros.

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode reversedL1 = ReverseList(l1);
        ListNode reversedL2 = ReverseList(l2);
        ListNode result = new ListNode();

        long numL1 = GetNumber(reversedL1);
        long numL2 = GetNumber(reversedL2);

        long sum = numL1 + numL2;
        string sumStr = sum.ToString();
        for (int i = 0; i < sumStr.Length; i++) {
            result.val = int.Parse(sumStr[i].ToString());
            if (i != sumStr.Length - 1) {
                result.next = new ListNode();
                result = result.next;
            }
        }
        return ReverseList(result);        
    }
    public static ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode current = head;
        while (current != null) {
            ListNode nextTemp = current.next;
            current.next = prev;
            prev = current;
            current = nextTemp;
        }
        return prev;
    }
    public static long GetNumber(ListNode head) {
        long result = 0;
        while (head != null) {
            result += head.val
            head = head.next;
        }
        return result;
    }
}