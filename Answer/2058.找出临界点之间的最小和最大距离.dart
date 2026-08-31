/*
 * @lc app=leetcode.cn id=2058 lang=dart
 *
 * [2058] 找出临界点之间的最小和最大距离
 */

// @lc code=start
class Solution {
  List<int> nodesBetweenCriticalPoints(ListNode? head) {
    if (head == null || head.next == null || head.next?.next == null) {
      return [-1, -1];
    }

    var first = -1;
    var last = -1;
    var minDistance = 1 << 30;
    var prev = head.val;
    var index = 1;

    for (var node = head.next; node != null && node.next != null; node = node.next, index++) {
      final next = node.next!.val;
      final isCritical = (node.val < prev && node.val < next) || (node.val > prev && node.val > next);
      if (isCritical) {
        if (first == -1) {
          first = index;
        } else {
          minDistance = minDistance < index - last ? minDistance : index - last;
        }
        last = index;
      }
      prev = node.val;
    }

    return minDistance == 1 << 30 ? [-1, -1] : [minDistance, last - first];
  }
}
// @lc code=end
