/*
 * @lc app=leetcode.cn id=25 lang=csharp
 *
 * [25] K 个一组翻转链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    Stack<ListNode> list = new Stack<ListNode>();

    public ListNode[] reverse()
    {
        ListNode head = list.Pop();
        ListNode node = head;
        while(list.Count != 0)
        {
            ListNode p = list.Pop();
            node.next = p;
            node = node.next;
        }
        node.next = null;
        return new ListNode[]{head, node};
    }

    public ListNode ReverseKGroup(ListNode head, int k) {
        if(k == 1) return head;
        ListNode node = head;
        ListNode tail = null;
        head = null;
        while(node != null)
        {
            //压入K个ListNode
            while(node != null && list.Count < k)
            {
                list.Push(node);
                node = node.next;
            }
            if(list.Count < k) break;
            ListNode[] p = reverse();
            if(head == null)
            {
                head = p[0];
                tail = p[1];
            }
            else
            {
                tail.next = p[0];
                tail = p[1];
            }
        }
        while(list.Count != 0)
        {
            tail.next = list.Pop();
        }
        return head;
    }
}
// @lc code=end

