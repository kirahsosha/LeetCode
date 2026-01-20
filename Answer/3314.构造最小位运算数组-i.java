/*
 * @lc app=leetcode.cn id=3314 lang=java
 *
 * [3314] 构造最小位运算数组 I
 */

// @lc code=start
import java.util.List;

class Solution {

    public int[] minBitwiseArray(List<Integer> nums) {
        var n = nums.size();
        var ans = new int[n];
        for (int i = 0; i < n; i++) {
            var num = nums.get(i);
            var min = num / 2;
            ans[i] = -1;
            for (int j = min; j < num; j++) {
                if ((j | (j + 1)) == num) {
                    ans[i] = j;
                    break;
                }
            }
        }
        return ans;
    }
}
// @lc code=end

