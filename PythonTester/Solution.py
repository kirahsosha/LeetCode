from typing import List

# [198] 打家劫舍
def rob(self, nums: List[int]) -> int:
    # dp[i] = max(dp[i-1], dp[i-2] + num[i])
    # 因为在计算dp[i]的时候只需要使用到dp[i - 1]和dp[i - 2], 所以将数组优化为两个int
    n = len(nums)
    if n == 0:
        return 0
    if n == 1:
        return nums[0]
    if n == 2:
        return max(nums[0], nums[1])
    dp1 = nums[0]
    dp2 = max(nums[0], nums[1])
    for i in range(2, n):
        sum = max(dp1 + nums[i], dp2)
        dp1 = dp2
        dp2 = sum
    return max(dp1, dp2)

# [3577] 统计计算机解锁顺序排列数
def countPermutations(self, complexity: List[int]) -> int:
    MOD = 1000000007
    res = 1
    for i in range(1, len(complexity)):
        if complexity[i] <= complexity[0]:
            return 0
        res = res * i % MOD
    return res

# [3531] 统计被覆盖的建筑
def countCoveredBuildings(self, n: int, buildings: List[List[int]]) -> int:
    # Key：横坐标；Value：纵坐标范围
    ver = {}
    # Key：纵坐标；Value：横坐标范围
    hor = {}
    for building in buildings:
        x = building[0]
        y = building[1]
        if ver.get(x, 0) != 0:
            ver[x][0] = min(ver[x][0], y)
            ver[x][1] = max(ver[x][1], y)
        else:
            ver[x] = [y, y]
        if hor.get(y, 0) != 0:
            hor[y][0] = min(hor[y][0], x)
            hor[y][1] = max(hor[y][1], x)
        else:
            hor[y] = [x, x]
    res = 0
    for building in buildings:
        x = building[0]
        y = building[1]
        if ver[x][0] < y < ver[x][1] and hor[y][0] < x < hor[y][1]:
            res = res + 1
    return res