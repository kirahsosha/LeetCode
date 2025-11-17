/*
 * @lc app=leetcode.cn id=887 lang=csharp
 *
 * [887] 鸡蛋掉落
 */

// @lc code=start
public class Solution {
    private int search(int a, int b)
    {
        if(a == 1 || b == 1)
        {
            return a;
        }
        return search(a - 1, b - 1) + 1 + search(a - 1, b);
    }

    public int SuperEggDrop(int K, int N){
        int num = 1;
        while (search(num++, K) < N);
        return num - 1;
    }
}
// @lc code=end

