/*
 * @lc app=leetcode.cn id=3577 lang=java
 *
 * [3577] 统计计算机解锁顺序排列数
 */

// @lc code=start
class Solution {

    public int countPermutations(int[] complexity) {
        int MOD = 1000000007;
        //complexity[0]必须是唯一最小值
        long res = 1;
        for (int i = 1; i < complexity.length; i++) {
            if (complexity[i] <= complexity[0]) {
                return 0;
            }
            res = res * i % MOD;
        }
        return (int) res;
    }
}
// @lc code=end

