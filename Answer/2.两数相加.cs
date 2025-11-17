/*
 * @lc app=leetcode.cn id=2 lang=csharp
 *
 * [2] 两数相加
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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int a = 0;
        ListNode l, l3, l4;
        l = l1;
        l3 = l1;
        l4 = l2;
        //同时遍历直到其中一个链表到末尾，相加并加上进位
        while(l1 != null && l2 != null)
        {
            a += l1.val + l2.val;
            l1.val = a % 10;
            a /= 10;
            l3 = l1;
            l1 = l1.next;
            l2 = l2.next;
        }
        //l1剩余节点加进位
        if(l1 != null)
        {
            while(l1 != null)
            {
                a += l1.val;
                l1.val = a % 10;
                a /= 10;
                l3 = l1;
                l1 = l1.next;
            }
            if(a > 0 && a < 10)
            {
                l3.next = l4;
                l4.val = a;
                l4.next = null;
            }
            else if(a > 10)
            {
                l3.next = l4;
                l4.val = a % 10;
                l3 = l4;
                l4 = new ListNode(1);
                l3.next = l4;
                l4.val = 1;
                l4.next = null;
            }
        }
        //l2剩余节点拼接到l1上，加进位
        else if(l2 != null)
        {
            l3.next = l2;
            l1 = l3.next;
            while(l1 != null)
            {
                a += l1.val;
                l1.val = a % 10;
                a /= 10;
                l3 = l1;
                l1 = l1.next;
            }
            if(a > 0 && a < 10)
            {
                l3.next = l4;
                l4.val = a;
                l4.next = null;
            }
            else if(a > 10)
            {
                l3.next = l4;
                l4.val = a % 10;
                l3 = l4;
                l4 = new ListNode(1);
                l3.next = l4;
                l4.val = 1;
                l4.next = null;
            }
        }
        //最高位有进位，补位，
        else if(a != 0)
        {
            if(a < 10)
            {
                l3.next = l4;
                l4.val = a;
                l4.next = null;
            }
            else
            {
                l3.next = l4;
                l4.val = a % 10;
                l4 = l4.next;
                l4.val = 1;
                l4.next = null;
            }
        }
        return l;
    }
}
// @lc code=end

