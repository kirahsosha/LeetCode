/*
 * @lc app=leetcode.cn id=1390 lang=java
 *
 * [1390] 四因数
 */

// @lc code=start
import java.util.HashSet;

class Solution {

    public int sumFourDivisors(int[] nums) {
        var res = 0;
        for (var n : nums) {
            var di = AllDivisors(n);
            if (di.size() == 4) {
                for (var i : di) {
                    res += i;
                }
            }
        }
        return res;
    }

    HashSet<Integer> AllDivisors(int n) {
        HashSet<Integer> res = new HashSet<>();
        for (int i = 1; i <= Math.sqrt(n); i++) {
            if (n % i == 0) {
                res.add(i);
                res.add(n / i);
            }
        }
        return res;
    }
}
// @lc code=end

