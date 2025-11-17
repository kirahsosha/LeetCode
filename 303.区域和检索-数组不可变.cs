/*
 * @lc app=leetcode.cn id=303 lang=csharp
 *
 * [303] 区域和检索 - 数组不可变
 */

// @lc code=start
public class NumArray {
    //预处理 计算sum[nums.Length + 1]
    //状态转移方程 sum[i, j] = sum[j + 1] - sum[i]
    public int[] sum;

    public NumArray(int[] nums) {
        sum = new int[nums.Length + 1];
        sum[0] = 0;
        for(int k = 0; k < nums.Length; k++)
        {
            sum[k + 1] = sum[k] + nums[k];
        }
    }
    
    public int SumRange(int i, int j) {
        return sum[j + 1] - sum[i];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */
// @lc code=end

