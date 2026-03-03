#
# @lc app=leetcode.cn id=1545 lang=python3
#
# [1545] 找出第 N 个二进制字符串中的第 K 位
#

# @lc code=start
class Solution:
    def findKthBit(self, n: int, k: int) -> str:
        if k % 2 > 0:
            # 奇数
            return str(k // 2 % 2)
        else:
            # 偶数
            k //= k & -k; # 去掉 k 的尾零
            return str(1 - k // 2 % 2)
        
# @lc code=end

