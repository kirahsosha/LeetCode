import array
import heapq
import math
import queue
from math import floor
from queue import PriorityQueue
from re import match
from typing import List, Optional
from Model import TreeNode


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


# [3433] 统计用户被提及情况
def countMentions(self, numberOfUsers: int, events: List[List[str]]) -> List[int]:
    pq = PriorityQueue()
    all = 0

    for ev in events:
        event_type_str = ev[0]
        timestamp_str = ev[1]
        target_str = ev[2]

        e = 0 if event_type_str == "MESSAGE" else 1
        t = int(timestamp_str) * 3
        target_str = target_str.replace("id", "").strip()

        if e == 0:
            if target_str == "ALL":
                all += 1
            elif target_str == "HERE":
                pq.put((pq, [t, e, -1]))
            else:
                id_list = target_str.split()
                for id_str in id_list:
                    pq.put((pq, [t, e, int(id_str)]))
        else:
            user_id = int(target_str)
            pq.put((pq, [t - 1, e, user_id]))
            pq.put((pq, [t + 178, 2, user_id]))

    status = [0] * numberOfUsers
    res = [all] * numberOfUsers

    while not pq.empty():
        _, item = pq.get()
        event = item[1]
        target_id = item[2]

        if event == 0:
            if target_id == -1:
                for i in range(numberOfUsers):
                    if status[i] == 0:
                        res[i] += 1
            else:
                res[target_id] += 1
        elif event == 1:
            status[target_id] = -1
        else:
            status[target_id] = 0

    return res


# [3606] 优惠券校验器
def validateCoupons(self, code: List[str], businessLine: List[str], isActive: List[bool]) -> List[str]:
    res = {"electronics": [], "grocery": [], "pharmacy": [], "restaurant": []}
    n = len(code)
    for i in range(n):
        if not isActive[i]:
            continue
        if businessLine[i] not in res.keys():
            continue
        if not match("^[a-zA-Z0-9_]+$", code[i]):
            continue
        res[businessLine[i]].append(code[i])
    ans = []
    for _, v in res.items():
        v.sort()
        for i in v:
            ans.append(i)
    return ans


# [2147] 分隔长廊的方案数
def numberOfWays(self, corridor: str) -> int:
    MOD = 1000000007
    lst = []
    for i in range(len(corridor)):
        if corridor[i] == 'S':
            lst.append(i)
    if len(lst) == 0 or len(lst) % 2 == 1:
        return 0
    index = 0
    res = 1
    for i in range(1, len(lst) - 1):
        if index == 0:
            index = lst[i]
        else:
            res = res * (lst[i] - index) % MOD
            index = 0
    return res


# [2110] 股票平滑下跌阶段的数目
def getDescentPeriods(self, prices: List[int]) -> int:
    res = 0
    last = 0
    current = 0
    for price in prices:
        if current == 0:
            current += 1
            last = price
        elif price == last - 1:
            current += 1
            last = price
        else:
            res += current * (current + 1) // 2
            current = 1
            last = price
    res += current * (current + 1) // 2
    return res


# [3573] 买卖股票的最佳时机 V
def maximumProfit(self, prices: List[int], k: int) -> int:
    # dp[prices.Length][k + 1][3]
    # i - 天数
    # j - 完成进行交易数
    # 0 - 当前不持有股票，如果有交易，完成交易
    # 1 - 当前持有普通交易的股票
    # 2 - 当前持有做空交易的股票
    # 状态转移：
    # dp[i][j][0] - 前一天没交易或卖出前一天的普通交易或买进前一天的做空交易: max(dp[i - 1][j][0], dp[i - 1][j][1] + prices[i], dp[i - 1][j][2] - prices[i])
    # dp[i][j][1] - 保持前一天的普通交易或买进新的普通交易: max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i])
    # dp[i][j][2] - 保持前一天的做空交易或卖出新的做空交易: max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + prices[i])
    # 优化：只需要i - 1交易情况
    # dp[k + 1][3]
    # dp[j][0] = max(dp[j][0], dp[j][1] + prices[i], dp[j][2] - prices[i])
    # dp[j][1] = max(dp[j][1], dp[j - 1][0] - prices[i])
    # dp[j][2] = max(dp[j][2], dp[j - 1][0] + prices[i])
    # 初始i == 0：
    # dp[j][0] = 0
    # dp[j][1] = -prices[0]
    # dp[j][2] = prices[0]

    n = len(prices)
    dp = [[0] * 3 for _ in range(k + 1)]
    for j in range(0, k + 1):
        dp[j] = [0, -prices[0], prices[0]]

    for i in range(1, n):
        # 由于j的状态取决于[前一天]的j - 1的状态，所以倒序遍历j，保证在计算j的时候j - 1还是前一天的结果
        for j in range(k, 0, -1):
            dp[j][0] = max(dp[j][0], dp[j][1] + prices[i], dp[j][2] - prices[i])
            dp[j][1] = max(dp[j][1], dp[j - 1][0] - prices[i])
            dp[j][2] = max(dp[j][2], dp[j - 1][0] + prices[i])
    return dp[k][0]


