import heapq
import math
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
    n = len(grid)
    m = len(grid[0])
    res = 0
    for i in range(n - 2):
        for j in range(m - 2):
            if isMagicSquare(self, grid, i, j):
                res += 1
    return res


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
    res = 0
    for n in nums:
        di = AllDivisors(self, n)
        if len(di) == 4:
            for i in di:
                res += i
    return res


def AllDivisors(self, n: int) -> List[int]:
    res = set()
    for i in range(1, floor(math.sqrt(n)) + 1):
        if n % i == 0:
            res.add(i)
            res.add(n // i)
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
    max = 0
    sum = []
    dfs(self, root, 0, sum)
    for i in range(len(sum)):
        if sum[i] > sum[max]:
            max = i
    return max + 1


def dfs(self, root: Optional[TreeNode], level: int, sum: List[int]) -> None:
    if root is not None:
        if len(sum) > level:
            sum[level] += root.val
        else:
            sum.append(root.val)
        dfs(self, root.left, level + 1, sum)
        dfs(self, root.right, level + 1, sum)


# [1339] 分裂二叉树的最大乘积
def maxProduct(self, root: Optional[TreeNode]) -> int:
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
    node = dfs(self, root, 0)
    return node[0]


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
