/*
 * @lc app=leetcode.cn id=24 lang=csharp
 *
 * [24] 两两交换链表中的节点
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
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null) return head;

        //Swap head
        var node = head;
        head = node.next;
        node.next = head.next;
        head.next = node;

        //Swap next
        while (node.next != null && node.next.next != null)
        {
            var t = node.next;
            var k = t.next;
            node.next = k;
            t.next = k.next;
            k.next = t;
            node = t;
        }
        return head;
    }
}
// @lc code=end

