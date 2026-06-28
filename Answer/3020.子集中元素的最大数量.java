
import java.util.ArrayList;
import java.util.HashMap;

/*
 * @lc app=leetcode.cn id=3020 lang=java
 *
 * [3020] 子集中元素的最大数量
 */
// @lc code=start
class Solution {

    public int maximumLength(int[] nums) {
        HashMap<Long, Integer> cnt = new HashMap<>();
        for (int x : nums) {
            cnt.merge((long) x, 1, Integer::sum); // cnt[x]++
        }

        Integer cnt1 = cnt.remove(1L);
        int ans = cnt1 != null ? (cnt1 - 1) | 1 : 0; // 保证 ans 是奇数（奇数不变，偶数减一）

        for (long x : cnt.keySet()) {
            int res = 0;
            while (cnt.getOrDefault(x, 0) >= 2) {
                res += 2;
                x *= x;
            }
            ans = Math.max(ans, res + (cnt.containsKey(x) ? 1 : -1));
        }

        return ans;
    }
}
// @lc code=end
