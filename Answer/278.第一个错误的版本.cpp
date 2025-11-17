/*
 * @lc app=leetcode.cn id=278 lang=cpp
 *
 * [278] 第一个错误的版本
 */

// @lc code=start
// Forward declaration of isBadVersion API.
bool isBadVersion(int version);

class Solution {
public:
    int cut(long fv, long lv)
    {
        if(lv == fv) return fv;
        if(lv == (fv + 1))
        {
            if(isBadVersion(fv)) return fv;
            else return lv;
        }
        if(isBadVersion((fv + lv + 1) / 2))
        {
            return cut(fv, (fv + lv + 1) / 2);
        }
        else
        {
            return cut((fv + lv + 1) / 2 + 1, lv);
        }
    }

    int firstBadVersion(int n) {
        return cut(1, (long)n);
    }
};
// @lc code=end

