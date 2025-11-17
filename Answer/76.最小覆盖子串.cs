/*
 * @lc app=leetcode.cn id=76 lang=csharp
 *
 * [76] 最小覆盖子串
 */

// @lc code=start
public class Solution {
    public string MinWindow(string s, string t) {
        Dictionary<char,int> dic = new Dictionary<char,int>();
        Dictionary<char,int> window = new Dictionary<char,int>();
        int valid = 0;
        int left = 0;
        int right = 0;
        string res = "";
        int startindex = 0;
        int len = int.MaxValue;
        foreach(char item in t){
            if(dic.ContainsKey(item)){
                dic[item]++;
            }else{
                dic.Add(item,1);
            }
        }
        while(right < s.Length){
            char temp = s[right];
            right++;
            if(dic.ContainsKey(temp)){
                if(window.ContainsKey(temp)){
                    window[temp]++;
                }else{
                    window.Add(temp,1);
                }
                if(window[temp] == dic[temp]){
                    valid++;
                }
            }
            while(valid == dic.Count){
                if(right - left < len){
                    len = right - left ;
                    startindex = left;
                }
                char c = s[left];
                left++;
                if(dic.ContainsKey(c)){
                    if(window[c] == dic[c]){
                        valid--;
                    }
                    window[c]--;
                }
            }
        }
        return len == int.MaxValue ? "" : s.Substring(startindex,len);
    }
}
// @lc code=end

