
import java.util.ArrayList;
import java.util.List;

/*
 * @lc app=leetcode.cn id=2147 lang=java
 *
 * [2147] 分隔长廊的方案数
 */

// @lc code=start
class Solution {
    public int numberOfWays(String corridor) {
        int MOD = 1000000007;
        List<Integer> list = new ArrayList<>();
        for (int i = 0; i < corridor.length(); i++)
        {
            if (corridor.charAt(i) == 'S')
            {
                list.add(i);
            }
        }
        if (list.isEmpty() || list.size() % 2 == 1)
        {
            return 0;
        }
        int index = 0;
        long res = 1;
        for (int i = 1; i < list.size() - 1; i++)
        {
            if (index == 0)
            {
                index = list.get(i);
            }
            else
            {
                res = res * (list.get(i) - index) % MOD;
                index = 0;
            }
        }
        return (int)res;
    }
}
// @lc code=end

