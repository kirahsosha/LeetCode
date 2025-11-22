/*
 * @lc app=leetcode.cn id=3190 lang=java
 *
 * [3190] 使所有元素都可以被 3 整除的最少操作数
 */

// @lc code=start
class Solution {

    public int minimumOperations(int[] nums) {
        int res = 0;
        for (int n : nums) {
            if (n % 3 != 0) {
                res++;
            }
        }
        return res;
    }
}
// @lc code=end

