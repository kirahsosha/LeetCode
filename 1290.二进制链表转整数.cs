/*
 * @lc app=leetcode.cn id=1290 lang=csharp
 *
 * [1290] 二进制链表转整数
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
    public int GetDecimalValue(ListNode head) {
        int ans = 0;
        while(head != null)
        {
            ans = ans * 2 + head.val;
            head = head.next;
        }
        return ans;
    }
}
// @lc code=end

