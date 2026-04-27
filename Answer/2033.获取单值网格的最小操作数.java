/*
 * @lc app=leetcode.cn id=2033 lang=java
 *
 * [2033] 获取单值网格的最小操作数
 */

// @lc code=start
import java.util.Arrays;

class Solution {
    public int minOperations(int[][] grid, int x) {
        int m = grid.length;
        int n = grid[0].length;
        int[] nums = new int[m * n];
        int base = grid[0][0];
        int idx = 0;
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int num = grid[i][j];
                if ((num - base) % x != 0) {
                    return -1;
                }
                nums[idx++] = num;
            }
        }
        
        Arrays.sort(nums);
        int median = nums[nums.length / 2];
        int ans = 0;
        
        for (int num : nums) {
            ans += Math.abs(num - median) / x;
        }
        
        return ans;
    }
}
// @lc code=end
