
import java.util.HashMap;

/*
 * @lc app=leetcode.cn id=3583 lang=java
 *
 * [3583] 统计特殊三元组
 */

// @lc code=start
class Solution {
    public int specialTriplets(int[] nums) {
        int MOD = 1000000007;
        //记录每个值的出现次数
        HashMap<Integer, Integer> dic = new HashMap<>();
        //记录i左边有多少符合条件nums[i]*2的值
        HashMap<Integer, Integer> count = new HashMap<>();
        for (int i = 0; i < nums.length; i++)
        {
            if (dic.containsKey(nums[i]))
            {
                dic.put(nums[i], dic.get(nums[i]) + 1);
            }
            else
            {
                dic.put(nums[i], 1);
            }
            if (nums[i] != 0 && dic.containsKey(nums[i] * 2))
            {
                count.put(i, dic.get(nums[i] * 2));
            }
        }
        int res = 0;
        for (HashMap.Entry<Integer, Integer> item : count.entrySet()) {
            var i = item.getKey();
            var value = item.getValue();
            if (i != 0)
            {
                var right = dic.get(nums[i] * 2) - value;
                res = (value * right + res) % MOD;
            }
        }
        //处理0
        if (dic.containsKey(0) && dic.get(0) >= 3)
        {
            var c = dic.get(0);
            long zero = (long)c * (c - 1) * (c - 2) / 6 % MOD;
            res = (res + (int)zero) % MOD;
        }
        return res;
    }
}
// @lc code=end

