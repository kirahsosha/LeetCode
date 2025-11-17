/*
 * @lc app=leetcode.cn id=28 lang=csharp
 *
 * [28] 实现 strStr()
 */

// @lc code=start
public class Solution {
    public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;
            if (string.IsNullOrEmpty(haystack)) return -1;
            if (needle.Length > haystack.Length) return -1;
            int len1 = haystack.Length;
            int len2 = needle.Length;
            //KMP算法
            // 原串和匹配串前面都加空格，使其下标从 1 开始
            haystack = " " + haystack;
            needle = " " + needle;
            // 构建 next 数组，数组长度为匹配串的长度（next 数组是和匹配串相关的）
            int[] next = new int[len2 + 1];
            // 构造过程 i = 2，j = 0 开始，i 小于等于匹配串长度 【构造 i 从 2 开始】
            for (int i = 2, j = 0; i <= len2; i++)
            {
                // 匹配不成功的话，j = next(j)
                while (j > 0 && needle[i] != needle[j + 1]) j = next[j];
                // 匹配成功的话，先让 j++
                if (needle[i] == needle[j + 1]) j++;
                // 更新 next[i]，结束本次循环，i++
                next[i] = j;
            }

            // 匹配过程，i = 1，j = 0 开始，i 小于等于原串长度 【匹配 i 从 1 开始】
            for (int i = 1, j = 0; i <= len1; i++)
            {
                // 匹配不成功 j = next(j)
                while (j > 0 && haystack[i] != needle[j + 1]) j = next[j];
                // 匹配成功的话，先让 j++，结束本次循环后 i++
                if (haystack[i] == needle[j + 1]) j++;
                // 整一段匹配成功，直接返回下标
                if (j == len2) return i - len2;
            }
            ////Sunday算法
            ////1.根据needle构建偏移表：
            ////存在：字符出现的最右位置到尾部的距离+1
            ////不存在：len2+1
            ////2.遍历haystack，提取len2长度的子串匹配needle
            ////若匹配，返回index
            ////若不匹配，查看子串的后一位字符，index按照偏移表后移
            //int check = 0;
            //while (check + len2 <= len1)
            //{
            //    int k = 0;
            //    while(k < len2)
            //    {
            //        if (haystack[check + k] == needle[k])
            //        {
            //            k++;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    if (k == len2) return check;
            //    if (check + len2 == len1) break;
            //    //查找偏移量
            //    for (int i = len2 - 1; i >= 0; i--)
            //    {
            //        if (haystack[check + len2] == needle[i])
            //        {
            //            check = check + len2 - i;
            //            break;
            //        }
            //        if (i == 0) check = check + len2 + 1;
            //    }
            //}
            return -1;
        }
}
// @lc code=end

