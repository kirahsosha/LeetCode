/*
 * @lc app=leetcode.cn id=1893 lang=csharp
 *
 * [1893] 检查是否区域内所有整数都被覆盖
 */

// @lc code=start
public class Solution {
    public bool IsCovered(int[][] ranges, int left, int right) {
        List<int> list = new List<int>();
            foreach(var range in ranges)
            {
                int l = range[0];
                int r = range[1];
                if(l > right || r < left)
                {
                    continue;
                }
                else if(l <= left && r >= right)
                {
                    return true;
                }
                else if(l < left)
                {
                    for(int i = left; i <= r; i++)
                    {
                        if(!list.Contains(i))
                        {
                            list.Add(i);
                        }
                    }
                }
                else if(r > right)
                {
                    for(int i = l; i <= right; i++)
                    {
                        if (!list.Contains(i))
                        {
                            list.Add(i);
                        }
                    }
                }
                else
                {
                    for (int i = l; i <= r; i++)
                    {
                        if (!list.Contains(i))
                        {
                            list.Add(i);
                        }
                    }
                }
            }
            if (list.Count == right - left + 1) return true;
            else return false;
    }
}
// @lc code=end

