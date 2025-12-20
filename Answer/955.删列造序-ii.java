/*
 * @lc app=leetcode.cn id=955 lang=java
 *
 * [955] 删列造序 II
 */

// @lc code=start
class Solution {
    public int minDeletionSize(String[] strs) {
        int n = strs.length;
        int m = strs[0].length();
        var cuts = new boolean[n - 1];

        int ans = 0;
        for (int j = 0; j < m; j++) {
            var check = true;
            for (int i = 0; i < n - 1; i++) {
                if (!cuts[i] && strs[i].charAt(j) > strs[i + 1].charAt(j)) {
                    ans++;
                    check = false;
                    break;
                }
            }
            if (check) {
                for (int i = 0; i < n - 1; i++) {
                    if (strs[i].charAt(j) < strs[i + 1].charAt(j)) {
                        cuts[i] = true;
                    }
                }
            }
        }

        return ans;
    }
}
// @lc code=end
