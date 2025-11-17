/*
 * @lc app=leetcode.cn id=189 lang=csharp
 *
 * [189] 旋转数组
 */

// @lc code=start
public class Solution {
    public void Rotate(int[] nums, int k) {
        int n = nums.Length;
        k %= n;
        if(k == 0) return;
        int t = 0;
        //全体反转
        int i = 0, j = n - 1;
        while(i < j)
        {
            t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
            i++;
            j--;
        }
        //前半反转
        i = 0;
        j = k - 1;
        while(i < j)
        {
            t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
            i++;
            j--;
        }
        //后半反转
        i = k;
        j = n - 1;
        while(i < j)
        {
            t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
            i++;
            j--;
        }
        return;
    }
}
// @lc code=end

