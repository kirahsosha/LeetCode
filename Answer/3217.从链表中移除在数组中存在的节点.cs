/*
 * @lc app=leetcode.cn id=3217 lang=csharp
 *
 * [3217] 从链表中移除在数组中存在的节点
 */

// @lc code=start
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
public class Solution
{
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        HashSet<int> isExist = new HashSet<int>(nums);
        while (head != null && isExist.Contains(head.val))
        {
            head = head.next;
        }
        if (head == null) return head;
        var node = head;
        while (node.next != null)
        {
            if (isExist.Contains(node.next.val))
            {
                node.next = node.next.next;
            }
            else
            {
                node = node.next;
            }
        }

        return head;
    }
}
// @lc code=end

