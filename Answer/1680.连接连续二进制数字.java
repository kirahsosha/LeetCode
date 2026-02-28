
import jdk.jfr.Unsigned;

/*
 * @lc app=leetcode.cn id=1680 lang=java
 *
 * [1680] 连接连续二进制数字
 */
// @lc code=start
class Solution {

    public int concatenatedBinary(int n) {
        var MOD = 1000000007;
        var res = 0;
        for (var i = 1; i <= n; i++) {
            var t = i;
            while (t > 0) {
                t >>= 1;
                res = (res << 1) % MOD;
            }
            res = (res + i) % MOD;
        }
        return res;
    }
}
// @lc code=end

