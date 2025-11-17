/*
 * @lc app=leetcode.cn id=383 lang=cpp
 *
 * [383] 赎金信
 */

// @lc code=start
class Solution {
public:
    bool canConstruct(string ransomNote, string magazine) {
        if(ransomNote.length() == 0) return true;
        if(magazine.length() == 0) return false;
        int i = 0, j = 0, k = 0;
        while(i < ransomNote.length())
        {
            j = 0;
            k = 0;
            while(j < magazine.length())
            {
                if(ransomNote[i] == magazine[j])
                {
                    magazine[j] = '\0';
                    k = 1;
                    break;
                }
                j++;
            }
            if(k == 0) return false;
            i++;
        }
        return true;
    }
};
// @lc code=end

