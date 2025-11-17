/*
 * @lc app=leetcode.cn id=383 lang=csharp
 *
 * [383] 赎金信
 */

// @lc code=start
public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if(ransomNote.Length == 0) return true;
        if(magazine.Length == 0) return false;
        for(int i = 0; i < ransomNote.Length; i++)
        {
            if(ransomNote[i] == '|') continue;
            int n1 = 0, n2 = 0;
            for(int j = i; j < ransomNote.Length; j++)
            {
                if(ransomNote[j] == ransomNote[i])
                {
                    n1++;
                }
            }
            for(int k = 0; k < magazine.Length; k++)
            {
                if(magazine[k] == ransomNote[i])
                {
                    n2++;
                }
            }
            if(n1 > n2) return false;
            ransomNote = ransomNote.Replace(ransomNote[i], '|');
            magazine = magazine.Replace(ransomNote[i], '|');
        }
        return true;
    }
}
// @lc code=end

