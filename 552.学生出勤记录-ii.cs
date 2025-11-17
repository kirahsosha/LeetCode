/*
 * @lc app=leetcode.cn id=552 lang=csharp
 *
 * [552] 学生出勤记录 II
 */

// @lc code=start
public class Solution {
    public Dictionary<int, long> Absent0Late0 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent1Late0 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent0Late1 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent1Late1 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent0Late2 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent1Late2 = new Dictionary<int, long>();
        
        const int MOD = 1000000007;

    public int CheckRecord(int n) {
        //初始化
            if(!Absent0Late0.ContainsKey(1))
            {
                Absent0Late0.Add(1, 1);
                Absent1Late0.Add(1, 1);
                Absent0Late1.Add(1, 1);
                Absent1Late1.Add(1, 0);
                Absent0Late2.Add(1, 0);
                Absent1Late2.Add(1, 0);
            }
            if (!Absent0Late0.ContainsKey(n))
            {
                CalRecord(n);
            }
            long num = Absent0Late0[n] + Absent1Late0[n] + Absent0Late1[n] + Absent1Late1[n] + Absent0Late2[n] + Absent1Late2[n];
            return (int)(num % MOD);
    }

    public void CalRecord(int n)
        {
            if (!Absent0Late0.ContainsKey(n - 1))
            {
                CalRecord(n - 1);
            }
            //Absent0Late0 + 'P' = Absent0Late0
            //Absent0Late0 + 'A' = Absent1Late0
            //Absent0Late0 + 'L' = Absent0Late1
            //Absent1Late0 + 'P' = Absent1Late0
            //Absent1Late0 + 'A' X
            //Absent1Late0 + 'L' = Absent1Late1
            //Absent0Late1 + 'P' = Absent0Late0
            //Absent0Late1 + 'A' = Absent1Late0
            //Absent0Late1 + 'L' = Absent0Late2
            //Absent1Late1 + 'P' = Absent1Late0
            //Absent1Late1 + 'A' X
            //Absent1Late1 + 'L' = Absent1Late2
            //Absent0Late2 + 'P' = Absent0Late0
            //Absent0Late2 + 'A' = Absent1Late0
            //Absent0Late2 + 'L' X
            //Absent1Late2 + 'P' = Absent1Late0
            //Absent1Late2 + 'A' X
            //Absent1Late2 + 'L' X
            Absent0Late0.Add(n, (Absent0Late0[n - 1] + Absent0Late1[n - 1] + Absent0Late2[n - 1]) % MOD);
            Absent1Late0.Add(n, (Absent0Late0[n - 1] + Absent1Late0[n - 1] + Absent0Late1[n - 1] + Absent1Late1[n - 1] + Absent0Late2[n - 1] + Absent1Late2[n - 1]) % MOD);
            Absent0Late1.Add(n, Absent0Late0[n - 1] % MOD);
            Absent1Late1.Add(n, Absent1Late0[n - 1] % MOD);
            Absent0Late2.Add(n, Absent0Late1[n - 1] % MOD);
            Absent1Late2.Add(n, Absent1Late1[n - 1] % MOD);
        }
}
// @lc code=end

