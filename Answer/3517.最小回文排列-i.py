#
# @lc app=leetcode.cn id=3517 lang=python3
#
# [3517] 最小回文排列 I
#

# @lc code=start
class Solution:
    def smallestPalindrome(self, s: str) -> str:
        n = len(s)
        cnt = [0] * 26
        for ch in s[:n // 2]:
            cnt[ord(ch) - ord('a')] += 1
        ans = [''] * n
        left, right = 0, n - 1
        for i in range(26):
            c = chr(ord('a') + i)
            while cnt[i] > 0:
                ans[left] = c
                ans[right] = c
                left += 1
                right -= 1
                cnt[i] -= 1
        if n % 2 == 1:
            ans[left] = s[n // 2]
        return ''.join(ans)
# @lc code=end
