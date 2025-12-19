/*
 * @lc app=leetcode.cn id=944 lang=java
 *
 * [944] 删列造序
 */

// @lc code=start
class Solution {
    public int minDeletionSize(String[] strs) {
        var n = strs[0].length();
        var res = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < strs.length; j++)
            {
                if (strs[j].charAt(i) < strs[j - 1].charAt(i))
                {
                    res++;
                    break;
                }
            }
        }
        return res;
    }
}
// @lc code=end

