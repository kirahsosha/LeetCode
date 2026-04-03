import java.util.Arrays;

/*
 * @lc app=leetcode.cn id=3661 lang=java
 *
 * [3661] 可以被机器人摧毁的最大墙壁数目
 */

// 状态定义：
// sort[i] = 按位置排序后的第i个机器人的原始索引
// dp[sort[i]][0] = 机器人sort[i]向左开枪时，sort[0..i]能摧毁的最大墙壁数
// dp[sort[i]][1] = 机器人sort[i]向右开枪时，sort[0..i]能摧毁的最大墙壁数
// 核心：向左开枪范围是[pos-dist, pos]，向右是[pos, pos+dist]
// 相邻机器人的射击范围不能重叠，但当前向左和前一个向右可以相邻(pos == prevPos+prevDist)
// 转移：
// 当前向左开枪时，若前一个也向左：范围是[max(pos-dist, 前一个pos+1), pos]
//           若前一个向右：范围是[max(pos-dist, 前一个右边界+1), pos]
// 当前向右开枪时，若前一个向左：范围是[pos, min(pos+dist, 后一个pos-1)]
//           若前一个向右：范围是[max(pos, 前一个右边界+1), min(pos+dist, 后一个pos-1)]
// @lc code=start
class Solution {
    public int maxWalls(int[] robots, int[] distance, int[] walls) {
        Arrays.sort(walls);
        int n = robots.length;
        if (n == 0) {
            return 0;
        }
        
        Integer[] idx = new Integer[n];
        for (int i = 0; i < n; i++) {
            idx[i] = i;
        }
        Arrays.sort(idx, (a, b) -> robots[a] - robots[b]);
        
        int[][] dp = new int[n][2];
        
        for (int i = 0; i < n; i++) {
            int pos = robots[idx[i]];
            int dist = distance[idx[i]];
            int origLeft = pos - dist;
            int origRight = pos + dist;
            
            if (i == 0) {
                int rightBound = origRight;
                if (n > 1) {
                    rightBound = Math.min(origRight, robots[idx[i + 1]] - 1);
                }
                dp[i][0] = countWalls(walls, origLeft, pos);
                dp[i][1] = countWalls(walls, pos, rightBound);
            } else {
                int prevPos = robots[idx[i - 1]];
                int prevDist = distance[idx[i - 1]];
                int prevOrigRight = prevPos + prevDist;
                
                int leftBound = Math.max(origLeft, prevPos + 1);
                int rightBound = origRight;
                if (i < n - 1) {
                    rightBound = Math.min(origRight, robots[idx[i + 1]] - 1);
                }
                
                int breakLeftFromLeft = countWalls(walls, leftBound, pos);
                int prevActualRight = Math.min(prevOrigRight, pos - 1);
                int breakLeftFromRight = countWalls(walls, Math.max(leftBound, prevActualRight + 1), pos);
                dp[i][0] = Math.max(dp[i - 1][0] + breakLeftFromLeft, dp[i - 1][1] + breakLeftFromRight);
                
                int breakRightFromLeft = countWalls(walls, pos, rightBound);
                int breakRightFromRight = countWalls(walls, Math.max(pos, prevActualRight + 1), rightBound);
                dp[i][1] = Math.max(dp[i - 1][0] + breakRightFromLeft, dp[i - 1][1] + breakRightFromRight);
            }
        }
        
        return Math.max(dp[n - 1][0], dp[n - 1][1]);
    }
    
    private int countWalls(int[] walls, int left, int right) {
        if (left > right) {
            return 0;
        }
        int l = lowerBound(walls, left);
        int r = lowerBound(walls, right + 1);
        return r - l;
    }
    
    private int lowerBound(int[] arr, int target) {
        int left = 0, right = arr.length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
// @lc code=end
