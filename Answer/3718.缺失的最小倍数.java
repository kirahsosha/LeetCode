/*
 * @lc app=leetcode.cn id=3718 lang=java
 *
 * [3718] 缺失的最小倍数
 */

// @lc code=start
class Solution {

    public int missingMultiple(int[] nums, int k) {
        java.util.HashSet<Integer> set = new java.util.HashSet<>();
        for (int v : nums) {
            set.add(v);
        }
        int multiple = k;
        while (set.contains(multiple)) {
            multiple += k;
        }
        return multiple;
    }
}
// @lc code=end
