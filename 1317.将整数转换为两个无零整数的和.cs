/*
 * @lc app=leetcode.cn id=1317 lang=csharp
 *
 * [1317] 将整数转换为两个无零整数的和
 */

// @lc code=start
public class Solution
{
    public int[] GetNoZeroIntegers(int n)
    {
        for (int i = 1; i < n; i++)
        {
            if (CheckZero(i) && CheckZero(n - i))
            {
                return new int[] { i, n - i };
            }
        }
        return new int[] { 1, n - 1 };
    }

    private bool CheckZero(int i)
    {
        int t = i % 10; //取余
        while (t != 0)
        {
            if (i > 0 && i < 10) return true;
            i = i / 10;
            t = i % 10;
        }
        return false;
    }
}
// @lc code=end

