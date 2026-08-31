/*
 * @lc app=leetcode.cn id=2058 lang=typescript
 *
 * [2058] 找出临界点之间的最小和最大距离
 */

// @lc code=start
function nodesBetweenCriticalPoints(head: ListNode | null): number[] {
  if (head === null || head.next === null || head.next.next === null) {
    return [-1, -1];
  }

  let first = -1;
  let last = -1;
  let minDistance = Number.MAX_SAFE_INTEGER;
  let prev = head.val;
  let index = 1;

  for (
    let node = head.next;
    node !== null && node.next !== null;
    node = node.next, index++
  ) {
    const next = node.next.val;
    const isCritical =
      (node.val < prev && node.val < next) ||
      (node.val > prev && node.val > next);
    if (isCritical) {
      if (first === -1) {
        first = index;
      } else {
        minDistance = Math.min(minDistance, index - last);
      }
      last = index;
    }
    prev = node.val;
  }

  return minDistance === Number.MAX_SAFE_INTEGER
    ? [-1, -1]
    : [minDistance, last - first];
}
// @lc code=end
