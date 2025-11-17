/*
 * @lc app=leetcode.cn id=443 lang=csharp
 *
 * [443] 压缩字符串
 */

// @lc code=start
public class Solution {
    public int Compress(char[] chars) {
        if (chars.Length == 1) return 1;
            int ans = 0;
            char n=chars[0];
            int index = 0;
            int cindex = 0;
            foreach(var c in chars)
            {
                if(c==n)
                {
                    index++;
                }
                else
                {
                    ans += 1 + (index == 1 ? 0 : index.ToString().Length);
                    chars[cindex++] = n;
                    if(index != 1)
                    {
                        foreach (var cc in index.ToString())
                        {
                            chars[cindex++] = cc;
                        }
                    }
                    index = 1;
                    n = c;
                }
            }
            ans += 1 + (index == 1 ? 0 : index.ToString().Length);
            chars[cindex++] = n;
            if (index != 1)
            {
                foreach (var cc in index.ToString())
                {
                    chars[cindex++] = cc;
                }
            }
            chars = chars.Take(cindex).ToArray();
            return ans;
    }
}
// @lc code=end

