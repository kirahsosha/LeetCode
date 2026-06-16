#
# @lc app=leetcode.cn id=3612 lang=python3
#
# [3612] 用特殊操作处理字符串 I
#

# @lc code=start
class Solution:
    def processStr(self, s: str) -> str:
        ans = []
        for ch in s:
            if ch == '*':
                if ans:
                    ans.pop()
            elif ch == '#':
                ans.extend(ans)
            elif ch == '%':
                ans.reverse()
            else:
                ans.append(ch)
        return ''.join(ans)
# @lc code=end
