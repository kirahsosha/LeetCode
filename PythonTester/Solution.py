from multiprocessing.managers import Array
from re import match
from typing import List
from queue import PriorityQueue


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
        for j in range (1, len(strs)):
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