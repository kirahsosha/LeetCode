/*
 * @lc app=leetcode.cn id=2058 lang=java
 *
 * [2058] 找出临界点之间的最小和最大距离
 */

// @lc code=start
class Solution {

    public int[] nodesBetweenCriticalPoints(ListNode head) {
        if (head == null || head.next == null || head.next.next == null) {
            return new int[]{-1, -1};
        }

        int first = -1;
        int last = -1;
        int minDistance = Integer.MAX_VALUE;
        int prev = head.val;
        int index = 1;

        for (ListNode node = head.next; node.next != null; node = node.next, index++) {
            int next = node.next.val;
            boolean isCritical = (node.val < prev && node.val < next) || (node.val > prev && node.val > next);
            if (isCritical) {
                if (first == -1) {
                    first = index;
                } else {
                    minDistance = Math.min(minDistance, index - last);
                }
                last = index;
            }
            prev = node.val;
        }

        return minDistance == Integer.MAX_VALUE ? new int[]{-1, -1} : new int[]{minDistance, last - first};
    }
}
// @lc code=end
