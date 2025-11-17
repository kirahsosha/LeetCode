/*
 * @lc app=leetcode.cn id=611 lang=csharp
 *
 * [611] 有效三角形的个数
 */

// @lc code=start
public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        if (nums.Length < 3) return 0;
        Dictionary<int, int> dic = new Dictionary<int, int>();
        Dictionary<int, int> sum = new Dictionary<int, int>();
        int ans = 0;
        //对每一个数
        //先找现有的和里面能组成三角形的个数
        //再将自身和现有数的和添加到sum
        //再将自身添加到dic
        foreach (var i in nums.OrderBy(p => p))
        {
            ans += sum.Where(p => p.Key > i).Sum(p => p.Value);

            foreach (var p in dic)
            {
                if (sum.ContainsKey(i + p.Key))
                {
                    sum[i + p.Key] += p.Value;
                }
                else
                {
                    sum.Add(i + p.Key, p.Value);
                }
            }

            if (dic.ContainsKey(i))
            {
                dic[i]++;
            }
            else
            {
                dic.Add(i, 1);
            }
        }

        return ans;
    }
}
// @lc code=end

