/*
 * @lc app=leetcode.cn id=914 lang=csharp
 *
 * [914] 卡牌分组
 */

// @lc code=start
public class Solution {
    public int GetGCD(int a, int b)
    {
        if (a == b) return a;
        int max = Math.Max(a, b);
        int min = Math.Min(a, b);
        while (max % min != 0)
        {
            int x = min;
            int y = max % min;
            max = Math.Max(x, y);
            min = Math.Min(x, y);
        }
        return min;
    }

    public bool HasGroupsSizeX(int[] deck) {
        if (deck.Length < 2) return false;
        if (deck.Length == 2)
        {
            return deck[0] == deck[1];
        }
        int[] t = new int[10000];
        foreach (int i in deck)
        {
            t[i]++;
        }
        int x = -1;
        foreach (int i in t)
        {
            if(i !=0)
            {
                if (x == -1)
                {
                    x = i;
                }
                else
                {
                    x = GetGCD(x, i);
                    if (x < 2) return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end

