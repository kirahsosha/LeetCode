/*
 * @lc app=leetcode.cn id=2141 lang=java
 *
 * [2141] 同时运行 N 台电脑的最长时间
 */

// @lc code=start
class Solution {
    public long maxRunTime(int n, int[] batteries) {
        //可运行时间不超过平均时间
        long total = 0;
        for (int num : batteries) {
            total += num;
        }
        long l = 0;
        long r = total / n + 1;
        while (l + 1 < r)
        {
            //二分，假设能运行t分钟，b >= t的电池只能给一台电脑使用，b < t的电池可以组合使用
            long t = l + (r - l) / 2;
            long sum = 0;
            for (int b : batteries)
            {
                sum += Math.min(b, t);
            }
            if (n * t <= sum)
            {
                //可以运行t分钟，下一轮查找范围[t,r)
                l = t;
            }
            else
            {
                //无法运行t分钟，下一轮查找范围[l,t)
                r = t;
            }
        }
        return l;
    }
}
// @lc code=end

