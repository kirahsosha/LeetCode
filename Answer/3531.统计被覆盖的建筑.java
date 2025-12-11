/*
 * @lc app=leetcode.cn id=3531 lang=java
 *
 * [3531] 统计被覆盖的建筑
 */

// @lc code=start
import java.util.HashMap;

class Solution {

    public int countCoveredBuildings(int n, int[][] buildings) {
        //Key：横坐标；Value：纵坐标范围
        HashMap<Integer, Integer[]> ver = new HashMap<>();
        //Key：纵坐标；Value：横坐标范围
        HashMap<Integer, Integer[]> hor = new HashMap<>();
        for (var building : buildings) {
            var x = building[0];
            var y = building[1];
            if (ver.containsKey(x)) {
                ver.get(x)[0] = Math.min(ver.get(x)[0], y);
                ver.get(x)[1] = Math.max(ver.get(x)[1], y);
            } else {
                ver.put(x, new Integer[]{y, y});
            }
            if (hor.containsKey(y)) {
                hor.get(y)[0] = Math.min(hor.get(y)[0], x);
                hor.get(y)[1] = Math.max(hor.get(y)[1], x);
            } else {
                hor.put(y, new Integer[]{x, x});
            }
        }
        int res = 0;
        for (var building : buildings) {
            var x = building[0];
            var y = building[1];
            if (ver.get(x)[0] < y && ver.get(x)[1] > y && hor.get(y)[0] < x && hor.get(y)[1] > x) {
                res++;
            }
        }
        return res;
    }
}
// @lc code=end

