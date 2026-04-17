/*
 * @lc app=leetcode.cn id=3783 lang=csharp
 *
 * [3783] 整数的镜像距离
 */

// @lc code=start
public class Solution {
    public int MirrorDistance(int n) {
        int rev = 0;
        for (int x = n; x > 0; x /= 10) {
            rev = rev * 10 + x % 10;
        }
        return Math.Abs(rev - n);
    }
}
// @lc code=end
