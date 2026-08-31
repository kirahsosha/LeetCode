#
# @lc app=leetcode.cn id=2058 lang=python3
#
# [2058] 找出临界点之间的最小和最大距离
#

# @lc code=start
from typing import List, Optional

class Solution:
    def nodesBetweenCriticalPoints(self, head: Optional[ListNode]) -> List[int]:
        if head is None or head.next is None or head.next.next is None:
            return [-1, -1]

        first = -1
        last = -1
        min_distance = 10**18
        prev = head.val
        index = 1

        node = head.next
        while node.next is not None:
            next_val = node.next.val
            is_critical = (node.val < prev and node.val < next_val) or (node.val > prev and node.val > next_val)
            if is_critical:
                if first == -1:
                    first = index
                else:
                    min_distance = min(min_distance, index - last)
                last = index
            prev = node.val
            node = node.next
            index += 1

        if min_distance == 10**18:
            return [-1, -1]
        return [min_distance, last - first]
# @lc code=end
