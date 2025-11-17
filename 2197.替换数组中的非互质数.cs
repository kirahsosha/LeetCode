/*
 * @lc app=leetcode.cn id=2197 lang=csharp
 *
 * [2197] 替换数组中的非互质数
 */

// @lc code=start
public class Solution
{
    public IList<int> ReplaceNonCoprimes(int[] nums)
        {
            if (nums.Length <= 1) return nums.ToList();

            var res = new List<int>();
            var left = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                while (res.Count > 0)
                {
                    int last = res[res.Count - 1];
                    int gcd = GCD(last, num);
                    if (gcd > 1)
                    {
                        num = last / gcd * num;
                        res.RemoveAt(res.Count - 1);
                    }
                    else
                    {
                        break;
                    }
                }
                res.Add(num);
            }
            return res;
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
}
// @lc code=end

