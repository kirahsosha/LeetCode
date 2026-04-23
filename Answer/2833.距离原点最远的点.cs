/*
 * @lc app=leetcode.cn id=2833 lang=csharp
 *
 * [2833] 距离原点最远的点
 */

// @lc code=start
public class Solution
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        // int left = 0, right = 0;
        // foreach (char c in moves)
        // {
        //     if (c == 'L')
        //     {
        //         left++;
        //         right--;
        //     }
        //     else if (c == 'R')
        //     {
        //         right++;
        //         left--;
        //     }
        //     else
        //     {
        //         left++;
        //         right++;
        //     }
        // }
        // return Math.Max(left, right);
        return Math.Abs(moves.Count(c => c == 'L') - moves.Count(c => c == 'R')) + moves.Count(c => c == '_');
    }
}
// @lc code=end

