import "sort"

/*
 * @lc app=leetcode.cn id=3661 lang=golang
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
func maxWalls(robots []int, distance []int, walls []int) int {
	sort.Ints(walls)
	n := len(robots)
	if n == 0 {
		return 0
	}

	idx := make([]int, n)
	for i := range idx {
		idx[i] = i
	}
	sort.Slice(idx, func(i, j int) bool {
		return robots[idx[i]] < robots[idx[j]]
	})

	countWalls := func(left, right int) int {
		if left > right {
			return 0
		}
		l := sort.Search(len(walls), func(i int) bool { return walls[i] >= left })
		r := sort.Search(len(walls), func(i int) bool { return walls[i] > right })
		return r - l
	}

	dp := make([][2]int, n)
	
	for i := 0; i < n; i++ {
		pos := robots[idx[i]]
		dist := distance[idx[i]]
		
		// 原始左右边界
		origLeft := pos - dist
		origRight := pos + dist
		
		if i == 0 {
			// 第一个机器人：向右不能越过后一个机器人
			rightBound := origRight
			if n > 1 {
				rightBound = min(origRight, robots[idx[i+1]]-1)
			}
			dp[i][0] = countWalls(origLeft, pos)
			dp[i][1] = countWalls(pos, rightBound)
		} else {
			prevPos := robots[idx[i-1]]
			prevDist := distance[idx[i-1]]
			prevOrigRight := prevPos + prevDist
			
			// 当前向左的左边界：不能越过前一个机器人的位置
			leftBound := max(origLeft, prevPos+1)
			
			// 当前向右的右边界：不能越过后一个机器人的位置
			rightBound := origRight
			if i < n-1 {
				rightBound = min(origRight, robots[idx[i+1]]-1)
			}
			
			// 当前向左，前一个向左：dp[i-1][0] + 新增墙壁
			// 前一个向左时，最右覆盖到prevPos，当前从leftBound到pos都是新的
			breakLeftFromLeft := countWalls(leftBound, pos)
			
			// 当前向左，前一个向右：dp[i-1][1] + 新增墙壁
			// 前一个向右时，最右覆盖到min(prevOrigRight, pos-1)
			prevActualRight := min(prevOrigRight, pos-1)
			breakLeftFromRight := countWalls(max(leftBound, prevActualRight+1), pos)
			
			dp[i][0] = max(dp[i-1][0]+breakLeftFromLeft, dp[i-1][1]+breakLeftFromRight)
			
			// 当前向右，前一个向左：dp[i-1][0] + 新增墙壁
			// 前一个向左时，最右覆盖到prevPos < pos，当前从pos开始都是新的
			breakRightFromLeft := countWalls(pos, rightBound)
			
			// 当前向右，前一个向右：dp[i-1][1] + 新增墙壁
			// 前一个向右时，最右覆盖到prevActualRight，当前从max(pos, prevActualRight+1)开始
			breakRightFromRight := countWalls(max(pos, prevActualRight+1), rightBound)
			
			dp[i][1] = max(dp[i-1][0]+breakRightFromLeft, dp[i-1][1]+breakRightFromRight)
		}
	}
	
	return max(dp[n-1][0], dp[n-1][1])
}

// @lc code=end
