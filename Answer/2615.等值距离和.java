import java.util.HashMap;
import java.util.Map;

/*
 * @lc app=leetcode.cn id=2615 lang=java
 *
 * [2615] 等值距离和
 */

// @lc code=start
class Solution {
    public long[] distance(int[] nums) {
        int n = nums.length;
        long[] ans = new long[n];

        // 从左向右：计算每个位置左侧同值元素的距离和
        Map<Integer, Integer> cnt = new HashMap<>(n);
        Map<Integer, Long> sum = new HashMap<>(n);
        for (int i = 0; i < n; i++) {
            int c = cnt.getOrDefault(nums[i], 0);
            long s = sum.getOrDefault(nums[i], 0L);
            long idx = i;
            ans[i] = idx * c - s;
            cnt.put(nums[i], c + 1);
            sum.put(nums[i], s + idx);
        }

        // 从右向左：计算每个位置右侧同值元素的距离和并累加
        cnt = new HashMap<>(n);
        sum = new HashMap<>(n);
        for (int i = n - 1; i >= 0; i--) {
            int c = cnt.getOrDefault(nums[i], 0);
            long s = sum.getOrDefault(nums[i], 0L);
            long idx = i;
            ans[i] += s - idx * c;
            cnt.put(nums[i], c + 1);
            sum.put(nums[i], s + idx);
        }

        return ans;
    }
}
// @lc code=end
