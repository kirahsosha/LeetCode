#
# @lc app=leetcode.cn id=1331 lang=python3
#
# [1331] 数组序号转换
#

# @lc code=start
class Solution:
    def arrayRankTransform(self, arr: List[int]) -> List[int]:
        sorted_arr = sorted(arr)
        rank = {}
        r = 1
        for num in sorted_arr:
            if num not in rank:
                rank[num] = r
                r += 1
        return [rank[x] for x in arr]
# @lc code=end
