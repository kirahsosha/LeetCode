/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        //一次遍历，用hashmap检索当前值需要的目标值
        Hashtable map = new Hashtable();
        for(int i = 0; i < nums.Length; i++)
        {
            int j = target - nums[i];//计算目标值
            if(map.ContainsKey(j))
            {
                //找到目标值后返回两个下标
                return new int[] {Convert.ToInt32(map[j]),i};
            }
            if(!map.ContainsKey(nums[i]))
            {
                //将当前值和数组下标存入hashmap
                map.Add(nums[i],i);
            }
        }
        return null;
    }
}
// @lc code=end

