/*
 * @lc app=leetcode.cn id=930 lang=csharp
 *
 * [930] 和相同的二元子数组
 */

// @lc code=start
public class Solution {
    public int NumSubarraysWithSum(int[] nums, int goal) {
        if (nums.Sum() < goal) return 0;
            List<int> list = new List<int>();
            list.Add(-1);
            //找到所有1的位置
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == 1)
                {
                    list.Add(i);
                }
            }
            list.Add(nums.Length);
            int ans = 0;
            if(goal == 0)
            {
                //次数为任意两个1之间0的个数的1~n累加
                for (int i = 0; i < list.Count - 1; i++)
                {
                    int n = list[i + 1] - list[i];
                    int sum = (n * (n - 1)) / 2;
                    ans += sum;
                }
                return ans;
            }
            //任意间隔goal-1的两个1之间的1的和为goal，次数为两侧的下标差的乘积
            for (int i = 1; i < list.Count - goal; i++)
            {
                int j = i + goal - 1;
                int left = list[i] - list[i - 1];
                int right = list[j + 1] - list[j];
                ans += left * right;
            }
            return ans;
    }
}
// @lc code=end

