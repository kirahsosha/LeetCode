#
# @lc app=leetcode.cn id=2147 lang=python3
#
# [2147] 分隔长廊的方案数
#

# @lc code=start
class Solution:
    def numberOfWays(self, corridor: str) -> int:
        MOD = 1000000007
        lst = []
        for i in range(len(corridor)):
            if corridor[i] == 'S':
                lst.append(i)
        if len(lst) == 0 or len(lst) % 2 == 1:
            return 0;
        index = 0
        res = 1
        for i in range(1, len(lst) - 1):
            if index == 0:
                index = lst[i]
            else:
                res = res * (lst[i] - index) % MOD
                index = 0
        return res
        
# @lc code=end

