/*
 * @lc app=leetcode.cn id=1877 lang=java
 *
 * [1877] 数组中最大数对和的最小值
 */

// @lc code=start
import java.util.Arrays;

class Solution {

    public int minPairSum(int[] nums) {
        Arrays.sort(nums);
        var ans = 0;
        for (int i = 0; i < nums.length / 2; i++) {
            ans = Math.max(ans, nums[i] + nums[nums.length - i - 1]);
        }
        return ans;
    }
}
// @lc code=end

