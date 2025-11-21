#
# @lc app=leetcode.cn id=1930 lang=python3
#
# [1930] 长度为 3 的不同回文子序列
#

# @lc code=start
class Solution:
    def countPalindromicSubsequence(self, s: str) -> int:
        dic = {}
        res = set()
        for i in range(len(s)):
            c = s[i]
            if c in dic:
                dic[c].append(i)
            else:
                dic[c] = [i]
        for v in dic.values():
            if len(v) >= 2:
                l = v[0]
                r = v[-1]
                for j in range(l+1, r):
                    res.add(s[l] + s[j] + s[r])
        return len(res)
        
# @lc code=end

