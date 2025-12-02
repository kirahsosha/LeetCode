
import java.util.HashMap;

/*
 * @lc app=leetcode.cn id=3623 lang=java
 *
 * [3623] 统计梯形的数目 I
 */

// @lc code=start
class Solution {
    int MOD = 1000000007;
    public int countTrapezoids(int[][] points) {
        //key：纵坐标；value：线段数量
        HashMap<Integer, Long> dic = new HashMap<>();
        for (int[] point : points) {
            int y = point[1];
            if (dic.containsKey(y))
            {
                dic.put(y, dic.get(y) + 1);
            }
            else
            {
                dic.put(y, (long)1);
            }
        }
        long res = 0;
        long side = 0;
        for (long point : dic.values()) {
            long edge = point * (point - 1) / 2;
            res = (res + edge * side) % MOD;
            side = (side + edge) % MOD;
        }
        return (int)res;
    }
}
// @lc code=end

