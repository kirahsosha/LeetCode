/*
 * @lc app=leetcode.cn id=202 lang=csharp
 *
 * [202] 快乐数
 */

// @lc code=start
public class Solution {
    int getSum(int n)
    {
        int sum = 0;
        while(n != 0)
        {
            sum += (n % 10) * (n % 10);
            n /= 10;
        }
        return sum;
    }

    public bool IsHappy(int n) {
        if(n == 1) return true;
        IList list = new List<int>{};
        list.Add(n);
        while(n != 1)
        {
            n = getSum(n);
            if(list.Contains(n))
            {
                return false;
            }
            list.Add(n);
        }
        return true;
    }
}
// @lc code=end

