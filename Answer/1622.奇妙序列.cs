/*
 * @lc app=leetcode.cn id=1622 lang=csharp
 *
 * [1622] 奇妙序列
 */

// @lc code=start
public class Fancy
{
    private const int MOD = 1000000007;
    private List<int> value;
    private int a;
    private int b;

    public Fancy()
    {
        value = new List<int>();
        a = 1;
        b = 0;
    }

    public void Append(int val)
    {
        long adjustedVal = ((long)(val - b + MOD) % MOD) * Inv(a) % MOD;
        value.Add((int)adjustedVal);
    }

    public void AddAll(int inc)
    {
        b = (b + inc) % MOD;
    }

    public void MultAll(int m)
    {
        a = (int)((long)a * m % MOD);
        b = (int)((long)b * m % MOD);
    }

    public int GetIndex(int idx)
    {
        if (idx >= value.Count)
        {
            return -1;
        }
        int ans = (int)(((long)a * value[idx] % MOD + b) % MOD);
        return ans;
    }

    private int QuickMul(int x, int y)
    {
        long ret = 1;
        long cur = x;
        while (y != 0)
        {
            if ((y & 1) != 0)
            {
                ret = ret * cur % MOD;
            }
            cur = cur * cur % MOD;
            y >>= 1;
        }
        return (int)ret;
    }

    // 乘法逆元
    private int Inv(int x)
    {
        return QuickMul(x, MOD - 2);
    }
}

/**
 * Your Fancy object will be instantiated and called as such:
 * Fancy obj = new Fancy();
 * obj.Append(val);
 * obj.AddAll(inc);
 * obj.MultAll(m);
 * int param_4 = obj.GetIndex(idx);
 */
// @lc code=end