# [3652] 按策略买卖股票的最佳时机
def maxProfit(self, prices: List[int], strategy: List[int], k: int) -> int:
    res = 0
    n = len(prices)
    for i in range(n):
        res += prices[i] * strategy[i]
    t = k // 2
    max_p = res
    for i in range(t):
        res -= prices[i] * strategy[i]
    for i in range(t, k):
        res += prices[i] * (1 - strategy[i])
    max_p = max(max_p, res)
    for i in range(n - k):
        res += prices[i] * strategy[i]
        res -= prices[i + t]
        res += prices[i + k] * (1 - strategy[i + k])
        max_p = max(max_p, res)
    return max_p


# [944] 删列造序
def minDeletionSize(self, strs: List[str]) -> int:
    n = len(strs[0])
    res = 0
    for i in range(n):
        for j in range(1, len(strs)):
            if strs[j][i] < strs[j - 1][i]:
                res += 1
                break
    return res


# [955] 删列造序 II
def minDeletionSize2(self, strs: List[str]) -> int:
    n = len(strs)
    m = len(strs[0])
    cuts = [False] * (n - 1)
    ans = 0
    for j in range(m):
        check = True
        for i in range(n - 1):
            if not cuts[i] and strs[i][j] > strs[i + 1][j]:
                ans += 1
                check = False
                break
        if check:
            for i in range(n - 1):
                if strs[i][j] < strs[i + 1][j]:
                    cuts[i] = True
    return ans


# [3074] 重新分装苹果
def minimumBoxes(self, apple: List[int], capacity: List[int]) -> int:
    apples = 0
    for appleCount in apple:
        apples += appleCount
    capacity.sort()
    capacity.reverse()
    res = 0
    for cap in capacity:
        apples -= cap
        res += 1
        if apples <= 0:
            break
    return res


# [3075] 幸福值最大化的选择方案
def maximumHappinessSum(self, happiness: List[int], k: int) -> int:
    happiness.sort()
    happiness.reverse()
    res = 0
    for i in range(k):
        res += max(0, happiness[i] - i);
    return res


# [2483] 商店的最少代价
def bestClosingTime(self, customers: str) -> int:
    cost = 0
    for i in range(len(customers)):
        if customers[i] == 'Y':
            cost += 1
    minCost = cost
    res = 0
    for i in range(len(customers)):
        if customers[i] == 'Y':
            cost -= 1
        else:
            cost += 1
        if cost < minCost:
            minCost = cost
            res = i + 1
    return res


# [2402] 会议室 III
def mostBooked(self, n: int, meetings: List[List[int]]) -> int:
    res = [0] * n
    free = list(range(n))
    heapq.heapify(free)
    busy = []

    # 按会议开始时间排序
    meetings.sort(key=lambda x: x)

    cur_time = 0
    min_end_time = 0

    def remove_until_next(time):
        while busy and busy[0][0] <= time:
            _, room_index = heapq.heappop(busy)
            heapq.heappush(free, room_index)

    for start, end in meetings:
        cur_time = max(cur_time, start)

        # 若无空闲会议室，推进到最近的结束时间
        if not free:
            min_end_time = busy[0][0] if busy else 0
            cur_time = max(cur_time, min_end_time)

        # 释放已结束的会议室
        remove_until_next(cur_time)

        # 分配会议室
        room_index = heapq.heappop(free)
        res[room_index] += 1
        duration = end - start
        heapq.heappush(busy, (cur_time + duration, room_index))

    ans = 0
    for i in range(1, n):
        if res[i] > res[ans]:
            ans = i
    return ans


# [1351] 统计有序矩阵中的负数
def countNegatives(self, grid: List[List[int]]) -> int:
    m = len(grid)
    n = len(grid[0])
    ans = 0
    j = 0
    for i in range(m - 1, -1, -1):
        while j < n:
            if grid[i][j] < 0:
                ans += n - j
                break
            j += 1
    return ans


# [840] 矩阵中的幻方
def numMagicSquaresInside(self, grid: List[List[int]]) -> int:
    def isMagicSquare(self, grid: List[List[int]], x: int, y: int) -> bool:
        target = 15
        seen = set()
        for i in range(3):
            for j in range(3):
                val = grid[x + i][y + j];
                if val < 1 or val > 9 or val in seen:
                    return False
                seen.add(val)
        for i in range(3):
            rowSum = 0
            colSum = 0
            for j in range(3):
                rowSum += grid[x + i][y + j]
                colSum += grid[x + j][y + i]
            if rowSum != target or colSum != target:
                return False
            diag1 = grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2]
            diag2 = grid[x][y + 2] + grid[x + 1][y + 1] + grid[x + 2][y]
            if diag1 != target or diag2 != target:
                return False
        return True

    n = len(grid)
    m = len(grid[0])
    res = 0
    for i in range(n - 2):
        for j in range(m - 2):
            if isMagicSquare(self, grid, i, j):
                res += 1
    return res


# [66] 加一
def plusOne(self, digits: List[int]) -> List[int]:
    n = len(digits)
    if n == 1 and digits[0] == 0:
        digits[0] = 1
        return digits
    t = 1
    for i in range(n - 1, -1, -1):
        digits[i] += t
        t = 0
        if digits[i] == 10:
            digits[i] = 0
            t = 1
        if t == 0:
            break
    if t == 1:
        a = [1]
        a.extend(digits)
        return a
    else:
        return digits


