/*
 * @lc app=leetcode.cn id=3043 lang=csharp
 *
 * [3043] 最长公共前缀的长度
 */

// @lc code=start
public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        var prefixSet = new HashSet<int>();

        foreach (var num in arr1)
        {
            for (var n = num; n > 0; n /= 10)
            {
                prefixSet.Add(n);
            }
        }

        var maxLen = 0;
        foreach (var num in arr2)
        {
            var length = 0;
            for (var temp = num; temp > 0; temp /= 10)
            {
                length++;
            }

            for (var n = num; n > 0; n /= 10)
            {
                if (prefixSet.Contains(n))
                {
                    if (length > maxLen)
                    {
                        maxLen = length;
                    }
                    break;
                }
                length--;
            }
        }

        return maxLen;
    }
}
// @lc code=end
