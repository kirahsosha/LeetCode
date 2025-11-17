/*
 * @lc app=leetcode.cn id=1171 lang=csharp
 *
 * [1171] 从链表中删去总和值为零的连续节点
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
    public ListNode RemoveZeroSumSublists(ListNode head) {
        if(head == null) return head;
        Hashtable map = new Hashtable();
        ListNode p = new ListNode {
            val = 0,
            next = head
        };
        head = p;
        int sum = 0;
        while(p != null)
        {
            sum += p.val;
            if(map.ContainsKey(sum))
            {
                map.Remove(sum);
                map.Add(sum, p);
            }
            else
            {
                map.Add(sum, p);
            }
            p = p.next;
        }
        p = head;
        sum = 0;
        while(p != null)
        {
            sum += p.val;
            if(map.ContainsKey(sum))
            {
                ListNode t = (ListNode)map[sum];
                p.next = t.next;
            }
            p = p.next;
        }
        return head.next;
    }
}
// @lc code=end

