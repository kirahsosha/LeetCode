/*
 * @lc app=leetcode.cn id=278 lang=csharp
 *
 * [278] 第一个错误的版本
 */

// @lc code=start
/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int cut(long fv, long lv)
    {
        if (lv == fv) return (int)fv;
        if (lv == (fv + 1))
        {
            if (IsBadVersion((int)fv)) return (int)fv;
            else return (int)lv;
        }
        long t = (fv + lv + 1) / 2;
        if (IsBadVersion((int)t))
        {
            return cut(fv, t);
        }
        else
        {
            return cut(t + 1, lv);
        }
    }

    public int FirstBadVersion(int n) {
        return cut(1, (long)n);
    }
}
// @lc code=end

