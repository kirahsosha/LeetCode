/*
 * @lc app=leetcode.cn id=466 lang=csharp
 *
 * [466] 统计重复个数
 */

// @lc code=start
public class Solution {
    public int GetMaxRepetitions(string s1, int n1, string s2, int n2) {
        if(n1 == 0) return 0;
        int len1 = s1.Length;
        int len2 = s2.Length;
        //s2中每个字符开头, 能在s1中重复多少次
        int[] repeatNum = new int[len2];
        //s2中每个字符开头. 尽可能重复, 下一次在s1中出现的第一个字符的索引
        int[] nextChar = new int[len2];

        for (int i = 0; i < len2; i++)
        {
            //计算每个字符开头的情况
            int cnt = 0, idx = i;

            //贪心法进行搜索
            for (int j = 0; j < len1; j++)
            {
                if (s1[j] == s2[idx])
                {
                    idx++;
                    if (idx == len2)
                    {
                        idx = 0;
                        cnt++;
                    }
                }
            }

            nextChar[i] = idx;
            repeatNum[i] = cnt;
        }
        
        int res = 0;
        int next = 0;

        for (int i = 0; i < n1; i++)
        {
            res += repeatNum[next];
            next = nextChar[next];
        }

        return res / n2;
    }
}
// @lc code=end

