/*
 * @lc app=leetcode.cn id=1018 lang=java
 *
 * [1018] 可被 5 整除的二进制前缀
 */

// @lc code=start

import java.util.ArrayList;
import java.util.List;

class Solution {
    public List<Boolean> prefixesDivBy5(int[] nums) {
        int num = 0;
        ArrayList<Boolean> res = new ArrayList<>();
        for (int i : nums) {
            num = num * 2 + i;
            if (num % 5 == 0)
            {
                res.add(true);
            }
            else
            {
                res.add(false);
            }
            num = num % 10;
        }
        return res;
    }
}
// @lc code=end

