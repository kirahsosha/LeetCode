/*
 * @lc app=leetcode.cn id=3453 lang=csharp
 *
 * [3453] 分割正方形 I
 */

// @lc code=start
public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        long totalArea = 0;
        List<int[]> events = new List<int[]>();

        foreach (var sq in squares)
        {
            int y = sq[1], l = sq[2];
            totalArea += (long)l * l;
            events.Add([y, l, 1]);
            events.Add([y + l, l, -1]);
        }

        // 按y坐标排序
        events.Sort((a, b) => a[0].CompareTo(b[0]));

        double coveredWidth = 0;  // 当前扫描线下所有底边之和
        double currArea = 0;      // 当前累计面积
        double prevHeight = 0;    // 前一个扫描线的高度

        foreach (var eventItem in events)
        {
            int y = eventItem[0];
            int l = eventItem[1];
            int delta = eventItem[2];

            int diff = y - (int)prevHeight;
            // 两条扫描线之间新增的面积
            double area = coveredWidth * diff;
            // 如果加上这部分面积超过总面积的一半
            if (2L * (currArea + area) >= totalArea)
            {
                return prevHeight + (totalArea - 2.0 * currArea) / (2.0 * coveredWidth);
            }
            // 更新宽度：开始事件加宽度，结束事件减宽度
            coveredWidth += delta * l;
            currArea += area;
            prevHeight = y;
        }

        return 0.0;
    }
}
// @lc code=end

