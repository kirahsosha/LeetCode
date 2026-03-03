/*
 * @lc app=leetcode.cn id=1545 lang=typescript
 *
 * [1545] 找出第 N 个二进制字符串中的第 K 位
 */

// @lc code=start
function findKthBit(n: number, k: number): string {
    if (k % 2) {
        //奇数
        return (k - 1) / 2 % 2 ? '1' : '0';
    } else {
        //偶数
        k /= k & -k; // 去掉 k 的尾零
        return (k - 1) / 2 % 2 ? '0' : '1';
    }
};
// @lc code=end

