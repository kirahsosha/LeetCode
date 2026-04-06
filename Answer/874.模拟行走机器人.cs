/*
 * @lc app=leetcode.cn id=874 lang=csharp
 *
 * [874] 模拟行走机器人
 */
using System;
using System.Collections.Generic;

// @lc code=start
public class Solution
{
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        var obs = new HashSet<long>();
        if (obstacles != null)
        {
            foreach (var ob in obstacles)
            {
                long key = ((long)ob[0] << 32) ^ (long)(uint)ob[1];
                obs.Add(key);
            }
        }
        int x = 0, y = 0, dir = 0, ans = 0;
        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };
        foreach (var cmd in commands)
        {
            if (cmd == -2) dir = (dir + 3) % 4;
            else if (cmd == -1) dir = (dir + 1) % 4;
            else
            {
                for (int step = 0; step < cmd; step++)
                {
                    int nx = x + dx[dir], ny = y + dy[dir];
                    long key = ((long)nx << 32) ^ (long)(uint)ny;
                    if (!obs.Contains(key))
                    {
                        x = nx; y = ny;
                        ans = Math.Max(ans, x * x + y * y);
                    }
                }
            }
        }
        return ans;
    }
}
// @lc code=end

