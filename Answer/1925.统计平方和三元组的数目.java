/*
 * @lc app=leetcode.cn id=1925 lang=java
 *
 * [1925] 统计平方和三元组的数目
 */

// @lc code=start
class Solution {

    public int countTriples(int n) {
        //a^2 + b^2 = c^2
        //1 <= a, b, c <= n
        //a, b <= sqrt(n^2 / 2)
        var maxa = Math.floor(Math.sqrt(n * n / 2));
        var res = 0;
        for (int a = 3; a <= maxa; a++) {
            var maxb = Math.floor(Math.sqrt(n * n - a * a));
            for (int b = a + 1; b <= maxb; b++) {
                var sum = Math.sqrt(a * a + b * b);
                if (sum == Math.floor(sum)) {
                    res += 2;
                }
            }
        }
        return res;
    }
}
// @lc code=end

