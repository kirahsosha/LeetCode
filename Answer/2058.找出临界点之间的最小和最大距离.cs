/*
 * @lc app=leetcode.cn id=2058 lang=csharp
 *
 * [2058] 找出临界点之间的最小和最大距离
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
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        if (head == null || head.next == null || head.next.next == null)
        {
            return [-1, -1];
        }

        int first = -1;
        int last = -1;
        int minDistance = int.MaxValue;
        int prev = head.val;
        int index = 1;

        for (var node = head.next; node.next != null; node = node.next, index++)
        {
            int next = node.next.val;
            bool isCritical = (node.val < prev && node.val < next) || (node.val > prev && node.val > next);
            if (isCritical)
            {
                if (first == -1)
                {
                    first = index;
                }
                else
                {
                    minDistance = Math.Min(minDistance, index - last);
                }
                last = index;
            }
            prev = node.val;
        }

        return minDistance == int.MaxValue ? [-1, -1] : [minDistance, last - first];
    }
}
// @lc code=end

