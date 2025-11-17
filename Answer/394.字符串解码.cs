/*
 * @lc app=leetcode.cn id=394 lang=csharp
 *
 * [394] 字符串解码
 */

// @lc code=start
public class Solution
{
    public string DecodeString(string s)
    {
        if (s.Length == 0) return s;
        int p = 0;
        Stack<string> st = new Stack<string>();
        string head = "";
        while (p < s.Length)
        {
            if (s[p] == '[')
            {
                st.Push(head);
                head = "";
            }
            else if(s[p] == ']')
            {
                string body = head;
                head = st.Pop();
                string temp = "";
                string num = "";
                //解析
                foreach(char c in head)
                {
                    if(c < '0' || c > '9') temp += c;
                    else num += c;
                }
                int n = int.Parse(num);
                head = temp;
                for(int i = 1; i <= n; i++)
                {
                    head += body;
                }
            }
            else head += s[p];
            p++;
        }
        return head;
    }
}
// @lc code=end

