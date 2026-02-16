/*
 * @lc app=leetcode.cn id=401 lang=csharp
 *
 * [401] 二进制手表
 */

// @lc code=start
public class Solution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        List<int> ConbineNumber(int number, int digit, int last)
        {
            if (last == 0)
            {
                return new List<int> { number };
            }
            else if (digit == last)
            {
                return ConbineNumber((number << 1) + 1, digit - 1, last - 1);
            }
            else if (digit == 0)
            {
                return ConbineNumber(number << 1, digit, last - 1);
            }
            else
            {
                var nums = new List<int>();
                nums.AddRange(ConbineNumber((number << 1) + 1, digit - 1, last - 1));
                nums.AddRange(ConbineNumber(number << 1, digit, last - 1));
                return nums;
            }
        }

        var nums = ConbineNumber(0, turnedOn, 10);
        var res = new List<string>();
        foreach (var num in nums)
        {
            var minute = num >> 4;
            var hour = num & 0x0000000f;
            if (hour >= 12 || minute >= 60) continue;
            res.Add(hour.ToString("D1") + ":" + minute.ToString("D2"));
        }
        return res;
    }
}
// @lc code=end

