#
# @lc app=leetcode.cn id=3661 lang=python3
#
# [3661] 可以被机器人摧毁的最大墙壁数目
#

# 状态定义：
# sort[i] = 按位置排序后的第i个机器人的原始索引
# dp[sort[i]][0] = 机器人sort[i]向左开枪时，sort[0..i]能摧毁的最大墙壁数
# dp[sort[i]][1] = 机器人sort[i]向右开枪时，sort[0..i]能摧毁的最大墙壁数
# 核心：向左开枪范围是[pos-dist, pos]，向右是[pos, pos+dist]
# 相邻机器人的射击范围不能重叠，但当前向左和前一个向右可以相邻(pos == prevPos+prevDist)
# 转移：
# 当前向左开枪时，若前一个也向左：范围是[max(pos-dist, 前一个pos+1), pos]
#           若前一个向右：范围是[max(pos-dist, 前一个右边界+1), pos]
# 当前向右开枪时，若前一个向左：范围是[pos, min(pos+dist, 后一个pos-1)]
#           若前一个向右：范围是[max(pos, 前一个右边界+1), min(pos+dist, 后一个pos-1)]
# @lc code=start
class Solution:
    def maxWalls(self, robots: list[int], distance: list[int], walls: list[int]) -> int:
        walls.sort()
        n = len(robots)
        if n == 0:
            return 0
        
        idx = sorted(range(n), key=lambda i: robots[i])
        
        def lower_bound(arr: list[int], target: int) -> int:
            left, right = 0, len(arr)
            while left < right:
                mid = (left + right) // 2
                if arr[mid] < target:
                    left = mid + 1
                else:
                    right = mid
            return left
        
        def count_walls(left: int, right: int) -> int:
            if left > right:
                return 0
            l = lower_bound(walls, left)
            r = lower_bound(walls, right + 1)
            return r - l
        
        dp = [[0, 0] for _ in range(n)]
        
        for i in range(n):
            pos = robots[idx[i]]
            dist = distance[idx[i]]
            orig_left = pos - dist
            orig_right = pos + dist
            
            if i == 0:
                right_bound = orig_right
                if n > 1:
                    right_bound = min(orig_right, robots[idx[i + 1]] - 1)
                dp[i][0] = count_walls(orig_left, pos)
                dp[i][1] = count_walls(pos, right_bound)
            else:
                prev_pos = robots[idx[i - 1]]
                prev_dist = distance[idx[i - 1]]
                prev_orig_right = prev_pos + prev_dist
                
                left_bound = max(orig_left, prev_pos + 1)
                right_bound = orig_right
                if i < n - 1:
                    right_bound = min(orig_right, robots[idx[i + 1]] - 1)
                
                break_left_from_left = count_walls(left_bound, pos)
                prev_actual_right = min(prev_orig_right, pos - 1)
                break_left_from_right = count_walls(max(left_bound, prev_actual_right + 1), pos)
                dp[i][0] = max(dp[i - 1][0] + break_left_from_left, dp[i - 1][1] + break_left_from_right)
                
                break_right_from_left = count_walls(pos, right_bound)
                break_right_from_right = count_walls(max(pos, prev_actual_right + 1), right_bound)
                dp[i][1] = max(dp[i - 1][0] + break_right_from_left, dp[i - 1][1] + break_right_from_right)
        
        return max(dp[n - 1][0], dp[n - 1][1])
# @lc code=end
