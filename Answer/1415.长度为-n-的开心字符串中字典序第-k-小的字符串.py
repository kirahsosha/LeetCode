#
# @lc app=leetcode.cn id=1415 lang=python3
#
# [1415] 长度为 n 的开心字符串中字典序第 k 小的字符串
#

# @lc code=start
class Solution:
    def getHappyString(self, n: int, k: int) -> str:
        chars = ['a', 'b', 'c']
        res = ""
        if k > (3 * (1 << (n - 1))):
            return res
        for i in range(0, n):
            count = 1 << (n - i - 1)
            for c in chars:
                if len(res) > 0 and res[len(res) - 1] == c:
                    continue
                if k <= count:
                    res = res + c
                    break
                k -= count
        return res
        
# @lc code=end

