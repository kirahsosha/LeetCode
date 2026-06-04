#
# @lc app=leetcode.cn id=3751 lang=python3
#
# [3751] 范围内总波动值 I
#

# @lc code=start
_MAX_N = 100000
_waviness = [0] * (_MAX_N + 1)
for x in range(100, _MAX_N + 1):
    s = str(x)
    cnt = 0
    for j in range(1, len(s) - 1):
        if (s[j] > s[j - 1] and s[j] > s[j + 1]) or \
           (s[j] < s[j - 1] and s[j] < s[j + 1]):
            cnt += 1
    _waviness[x] = cnt

_prefix = [0] * (_MAX_N + 1)
for i in range(1, _MAX_N + 1):
    _prefix[i] = _prefix[i - 1] + _waviness[i]


class Solution:
    def totalWaviness(self, num1: int, num2: int) -> int:
        if num1 <= 0:
            return _prefix[num2]
        return _prefix[num2] - _prefix[num1 - 1]
# @lc code=end