# [961] 在长度 2N 的数组中找出重复 N 次的元素
def repeatedNTimes(self, nums: List[int]) -> int:
    res = 0
    ans = set()
    for n in nums:
        if n in ans:
            res = n
            break
        ans.add(n)
    return res


# [1411] 给 N x 3 网格图涂色的方案数
def numOfWays(self, n: int) -> int:
    # i - row - 0 ~ n-1
    # j - type - 0 ~ 11
    # dp[0][k] = 1
    # 0 - 010 - 4 5 6 8 9
    # 1 - 012 - 4 6 7 9
    # 2 - 020 - 4 5 8 9 10
    # 3 - 021 - 5 8 10 11
    # 4 - 101 - 0 1 2 10 11
    # 5 - 102 - 0 2 3 11
    # 6 - 121 - 0 1 8 10 11
    # 7 - 120 - 1 8 9 10
    # 8 - 202 - 0 2 3 6 7
    # 9 - 201 - 0 1 2 7
    # 10 - 212 - 2 3 4 6 7
    # 11 - 210 - 3 4 5 6
    MOD = 1000000007
    res = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
    line = [0] * 12
    for i in range(1, n):
        line[0] = (res[4] + res[5] + res[6] + res[8] + res[9]) % MOD
        line[1] = (res[4] + res[6] + res[7] + res[9]) % MOD
        line[2] = (res[4] + res[5] + res[8] + res[9] + res[10]) % MOD
        line[3] = (res[5] + res[8] + res[10] + res[11]) % MOD
        line[4] = (res[0] + res[1] + res[2] + res[10] + res[11]) % MOD
        line[5] = (res[0] + res[2] + res[3] + res[11]) % MOD
        line[6] = (res[0] + res[1] + res[8] + res[10] + res[11]) % MOD
        line[7] = (res[1] + res[8] + res[9] + res[10]) % MOD
        line[8] = (res[0] + res[2] + res[3] + res[6] + res[7]) % MOD
        line[9] = (res[0] + res[1] + res[2] + res[7]) % MOD
        line[10] = (res[2] + res[3] + res[4] + res[6] + res[7]) % MOD
        line[11] = (res[3] + res[4] + res[5] + res[6]) % MOD
        res = line
        line = [0] * 12
    ans = 0
    for i in range(12):
        ans = (ans + res[i]) % MOD
    return ans


