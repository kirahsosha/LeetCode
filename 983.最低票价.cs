/*
 * @lc app=leetcode.cn id=983 lang=csharp
 *
 * [983] 最低票价
 */

// @lc code=start
public class Solution {
    int minCost = int.MaxValue; //维护的最小票价
    int[] day = new int[]{1, 7, 30}; //票价对应可以度过的假期数
    int[] memo; //备忘录

    public void DFS(int[] odd, int[] costs, int index, int cost)
    {
        //已经有一个最小值, 而且最小值比现在的花费还小, 剪枝
        if(minCost != int.MaxValue && cost >= minCost) return;
        if(index == odd.Length)
        {
            //维护最小值
            minCost = Math.Min(cost, minCost);
            return;
        }
        //备忘录中有这个下标的花费, 并且花费比较少, 剪枝
        if(memo[index] != 0 && memo[index] <= cost) return;
        memo[index] = cost;

        for(int i = 0; i < costs.Length; i++)
        {
            //买了这次票我能度假多少天, 加上当前度假间隔是因为可能是隔了这么多天直接买的, 要加上当前间隔的消耗
            int canDay = day[i] + odd[index] - 1;
            //记录一下当前的下标
            int temp = index;
            //买票要花钱
            cost += costs[i];
            while(canDay > 0 && index < odd.Length)
            {
                //减去花费的天数
                canDay -= odd[index];
                //能够度过当前下标的天数
                if(canDay >= 0)
                {
                    //准备下个假期
                    index++;
                }
            }
            //递归继续买票
            DFS(odd, costs, index, cost);
            //回溯, 不买了
            cost -= costs[i];
            //回到没买这个票前的下标
            index = temp;
        }
    }

    public int MincostTickets(int[] days, int[] costs) {
        if(days.Length == 1) return costs[0];
        //度假间隔天数数组
        int[] odd = new int[days.Length];
        //第一次为一天
        odd[0] = 1;
        for(int i = 1; i < days.Length; i++)
        {
            odd[i] = days[i] - days[i - 1];
        }
        memo = new int[days.Length];
        DFS(odd, costs, 0, 0);
        return minCost;
    }
}
// @lc code=end

