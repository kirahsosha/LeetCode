/*
 * @lc app=leetcode.cn id=3315 lang=java
 *
 * [3315] 构造最小位运算数组 II
 */

// @lc code=start
import java.util.List;

class Solution {

    public int[] minBitwiseArray(List<Integer> nums) {
        var n = nums.size();
        var ans = new int[n];
        for (int i = 0; i < n; i++) {
            var value = nums.get(i);
            if (value == 2) {
                ans[i] = -1;
            } else {
                int t = ~value;
                int lowbit = t & -t;
                ans[i] = value ^ (lowbit >> 1);
            }
        }
        return ans;
    }
}
// @lc code=end

