
import java.util.HashSet;

/*
 * @lc app=leetcode.cn id=1015 lang=java
 *
 * [1015] 可被 K 整除的最小整数
 */

// @lc code=start
class Solution {
    public int smallestRepunitDivByK(int k) {
        HashSet<Integer> set = new HashSet<>();
        var n = 0;
        for (int i = 1; i <= k; i++)
        {
            n = (n * 10 + 1) % k;
            if (n == 0)
            {
                return i;
            }
            else if (set.contains(n))
            {
                return -1;
            }
            else
            {
                set.add(n);
            }
        }
        return -1;
    }
}
// @lc code=end

