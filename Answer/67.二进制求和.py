#
# @lc app=leetcode.cn id=67 lang=python3
#
# [67] 二进制求和
#

# @lc code=start
class Solution:
    def addBinary(self, a: str, b: str) -> str:
        def ctoI(self, c: str) -> int:
            if c == '1':
                return 1
            return 0

        def itoC(self, i: int) -> str:
            if i == 1:
                return '1'
            return '0'

        s = ""
        if len(b) > len(a):
            s = a
            a = b
            b = s
        c = [''] * len(a)
        length = len(a) - len(b)
        t = 0
        for i in range(len(b) - 1, -1, -1):
            aa = ctoI(self, a[i + length]) + ctoI(self, b[i]) + t
            if aa > 1:
                t = 1
                aa -= 2
            else:
                t = 0
            c[i + length] = itoC(self, aa)
        for i in range(length - 1, -1, -1):
            aa = ctoI(self, a[i]) + t
            if aa > 1:
                t = 1
                aa -= 2
            else:
                t = 0
            c[i] = itoC(self, aa)
        s = ''.join(c)
        if t == 1:
            s = "1" + s
        return s
# @lc code=end

