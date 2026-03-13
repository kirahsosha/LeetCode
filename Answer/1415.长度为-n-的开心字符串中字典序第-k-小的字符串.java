/*
 * @lc app=leetcode.cn id=1415 lang=java
 *
 * [1415] 长度为 n 的开心字符串中字典序第 k 小的字符串
 */

// @lc code=start
class Solution {

    public String getHappyString(int n, int k) {
        var chars = new char[]{'a', 'b', 'c'};
        var res = new StringBuilder();
        if (k > 3 * (1 << (n - 1))) {
            return res.toString();
        }
        for (var i = 0; i < n; i++) {
            var count = 1 << (n - i - 1);
            for (var c : chars) {
                if (res.length() > 0 && res.charAt(res.length() - 1) == c) {
                    continue;
                }
                if (k <= count) {
                    res.append(c);
                    break;
                }
                k -= count;
            }
        }
        return res.toString();
    }
}
// @lc code=end