# [1390] 四因数
def sumFourDivisors(self, nums: List[int]) -> int:
    def AllDivisors(self, n: int) -> List[int]:
        res = set()
        for i in range(1, floor(math.sqrt(n)) + 1):
            if n % i == 0:
                res.add(i)
                res.add(n // i)
        return res

    res = 0
    for n in nums:
        di = AllDivisors(self, n)
        if len(di) == 4:
            for i in di:
                res += i
    return res


# [1975] 最大方阵和
def maxMatrixSum(self, matrix: List[List[int]]) -> int:
    n = len(matrix)
    sumPos = 0
    sumNeg = 0
    maxNeg = -100001
    minPos = 100001
    countPos = 0
    countNeg = 0
    for i in range(n):
        for j in range(n):
            k = matrix[i][j]
            if k >= 0:
                countPos += 1
                sumPos += k
                minPos = min(minPos, k)
            else:
                countNeg += 1
                sumNeg -= k
                maxNeg = max(maxNeg, k)
    if countNeg % 2 == 0:
        return sumPos + sumNeg
    elif countPos == 0:
        return sumPos + sumNeg + 2 * maxNeg
    else:
        return max(sumPos + sumNeg + 2 * maxNeg, sumPos + sumNeg - 2 * minPos)


# [1161] 最大层内元素和
def maxLevelSum(self, root: Optional[TreeNode]) -> int:
    def dfs(self, root: Optional[TreeNode], level: int, sum: List[int]) -> None:
        if root is not None:
            if len(sum) > level:
                sum[level] += root.val
            else:
                sum.append(root.val)
            dfs(self, root.left, level + 1, sum)
            dfs(self, root.right, level + 1, sum)

    max = 0
    sum = []
    dfs(self, root, 0, sum)
    for i in range(len(sum)):
        if sum[i] > sum[max]:
            max = i
    return max + 1


# [1339] 分裂二叉树的最大乘积
def maxProduct(self, root: Optional[TreeNode]) -> int:
    def dfs(self, node: Optional[TreeNode], sums: set()) -> int:
        left = 0
        right = 0
        if node.left is not None:
            left = dfs(self, node.left, sums)
            sums.add(left)
        if node.right is not None:
            right = dfs(self, node.right, sums)
            sums.add(right)
        return node.val + left + right

    MOD = 1000000007
    sums = set()
    total = dfs(self, root, sums)
    mi = total
    res = 0
    for item in sums:
        if abs(total - item - item) < mi:
            res = item
            mi = abs(total - item - item)
    return res * (total - res) % MOD


# [1458] 两个子序列的最大点积
def maxDotProduct(self, nums1: List[int], nums2: List[int]) -> int:
    # i - nums1 index
    # j - nums2 index
    # dp[i][j] = max(dp[i-1][j-1], dp[i-1][j-1] + nums1[i] * nums2[j])
    n1 = len(nums1)
    n2 = len(nums2)
    dp = [[0] * n2 for _ in range(n1)]
    res = -1000000
    for i in range(n1):
        for j in range(n2):
            if i == 0 and j == 0:
                dp[0][0] = max(-1000000, nums1[i] * nums2[j])
                res = max(res, dp[i][j])
            elif i == 0:
                dp[0][j] = max(dp[0][j - 1], nums1[i] * nums2[j])
                res = max(res, dp[i][j])
            elif j == 0:
                dp[i][0] = max(dp[i - 1][0], nums1[i] * nums2[j])
                res = max(res, dp[i][j])
            else:
                dp[i][j] = max(dp[i][j - 1], dp[i - 1][j], dp[i - 1][j - 1])
                dp[i][j] = max(dp[i][j], dp[i - 1][j - 1] + nums1[i] * nums2[j], nums1[i] * nums2[j])
                res = max(res, dp[i][j])
    return res


# [865] 具有所有最深节点的最小子树
def subtreeWithAllDeepest(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
    def dfs(self, node: Optional[TreeNode], depth: int) -> [Optional[TreeNode], int]:
        if node is None:
            return [node, depth]
        left = dfs(self, node.left, depth + 1)
        right = dfs(self, node.right, depth + 1)
        if left[0] is not None and right[0] is not None:
            if left[1] > right[1]:
                return left
            elif left[1] < right[1]:
                return right
            else:
                return [node, left[1]]
        elif left[0] is not None:
            return left
        elif right[0] is not None:
            return right
        else:
            return [node, depth]

    node = dfs(self, root, 0)
    return node[0]


# [1266] 访问所有点的最小时间
def minTimeToVisitAllPoints(self, points: List[List[int]]) -> int:
    n = len(points)
    if n == 1:
        return 0
    res = 0
    x1 = points[0][0]
    y1 = points[0][1]
    for i in range(1, n):
        x = points[i][0]
        y = points[i][1]
        res += max(abs(x - x1), abs(y - y1))
        x1 = x
        y1 = y
    return res


# [2943] 最大化网格图中正方形空洞的面积
def maximizeSquareHoleArea(self, n: int, m: int, hBars: List[int], vBars: List[int]) -> int:
    hBars.sort()
    hMax = 1
    left = 1
    right = 2
    for bar in hBars:
        if bar == right:
            right = bar + 1
        else:
            left = bar - 1
            right = bar + 1
        hMax = max(hMax, right - left)

    vBars.sort()
    vMax = 1
    left = 1
    right = 2
    for bar in vBars:
        if bar == right:
            right = bar + 1
        else:
            left = bar - 1
            right = bar + 1
        vMax = max(vMax, right - left);
    l = min(hMax, vMax)
    return l * l


# [2975] 移除栅栏得到的正方形田地的最大面积
def maximizeSquareArea(self, m: int, n: int, hFences: List[int], vFences: List[int]) -> int:
    MOD = 1000000007
    hFences.sort()
    hLength = set()
    hLength.add(m - 1)
    for i in range(0, len(hFences)):
        hLength.add(hFences[i] - 1)
        hLength.add(m - hFences[i])
        for j in range(i + 1, len(hFences)):
            hLength.add(hFences[j] - hFences[i])

    vFences.sort()
    vLength = set()
    vLength.add(n - 1)
    for i in range(0, len(vFences)):
        vLength.add(vFences[i] - 1)
        vLength.add(n - vFences[i])
        for j in range(i + 1, len(vFences)):
            vLength.add(vFences[j] - vFences[i])

    res = 0
    for length in hLength:
        if length in vLength:
            res = max(res, length)

    if res == 0:
        return -1
    else:
        return res * res % MOD


# [1292] 元素和小于等于阈值的正方形的最大边长
def maxSideLength(self, mat: List[List[int]], threshold: int) -> int:
    def Check(self, mid: int, threshold: int, pre: List[List[int]], m: int, n: int) -> bool:
        for i in range(0, m - mid + 1):
            for j in range(0, n - mid + 1):
                total = 0
                for k in range(0, mid):
                    total += pre[i + k][j + mid] - pre[i + k][j]
                if total <= threshold:
                    return True
        return False

    m = len(mat)
    n = len(mat[0])
    pre = [[0] * (n + 1) for _ in range(m)]
    for i in range(0, m):
        for j in range(0, n):
            pre[i][j + 1] = pre[i][j] + mat[i][j]
    left = 0
    right = min(m, n)
    while left < right:
        mid = left + (right - left + 1) // 2
        if Check(self, mid, threshold, pre, m, n):
            left = mid
        else:
            right = mid - 1
    return left


# [3314] 构造最小位运算数组 I
def minBitwiseArray1(self, nums: List[int]) -> List[int]:
    n = len(nums)
    ans = []
    for i in range(0, n):
        minNum = nums[i] // 2
        ans.append(-1)
        for j in range(minNum, nums[i]):
            if (j | (j + 1)) == nums[i]:
                ans[i] = j
                break
    return ans


# [3315] 构造最小位运算数组 II
def minBitwiseArray(self, nums: List[int]) -> List[int]:
    n = len(nums)
    ans = []
    for i in range(0, n):
        value = nums[i]
        if value == 2:
            ans.append(-1)
        else:
            t = ~value
            low = t & -t
            ans.append(value ^ (low >> 1))
    return ans


# [3507] 移除最小数对使数组有序 I
def minimumPairRemoval(self, nums: List[int]) -> int:
    def GetMin(self, nums: List[int]) -> int:
        res = nums[0] + nums[1]
        index = 0
        for i in range(0, len(nums) - 1):
            if nums[i] + nums[i + 1] < res:
                res = nums[i] + nums[i + 1]
                index = i
        return index

    def Replace(self, nums: List[int], index: int) -> List[int]:
        newNums = []
        for i in range(0, index):
            newNums.append(nums[i])
        newNums.append(nums[index] + nums[index + 1])
        for i in range(index + 2, len(nums)):
            newNums.append(nums[i])
        return newNums

    def Check(self, nums: List[int]) -> bool:
        if len(nums) <= 1:
            return True
        for i in range(0, len(nums) - 1):
            if nums[i] > nums[i + 1]:
                return False
        return True

    times = 0
    while not Check(self, nums):
        index = GetMin(self, nums)
        nums = Replace(self, nums, index)
        times += 1
    return times


# [1877] 数组中最大数对和的最小值
def minPairSum(self, nums: List[int]) -> int:
    nums.sort()
    ans = 0
    for i in range(0, len(nums) // 2):
        ans = max(ans, nums[i] + nums[len(nums) - i - 1])
    return ans


# [1984] 学生分数的最小差值
def minimumDifference(self, nums: List[int], k: int) -> int:
    if k == 1:
        return 0
    nums.sort()
    ans = nums[k - 1] - nums[0]
    for i in range(1, len(nums) - k + 1):
        ans = min(ans, nums[i + k - 1] - nums[i])
    return ans


# [1200] 最小绝对差
def minimumAbsDifference(self, arr: List[int]) -> List[List[int]]:
    ans = []
    minAbs = 1000000
    n = len(arr)
    arr.sort()
    for i in range(0, n - 1):
        currAbs = arr[i + 1] - arr[i]
        if currAbs < minAbs:
            minAbs = currAbs
            ans.clear()
            ans.append([arr[i], arr[i + 1]])
        elif currAbs == minAbs:
            ans.append([arr[i], arr[i + 1]])
    return ans


# [744] 寻找比目标字母大的最小字母
def nextGreatestLetter(self, letters: List[str], target: str) -> str:
    index = 0
    for i in range(0, len(letters)):
        if letters[i] > target:
            index = i
            break
    return letters[index]


# [3010] 将数组分成最小总代价的子数组 I
def minimumCost(self, nums: List[int]) -> int:
    n1 = nums[0]
    nums.pop(0)
    nums.sort()
    return n1 + nums[0] + nums[1];


# [110] 平衡二叉树
def isBalanced(self, root: Optional[TreeNode]) -> bool:
    def getDepth(self, node: Optional[TreeNode]) -> int:
        depth = 0
        if node is None:
            depth = 0
            return depth
        depth = 1
        left = getDepth(self, node.left)
        right = getDepth(self, node.right)
        if left >= 0 and right >= 0:
            depth = max(left, right) + 1
            return depth if abs(left - right) <= 1 else -1
        return -1

    return getDepth(self, root) >= 0


# [799] 香槟塔
def champagneTower(self, poured: int, query_row: int, query_glass: int) -> float:
    def getHalf(self, num: float) -> float:
        if num <= 1:
            return 0
        return (num - 1) / 2

    # dp[i][j] = (dp[i - 1][j - 1] - 1) / 2 + (dp[i - 1][j] - 1) / 2
    dp = []
    for i in range(0, query_row + 1):
        dp.append([])
        if i == 0:
            dp[i].append(poured)
        else:
            dp[i].append(getHalf(self, dp[i - 1][0]))
            for j in range(1, i):
                dp[i].append(getHalf(self, dp[i - 1][j - 1]) + getHalf(self, dp[i - 1][j]))
            dp[i].append(getHalf(self, dp[i - 1][i - 1]))
    return 1 if dp[query_row][query_glass] >= 1 else dp[query_row][query_glass]


# [67] 二进制求和
def addBinary(self, a: str, b: str) -> str:
    def ctoI(self, c: str) -> int:
        if c == '1':
            return 1
        return 0

    def itoC(self, i: int) -> str:
        if i == 1:
            return '1'
        return '0'

    s = ""
    if len(b) > len(a):
        s = a
        a = b
        b = s
    c = [''] * len(a)
    length = len(a) - len(b)
    t = 0
    for i in range(len(b) - 1, -1, -1):
        aa = ctoI(self, a[i + length]) + ctoI(self, b[i]) + t
        if aa > 1:
            t = 1
            aa -= 2
        else:
            t = 0
        c[i + length] = itoC(self, aa)
    for i in range(length - 1, -1, -1):
        aa = ctoI(self, a[i]) + t
        if aa > 1:
            t = 1
            aa -= 2
        else:
            t = 0
        c[i] = itoC(self, aa)
    s = ''.join(c)
    if t == 1:
        s = "1" + s
    return s


# [401] 二进制手表
def readBinaryWatch(self, turnedOn: int) -> List[str]:
    def combineNumber(self, number, digit, last) -> List[int]:
        if last == 0:
            return [number]
        elif digit == last:
            return combineNumber(self, (number << 1) + 1, digit - 1, last - 1)
        elif digit == 0:
            return combineNumber(self, number << 1, digit, last - 1)
        else:
            nums = []
            for num in combineNumber(self, (number << 1) + 1, digit - 1, last - 1):
                nums.append(num)
            for num in combineNumber(self, number << 1, digit, last - 1):
                nums.append(num)
            return nums

    nums = combineNumber(self, 0, turnedOn, 10)
    res = []
    for num in nums:
        minute = num >> 4
        hour = num & 0x0000000f
        if hour < 12 and minute < 60:
            res.append(f"{hour}:{minute:02d}")
    return res


# [693] 交替位二进制数
def hasAlternatingBits(self, n: int) -> bool:
    a = n ^ (n >> 1)
    b = a + 1
    return (a & b) == 0


# [696] 计数二进制子串
def countBinarySubstrings(self, s: str) -> int:
    a = '0'
    count = 0
    old = 0
    res = 0
    for c in s:
        if c == a:
            count += 1
        else:
            res += min(old, count)
            old = count
            a = c
            count = 1
    res += min(old, count)
    return res


# [1404] 将二进制表示减到 1 的步骤数
def numSteps(self, s: str) -> int:
    step = 0
    carry = 0
    for i in range(len(s) - 1, 0, -1):
        step += 1
        if int(s[i]) + carry == 1:
            carry = 1
            step += 1
    return step + carry


# [1680] 连接连续二进制数字
def concatenatedBinary(self, n: int) -> int:
    MOD = 1000000007
    res = 0
    for i in range(1, n + 1):
        t = i
        while t > 0:
            t = t >> 1
            res = (res << 1) % MOD
        res = (res + i) % MOD
    return res


# [1536] 排布二进制网格的最少交换次数
def minSwaps(self, grid: List[List[int]]) -> int:
    n = len(grid)
    aim = [0] * n
    for i in range(0, n):
        count = n - 1
        for j in range(n - 1, -1, -1):
            count = j
            if grid[i][j] == 1:
                break
        aim[i] = count
    ans = 0
    for i in range(0, n):
        j = i
        while j < n and aim[j] > i:
            j += 1
        if j == n:
            return -1
        ans += j - i
        for k in range(j, i - 1, -1):
            aim[k] = aim[k - 1]
    return ans


# [1545] 找出第 N 个二进制字符串中的第 K 位
def findKthBit(self, n: int, k: int) -> str:
    if k % 2 > 0:
        # 奇数
        return str(k // 2 % 2)
    else:
        # 偶数
        k //= k & -k;  # 去掉 k 的尾零
        return str(1 - k // 2 % 2)


# [1582] 二进制矩阵中的特殊位置
def numSpecial(self, mat: List[List[int]]) -> int:
    m = len(mat)
    n = len(mat[0])
    rows = [0] * m
    res = 0
    for i in range(0, m):
        first = -1
        for j in range(0, n):
            if mat[i][j] == 1:
                rows[i] = j
                if first == -1:
                    first = j
        if first == rows[i]:
            a = -1
            b = -1
            for j in range(0, m):
                if mat[j][first] == 1:
                    if a == -1:
                        a = j
                    else:
                        b = j
                        break
            if a != -1 and b == -1:
                res += 1
    return res


# [1758] 生成交替二进制字符串的最少操作数
def minOperations(self, s: str) -> int:
    res = 0
    n = len(s)
    for i, c in enumerate(s):
        if ord(c) - ord('0') != i % 2:
            res += 1
    return min(res, n - res)


# [1784] 检查二进制字符串字段
def checkOnesSegment(self, s: str) -> bool:
    res = False
    hasZero = False
    for c in s:
        if c == '1' and not res:
            res = True
        elif c == '0' and res:
            hasZero = True
        elif c == '1' and hasZero:
            return False
    return res


# [1980] 找出不同的二进制字符串
def findDifferentBinaryString(self, nums: List[str]) -> str:
    n = len(nums)
    res = [''] * n
    for i in range(0, n):
        res[i] = '1' if nums[i][i] == '0' else '0'
    return ''.join(res)


# [3296] 移山所需的最少秒数
def minNumberOfSeconds(self, mountainHeight: int, workerTimes: List[int]) -> int:
    worker = len(workerTimes)
    round_count = [0] * worker
    times = [0] * worker
    pq = []

    # init pq
    for i in range(0, worker):
        heapq.heappush(pq, (workerTimes[i], i))

    for _ in range(mountainHeight):
        next_time, key = heapq.heappop(pq)
        round_count[key] += 1
        times[key] = next_time
        heapq.heappush(pq, (times[key] + workerTimes[key] * (round_count[key] + 1), key))

    return max(times)


# [1415] 长度为 n 的开心字符串中字典序第 k 小的字符串
def getHappyString(self, n: int, k: int) -> str:
    chars = ['a', 'b', 'c']
    res = ""
    if k > (3 * (1 << (n - 1))):
        return res
    for i in range(0, n):
        count = 1 << (n - i - 1)
        for c in chars:
            if len(res) > 0 and res[len(res) - 1] == c:
                continue
            if k <= count:
                res = res + c
                break
            k -= count
    return res


# [3070] 元素和小于等于 k 的子矩阵的数目
def countSubmatrices(self, grid: List[List[int]], k: int) -> int:
    m = len(grid)
    n = len(grid[0])
    pre = [0] * n
    res = 0
    for i in range(0, m):
        sum = 0
        for j in range(0, n):
            pre[j] += grid[i][j]
            sum += pre[j]
            if sum <= k:
                res += 1
            else:
                n = j
                break
    return res


# [3212] 统计 X 和 Y 频数相等的子矩阵数量
def numberOfSubmatrices(self, grid: List[List[str]]) -> int:
    m = len(grid)
    n = len(grid[0])
    cntX = [0] * n
    cntY = [0] * n
    res = 0
    for i in range(0, m):
        sumX = 0
        sumY = 0
        for j in range(0, n):
            cntX[j] += 1 if grid[i][j] == 'X' else 0
            cntY[j] += 1 if grid[i][j] == 'Y' else 0
            sumX += cntX[j]
            sumY += cntY[j]
            if sumX == sumY and sumX > 0:
                res += 1
    return res


# [3643] 垂直翻转子矩阵
def reverseSubmatrix(self, grid: List[List[int]], x: int, y: int, k: int) -> List[List[int]]:
    for i in range(x, x + k // 2):
        t = 2 * x + k - i - 1
        for j in range(y, y + k):
            temp = grid[i][j]
            grid[i][j] = grid[t][j]
            grid[t][j] = temp
    return grid


# [1886] 判断矩阵经轮转后是否一致
def findRotation(self, mat: List[List[int]], target: List[List[int]]) -> bool:
    n = len(mat)
    r1 = r2 = r3 = r4 = True
    for i in range(n):
        for j in range(n):
            if r1 and mat[i][j] != target[i][j]:
                r1 = False
            if r2 and mat[i][j] != target[j][n - i - 1]:
                r2 = False
            if r3 and mat[i][j] != target[n - i - 1][n - j - 1]:
                r3 = False
            if r4 and mat[i][j] != target[n - j - 1][i]:
                r4 = False
    return r1 or r2 or r3 or r4


# [1594] 矩阵的最大非负积
def maxProductPath(self, grid: List[List[int]]) -> int:
    MOD = 1000000007
    m = len(grid)
    n = len(grid[0])
    dp = [[[0, 0] for _ in range(n)] for _ in range(m)]
    for i in range(m):
        for j in range(n):
            if i == 0 and j == 0:
                dp[i][j][0] = grid[i][j]
                dp[i][j][1] = grid[i][j]
            elif i == 0:
                maxVal = dp[i][j - 1][0] * grid[i][j]
                minVal = dp[i][j - 1][1] * grid[i][j]
                dp[i][j][0] = max(maxVal, minVal)
                dp[i][j][1] = min(maxVal, minVal)
            elif j == 0:
                maxVal = dp[i - 1][j][0] * grid[i][j]
                minVal = dp[i - 1][j][1] * grid[i][j]
                dp[i][j][0] = max(maxVal, minVal)
                dp[i][j][1] = min(maxVal, minVal)
            elif grid[i][j] > 0:
                maxVal = max(dp[i - 1][j][0], dp[i][j - 1][0]) * grid[i][j]
                minVal = min(dp[i - 1][j][1], dp[i][j - 1][1]) * grid[i][j]
                dp[i][j][0] = max(maxVal, minVal)
                dp[i][j][1] = min(maxVal, minVal)
            elif grid[i][j] < 0:
                maxVal = min(dp[i - 1][j][1], dp[i][j - 1][1]) * grid[i][j]
                minVal = max(dp[i - 1][j][0], dp[i][j - 1][0]) * grid[i][j]
                dp[i][j][0] = max(maxVal, minVal)
                dp[i][j][1] = min(maxVal, minVal)
            else:
                dp[i][j][0] = 0
                dp[i][j][1] = 0
    val = max(dp[m - 1][n - 1][0], dp[m - 1][n - 1][1])
    return -1 if val < 0 else val % MOD


# [2906] 构造乘积矩阵
def constructProductMatrix(self, grid: List[List[int]]) -> List[List[int]]:
    mod = 12345
    n = len(grid)
    m = len(grid[0])
    left = [0] * (n * m + 1)
    right = [0] * (n * m + 1)
    left[0] = 1
    right[-1] = 1
    for i in range(n):
        for j in range(m):
            left[i * m + j + 1] = left[i * m + j] * grid[i][j] % mod

    for i in range(n - 1, -1, -1):
        for j in range(m - 1, -1, -1):
            right[i * m + j] = right[i * m + j + 1] * grid[i][j] % mod

    p = [[0] * m for _ in range(n)]
    for i in range(n):
        for j in range(m):
            p[i][j] = (left[i * m + j] * right[i * m + j + 1]) % mod
    return p


# [3546] 等和矩阵分割 I
def canPartitionGrid(self, grid: List[List[int]]) -> bool:
    m = len(grid)
    n = len(grid[0])
    if m == 1 and n == 1:
        return False
    ver = [0] * m
    hor = [0] * n
    total = 0
    for i in range(m):
        if i > 0:
            ver[i] = ver[i - 1]
        for j in range(n):
            ver[i] += grid[i][j]
            hor[j] += grid[i][j]
            if i == m - 1 and j > 0:
                hor[j] += hor[j - 1]
            total += grid[i][j]
    if total % 2 != 0:
        return False
    half = total // 2
    if half in ver:
        return True
    if half in hor:
        return True
    return False


# [2946] 循环移位后的矩阵相似检查
def areSimilar(self, mat: List[List[int]], k: int) -> bool:
    m = len(mat)
    n = len(mat[0])
    k %= n
    if k == 0:
        return True

    for i in range(m):
        row = mat[i]
        if i & 1 == 0:
            for j in range(n):
                if row[j] != row[(j + k) % n]:
                    return False
        else:
            for j in range(n):
                if row[j] != row[(j - k + n) % n]:
                    return False
    return True


# [2839] 判断通过操作能否让字符串相等 I
def canBeEqual(self, s1: str, s2: str) -> bool:
    even_equal = (s1[0] == s2[0] and s1[2] == s2[2]) or (s1[0] == s2[2] and s1[2] == s2[0])
    odd_equal = (s1[1] == s2[1] and s1[3] == s2[3]) or (s1[1] == s2[3] and s1[3] == s2[1])

    return even_equal and odd_equal


# [2840] 判断通过操作能否让字符串相等 II
def checkStrings(self, s1: str, s2: str) -> bool:
    cnt1 = [[0] * 26 for _ in range(2)]
    cnt2 = [[0] * 26 for _ in range(2)]
    for i, (c1, c2) in enumerate(zip(s1, s2)):
        cnt1[i % 2][ord(c1) - ord('a')] += 1
        cnt2[i % 2][ord(c2) - ord('a')] += 1

    return cnt1 == cnt2


# [2751] 机器人碰撞
def survivedRobotsHealths(self, positions: List[int], healths: List[int], directions: str) -> List[int]:
    n = len(positions)
    order = sorted(range(n), key=positions.__getitem__)

    right_stack: List[int] = []
    for i in order:
        if directions[i] == 'R':
            right_stack.append(i)
            continue

        while right_stack and healths[i] > 0:
            j = right_stack[-1]
            if healths[j] < healths[i]:
                right_stack.pop()
                healths[i] -= 1
                healths[j] = 0
            elif healths[j] > healths[i]:
                healths[j] -= 1
                healths[i] = 0
            else:
                right_stack.pop()
                healths[j] = 0
                healths[i] = 0

    return [h for h in healths if h > 0]


# [3418] 机器人可以获得的最大金币数
def maximumAmount(self, coins: List[List[int]]) -> int:
    m, n = len(coins), len(coins[0])

    def solve(rows: int, cols: int, transposed: bool) -> int:
        neg_inf = -10 ** 30
        dp0 = [neg_inf] * cols
        dp1 = [neg_inf] * cols
        dp2 = [neg_inf] * cols

        for r in range(rows):
            left0 = neg_inf
            left1 = neg_inf
            left2 = neg_inf
            for c in range(cols):
                up0 = dp0[c]
                up1 = dp1[c]
                up2 = dp2[c]

                if r == 0 and c == 0:
                    best0 = 0
                    best1 = 0
                    best2 = 0
                else:
                    best0 = max(up0, left0)
                    best1 = max(up1, left1)
                    best2 = max(up2, left2)

                coin = coins[c][r] if transposed else coins[r][c]
                cur0 = best0 + coin
                cur1 = max(best1 + coin, best0)
                cur2 = max(best2 + coin, best1)

                dp0[c] = cur0
                dp1[c] = cur1
                dp2[c] = cur2

                left0 = cur0
                left1 = cur1
                left2 = cur2

        return max(dp0[-1], dp1[-1], dp2[-1])

    if n <= m:
        return solve(m, n, False)
    return solve(n, m, True)


# [3661] 可以被机器人摧毁的最大墙壁数目
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


# [2087] 网格图中机器人回家的最小代价
def minCost(self, startPos: List[int], homePos: List[int], rowCosts: List[int], colCosts: List[int]) -> int:
    sr, sc = startPos
    hr, hc = homePos
    cost = 0
    if sr < hr:
        for i in range(sr + 1, hr + 1):
            cost += rowCosts[i]
    else:
        for i in range(sr - 1, hr - 1, -1):
            cost += rowCosts[i]
    if sc < hc:
        for j in range(sc + 1, hc + 1):
            cost += colCosts[j]
    else:
        for j in range(sc - 1, hc - 1, -1):
            cost += colCosts[j]
    return cost
