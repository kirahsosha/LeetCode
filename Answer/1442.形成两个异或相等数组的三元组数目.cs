/*
 * @lc app=leetcode.cn id=1442 lang=csharp
 *
 * [1442] 形成两个异或相等数组的三元组数目
 */

// @lc code=start
public class Solution {
    public int CountTriplets(int[] arr) {
        int len = arr.Length;
        if(len == 1) return 0;
        if(len == 2)
        {
            if(arr[0] == arr[1]) return 1;
            else return 0;
        }
        int ans = 0;
        //从0到每个数的异或值
        int[] xor = new int[len + 1];
        //使用HashTable保存<xor[k], count>和<xor[k], sum>的键值对用于检索xor值
        Hashtable htCnt = new Hashtable();
        Hashtable htSum = new Hashtable();
        //遍历计算所有的xor
        //xor[0]为没有任何值时的异或值
        //遍历下标为实际下标 + 1
        //然后检索表中是否存在与xor[k]相等的value
        //如果存在这样的xor[i - 1], 就有一组arr[i]^...^arr[k] == 0
        //就存在k - i个解
        //再将当前的k累加到ht中, 计数 + 1
        xor[0] = 0;
        htCnt.Add(xor[0], 1);
        htSum.Add(xor[0], -1);
        for(int k = 1; k <= len; k++)
        {
            xor[k] = xor[k - 1] ^ arr[k - 1];
            if(htCnt.ContainsKey(xor[k]))
            {
                //之前已存在与xor[k]相等的xor[i]值
                //计算当前满足条件的解的数量
                int cnt = (int)htCnt[xor[k]];
                int sum = (int)htSum[xor[k]];
                //实际k值: k - 1
                //实际i值: i + 1
                ans += (k - 2) * cnt - sum;
                //保存当前k值
                htCnt[xor[k]] = (int)htCnt[xor[k]] + 1;
                htSum[xor[k]] = (int)htSum[xor[k]] + k - 1;
            }
            else
            {
                //之前不存在xor[k]相等的sum[i]值
                //将<xor[k], count>和<xor[k], sum>保存到ht
                htCnt.Add(xor[k], 1);
                htSum.Add(xor[k], k - 1);
            }
        }
        return ans;
    }
}
// @lc code=end

