/*
 * @lc app=leetcode.cn id=2751 lang=csharp
 *
 * [2751] 机器人碰撞
 */

// @lc code=start
public class Solution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        var n = positions.Length;
        var order = new int[n];
        for (var i = 0; i < n; i++)
        {
            order[i] = i;
        }

        Array.Sort(order, (a, b) => positions[a].CompareTo(positions[b]));

        var rightStack = new Stack<int>();
        foreach (var i in order)
        {
            if (directions[i] == 'R')
            {
                rightStack.Push(i);
                continue;
            }

            while (rightStack.Count > 0 && healths[i] > 0)
            {
                var j = rightStack.Peek();
                if (healths[j] < healths[i])
                {
                    rightStack.Pop();
                    healths[i]--;
                    healths[j] = 0;
                }
                else if (healths[j] > healths[i])
                {
                    healths[j]--;
                    healths[i] = 0;
                }
                else
                {
                    rightStack.Pop();
                    healths[j] = 0;
                    healths[i] = 0;
                }
            }
        }

        var ans = new List<int>();
        for (var i = 0; i < n; i++)
        {
            if (healths[i] > 0)
            {
                ans.Add(healths[i]);
            }
        }

        return ans;
    }
}
// @lc code=end