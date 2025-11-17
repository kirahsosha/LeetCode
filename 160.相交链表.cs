/*
 * @lc app=leetcode.cn id=160 lang=csharp
 *
 * [160] 相交链表
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
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        int a = 0;
        var na = headA;
        while (na != null)
        {
            a++;
            na = na.next;
        }
        int b = 0;
        var nb = headB;
        while (nb != null)
        {
            b++;
            nb = nb.next;
        }
        if (a < b)
        {
            na = headB;
            nb = headA;
            var c = a;
            a = b;
            b = c;
        }
        else
        {
            na = headA;
            nb = headB;
        }
        for (int i = 0; i < a - b; i++)
        {
            na = na.next;
        }
        while (na != null && nb != null)
        {
            if (na == nb) return na;
            na = na.next;
            nb = nb.next;
        }
        return null;
    }
}
// @lc code=end

