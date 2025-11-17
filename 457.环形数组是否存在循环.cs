/*
 * @lc app=leetcode.cn id=457 lang=csharp
 *
 * [457] 环形数组是否存在循环
 */

// @lc code=start
public class Solution {
    public bool CircularArrayLoop(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return false;
            Dictionary<int, bool> tested = new Dictionary<int, bool>();
            int index = 0;

            while (index < len)
            {
                if(!tested.ContainsKey(index))
                {
                    bool res = TestLoop(index, nums, tested);
                    if (res) return true;
                }
                index++;
            }
            return false;
        }

        public bool TestLoop(int index, int[] nums, Dictionary<int, bool> tested)
        {
            if(tested.ContainsKey(index) && tested[index])
            {
                //之前检查过的点，说明从这点开始不构成循环，返回false
                return false;
            }
            else if(tested.ContainsKey(index))
            {
                //这一次的点，说明构成了循环，返回true
                return true;
            }
            int next = (index + nums[index] + nums.Length * (Math.Abs(nums[index]) / nums.Length + 1)) % nums.Length;
            if(next == index)
            {
                //循环长度为1，返回false
                tested[index] = true;
                return false;
            }
            if(nums[next] / Math.Abs(nums[next]) != nums[index] / Math.Abs(nums[index]))
            {
                //方向不同，返回false
                tested[index] = true;
                return false;
            }
            tested.Add(index, false);
            bool res = TestLoop(next, nums, tested);
            tested[index] = !res;

            return res;
        }
}
// @lc code=end

