/*
 * @lc app=leetcode.cn id=1441 lang=csharp
 *
 * [1441] 用栈操作构建数组
 */

// @lc code=start
public class Solution {
    public IList<string> BuildArray(int[] target, int n) {
        IList<string> ans = new List<string>{};
        //遍历, 直到获取到target的最后一个值
        int p = 0;
        for(int i = 1; i <= target[target.Length - 1]; i++)
        {
            //每一个值都有Push操作
            ans.Add("Push");
            if(target[p] != i)
            {
                //不存在的值需要Pop
                ans.Add("Pop");
            }
            else
            {
                p++;
            }
        }
        return ans;
    }
}
// @lc code=end

