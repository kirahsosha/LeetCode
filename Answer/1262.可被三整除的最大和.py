#
# @lc app=leetcode.cn id=1262 lang=python3
#
# [1262] 可被三整除的最大和
#

# @lc code=start
class Solution:
    def maxSumDivThree(self, nums: List[int]) -> int:
        res = 0
        min1, min12, min2, min22 = 0, 0, 0, 0
        for num in nums:
            res += num
            if num % 3 == 1:
                if min1 == 0 or num <= min1:
                    min12 = min1
                    min1 = num
                elif min12 == 0 or num <= min12:
                    min12 = num
            elif num % 3 == 2:
                if min2 == 0 or num <= min2:
                    min22 = min2
                    min2 = num
                elif min22 == 0 or num <= min22:
                    min22 = num
        if res % 3 == 1:
            if min1 == 0:
                res = res - min2 - min22
            elif min22 == 0:
                res = res - min1
            else:
                res = max(res - min1, res - min2 - min22)
        elif res % 3 == 2:
            if min2 == 0:
                res = res - min1 - min12
            elif min12 == 0:
                res = res - min2
            else:
                res = max(res - min2, res - min1 - min12)
        return res
        
# @lc code=end

