/*
 * @lc app=leetcode.cn id=2211 lang=csharp
 *
 * [2211] 统计道路上的碰撞次数
 */

// @lc code=start
public class Solution
{
    public int CountCollisions(string directions)
    {
        //L：state < 0，忽略；state >= 0，更新res += state + 1，state = 0
        //S：state < 0，更新state = 0；state >= 0，更新res += state，state = 0
        //R：state <= 0，更新state = 1；state > 0，更新state += 1
        var state = -1;
        var res = 0;
        foreach (char c in directions)
        {
            switch (c)
            {
                case 'L':
                    if (state >= 0)
                    {
                        res += state + 1;
                        state = 0;
                    }
                    break;
                case 'S':
                    if (state < 0)
                    {
                        state = 0;
                    }
                    else
                    {
                        res += state;
                        state = 0;
                    }
                    break;
                case 'R':
                    if (state <= 0)
                    {
                        state = 1;
                    }
                    else
                    {
                        state += 1;
                    }
                    break;
                default:
                    continue;
            }
        }
        return res;
    }
}
// @lc code=end

