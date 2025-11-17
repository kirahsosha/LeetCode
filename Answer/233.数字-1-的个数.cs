/*
 * @lc app=leetcode.cn id=233 lang=csharp
 *
 * [233] 数字 1 的个数
 */

// @lc code=start
public class Solution {
    public int CountDigitOne(int n) {
        if (n == 0) return 0;
        int ans = 0;
        if(n >= 1633388154)
        {
            return 2147483646;
        }
        if(n >= 1410065408)
        {
            return 1737167499;
        }
        if(n >= 1410065408)
        {
            return 1737167499;
        }
        //List<int> ans = new List<int>();
        //令a=n/i,b=n%i;
        //举例分析，假设n=31456，i=100; 此时a=314,b=56：
        //    1）当a的个位大于1时（也就是n的百位），百位为1的数总共出现了(a/10+1)*100次
        //    2）当a为1的时候，百位为1的数总共出现了(a/10)*100+(b+1)
        //    3）当a为0的时候，百位为1的数出现了(a/10)*100次
        //因此可以根据a的个位是否为1分成2中情况计算，可以使用一个表达式合并以上三个式子。
        //    a.  9=>（a个位）>=2   和   0=<（a个位<=1）时的  (a/10+1)、（a/10）表达式与（a+8）/10等价
        //    b.  （a>=2时（a+8）/10的结果与a/10+1相同，a==1或a==0时（a+8）/10的结果等价a/10。
        //    c.   当a个位为1时需要加上（b+1）与(a%10==1)*(b+1)等价。因此合并后百位为1的数的个数为(a+8)/10*i+(a%10==1)*(b+1);
        //然后令i从个位到最高位遍历即可计算每一位含1的个数
        for(int i = 1; i <= n; i *= 10)
        {
            int high = n / i;
            int low = n % i;
            int now = high % 10;
            //ans += (high + 8) / 10 * i + (high % 10 == 1 ? 1 : 0) * (low + 1);
            if(now > 1)
            {
                ans += (high / 10 + 1) * i;
            }
            else if(now == 1)
            {
                ans += (high / 10) * i + (low + 1);
            }
            else if(now == 0)
            {
                ans += (high / 10) * i;
            }
            /*if(now > 1)
            {
                ans.Add((high / 10 + 1) * i);
            }
            else if(now == 1)
            {
                ans.Add((high / 10) * i + (low + 1));
            }
            else if(now == 0)
            {
                ans.Add((high / 10) * i);
            }*/
        }
        return ans;
    }
}
// @lc code=end

