/*
 * @lc app=leetcode.cn id=3661 lang=typescript
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
function maxWalls(robots: number[], distance: number[], walls: number[]): number {
    walls.sort((a, b) => a - b);
    const n = robots.length;
    if (n === 0) {
        return 0;
    }
    
    const idx = Array.from({ length: n }, (_, i) => i);
    idx.sort((a, b) => robots[a] - robots[b]);
    
    const countWalls = (left: number, right: number): number => {
        if (left > right) {
            return 0;
        }
        const l = lowerBound(walls, left);
        const r = lowerBound(walls, right + 1);
        return r - l;
    };
    
    const dp: number[][] = Array.from({ length: n }, () => [0, 0]);
    
    for (let i = 0; i < n; i++) {
        const pos = robots[idx[i]];
        const dist = distance[idx[i]];
        const origLeft = pos - dist;
        const origRight = pos + dist;
        
        if (i === 0) {
            let rightBound = origRight;
            if (n > 1) {
                rightBound = Math.min(origRight, robots[idx[i + 1]] - 1);
            }
            dp[i][0] = countWalls(origLeft, pos);
            dp[i][1] = countWalls(pos, rightBound);
        } else {
            const prevPos = robots[idx[i - 1]];
            const prevDist = distance[idx[i - 1]];
            const prevOrigRight = prevPos + prevDist;
            
            const leftBound = Math.max(origLeft, prevPos + 1);
            let rightBound = origRight;
            if (i < n - 1) {
                rightBound = Math.min(origRight, robots[idx[i + 1]] - 1);
            }
            
            const breakLeftFromLeft = countWalls(leftBound, pos);
            const prevActualRight = Math.min(prevOrigRight, pos - 1);
            const breakLeftFromRight = countWalls(Math.max(leftBound, prevActualRight + 1), pos);
            dp[i][0] = Math.max(dp[i - 1][0] + breakLeftFromLeft, dp[i - 1][1] + breakLeftFromRight);
            
            const breakRightFromLeft = countWalls(pos, rightBound);
            const breakRightFromRight = countWalls(Math.max(pos, prevActualRight + 1), rightBound);
            dp[i][1] = Math.max(dp[i - 1][0] + breakRightFromLeft, dp[i - 1][1] + breakRightFromRight);
        }
    }
    
    return Math.max(dp[n - 1][0], dp[n - 1][1]);
}

function lowerBound(arr: number[], target: number): number {
    let left = 0, right = arr.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}
// @lc code=end
