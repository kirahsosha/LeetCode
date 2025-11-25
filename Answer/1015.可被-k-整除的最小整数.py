#
# @lc app=leetcode.cn id=1015 lang=python3
#
# [1015] 可被 K 整除的最小整数
#

# @lc code=start
class Solution:
    def smallestRepunitDivByK(self, k: int) -> int:
        s = set()
        n = 0
        for i in range(1, k + 1):
            n = (n * 10 + 1) % k
            if n == 0:
                return i
            elif n in s:
                return -1
            else:
                s.add(n)
        return -1

        
# @lc code=end

