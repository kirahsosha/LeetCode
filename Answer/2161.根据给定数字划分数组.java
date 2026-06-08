/*
 * @lc app=leetcode.cn id=2161 lang=java
 *
 * [2161] 根据给定数字划分数组
 */

// @lc code=start
class Solution {

    public int[] pivotArray(int[] nums, int pivot) {
        var n = nums.length;
        var ans = new int[n];
        int left = 0, right = n - 1;
        for (var num : nums) {
            if (num < pivot) {
                ans[left++] = num;
            } else if (num > pivot) {
                ans[right--] = num;
            }
        }
        for (var i = left; i <= right; i++) {
            ans[i] = pivot;
        }
        for (int i = right + 1, j = n - 1; i < j; i++, j--) {
            var tmp = ans[i];
            ans[i] = ans[j];
            ans[j] = tmp;
        }
        return ans;
    }
}
// @lc code=end
