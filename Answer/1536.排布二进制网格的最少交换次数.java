/*
 * @lc app=leetcode.cn id=1536 lang=java
 *
 * [1536] 排布二进制网格的最少交换次数
 */

// @lc code=start
class Solution {

    public int minSwaps(int[][] grid) {
        var n = grid.length;
        var aim = new int[n];
        for (int i = 0; i < n; i++) {
            var count = n - 1;
            for (int j = n - 1; j >= 0; j--) {
                count = j;
                if (grid[i][j] == 1) {
                    break;
                }
            }
            aim[i] = count;
        }
        var ans = 0;
        for (int i = 0; i < n; i++) {
            var j = i;
            while (j < n && aim[j] > i) {
                j++;
            }
            if (j == n) {
                return -1;
            }
            ans += j - i;
            for (int k = j; k > i; k--) {
                aim[k] = aim[k - 1];
            }
        }
        return ans;
    }
}
// @lc code=end

