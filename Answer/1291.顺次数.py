#
# @lc app=leetcode.cn id=1291 lang=python3
#
# [1291] 顺次数
#

# @lc code=start
class Solution:
    def sequentialDigits(self, low: int, high: int) -> List[int]:
        res = []
        delta = 1
        offset = 0
        for length in range(2, 10):
            delta = delta * 10 + 1
            offset = offset * 10 + (length - 1)

            min_num = delta + offset
            if min_num > high:
                break
            max_num = (10 - length) * delta + offset
            if max_num < low:
                continue
            for start in range(1, 11 - length):
                num = start * delta + offset
                if num < low:
                    continue
                if num > high:
                    break
                res.append(num)
        return res
# @lc code=end
