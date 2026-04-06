/*
 * @lc app=leetcode.cn id=874 lang=java
 *
 * [874] 模拟行走机器人
 */
import java.util.*;

// @lc code=start
class Solution {

    public int robotSim(int[] commands, int[][] obstacles) {
        Set<Long> obs = new HashSet<>();
        if (obstacles != null) {
            for (int[] ob : obstacles) {
                long key = (((long) ob[0]) << 32) ^ (ob[1] & 0xffffffffL);
                obs.add(key);
            }
        }
        int x = 0, y = 0, dir = 0, ans = 0;
        int[] dx = {0, 1, 0, -1};
        int[] dy = {1, 0, -1, 0};
        for (int cmd : commands) {
            if (cmd == -2) {
                dir = (dir + 3) % 4; 
            }else if (cmd == -1) {
                dir = (dir + 1) % 4; 
            }else {
                for (int step = 0; step < cmd; step++) {
                    int nx = x + dx[dir], ny = y + dy[dir];
                    long key = (((long) nx) << 32) ^ (ny & 0xffffffffL);
                    if (!obs.contains(key)) {
                        x = nx;
                        y = ny;
                        ans = Math.max(ans, x * x + y * y);
                    }
                }
            }
        }
        return ans;
    }
}
// @lc code=end

