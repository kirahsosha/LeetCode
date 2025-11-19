/*
 * @lc app=leetcode.cn id=2154 lang=java
 *
 * [2154] 将找到的值乘以 2
 */

// @lc code=start

import java.util.HashSet;

class Solution {
    public int findFinalValue(int[] nums, int original) {
        HashSet<Integer> set = new HashSet<>();
        for (int integer : nums) {
            set.add(integer);
        }
        while (set.contains(original))
        {
            original *= 2;
        }
        return original;
    }
}
// @lc code=end

