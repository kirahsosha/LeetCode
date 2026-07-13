/*
 * @lc app=leetcode.cn id=1291 lang=csharp
 *
 * [1291] 顺次数
 */

// @lc code=start
public class Solution
{
    public IList<int> SequentialDigits(int low, int high)
    {
        var res = new List<int>();
        int delta = 1;
        int offset = 0;
        for (int len = 2; len <= 9; len++)
        {
            delta = delta * 10 + 1;
            offset = offset * 10 + (len - 1);
            int minNum = delta + offset;
            if (minNum > high)
            {
                break;
            }
            int maxNum = (10 - len) * delta + offset;
            if (maxNum < low)
            {
                continue;
            }
            for (int start = 1; start <= 10 - len; start++)
            {
                int num = start * delta + offset;
                if (num < low)
                {
                    continue;
                }
                if (num > high)
                {
                    break;
                }
                res.Add(num);
            }
        }
        return res;
    }
}
// @lc code=end
