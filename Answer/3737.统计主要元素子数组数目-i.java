
import java.util.ArrayList;

/*
 * @lc app=leetcode.cn id=3737 lang=java
 *
 * [3737] 统计主要元素子数组数目 I
 */
// @lc code=start
class Solution {

    public int countMajoritySubarrays(int[] nums, int target) {
        int n = nums.length;
        int[] cnt = new int[n * 2 + 1];
        cnt[n] = 1;
        long ans = 0;
        int s = n;
        int f = 0;
        for (int x : nums) {
            if (x == target) {
                f += cnt[s];
                s++;
            } else {
                s--;
                f -= cnt[s];
            }
            ans += f;
            cnt[s]++;
        }
        return (int) ans;
    }
}
// @lc code=end

