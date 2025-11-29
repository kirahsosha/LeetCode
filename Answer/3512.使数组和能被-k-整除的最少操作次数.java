/*
 * @lc app=leetcode.cn id=3512 lang=java
 *
 * [3512] 使数组和能被 K 整除的最少操作次数
 */

// @lc code=start
class Solution {

    public int minOperations(int[] nums, int k) {
        var res = 0;
        for (int n : nums) {
            res = (res + n) % k;
        }
        return res;
    }
}
// @lc code=end

