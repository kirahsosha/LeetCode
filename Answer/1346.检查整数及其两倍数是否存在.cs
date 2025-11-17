/*
 * @lc app=leetcode.cn id=1346 lang=csharp
 *
 * [1346] 检查整数及其两倍数是否存在
 */

// @lc code=start
public class Solution {
    public bool CheckIfExist(int[] arr) {
        Array.Sort(arr);
        int a = 0, b = 1;
        while(a < arr.Length && b < arr.Length)
        {
            if(arr[a] < 0 && arr[b] < 0)
            {
                if(arr[a] == 2 * arr[b]) return true;
                else if(arr[a] < 2 * arr[b])
                {
                    a++;
                    continue;
                }
                else
                {
                    b++;
                    continue;
                }
            }
            if(arr[a] == 0 && arr[b] == 0 && a != b) return true;
            if(arr[a] <= 0 && arr[b] >= 0)
            {
                a++;
                continue;
            }
            if(arr[a] > 0 && arr[b] >= 0)
            {
                if(2 * arr[a] == arr[b]) return true;
                else if(2 * arr[a] < arr[b])
                {
                    a++;
                    continue;
                }
                else
                {
                    b++;
                    continue;
                }
            }
        }
        return false;
    }
}
// @lc code=end

