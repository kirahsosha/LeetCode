/*
 * @lc app=leetcode.cn id=2784 lang=java
 *
 * [2784] 检查数组是否是好的
 */

// @lc code=start
class Solution {
    public boolean isGood(int[] nums) {
        int n = nums.length - 1;
        if (n == 0) {
            return false;
        }

        int[] cnt = new int[n];
        for (int num : nums) {
            if (num > n || num <= 0) {
                return false;
            }
            if (num != n && cnt[num - 1] == 1) {
                return false;
            }
            if (num == n && cnt[num - 1] > 1) {
                return false;
            }
            cnt[num - 1]++;
        }
        return true;
    }
}
// @lc code=end
