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
    res = { "electronics": [], "grocery": [], "pharmacy": [], "restaurant": [] }
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
        return 0;
    index = 0
    res = 1
    for i in range(1, len(lst) - 1):
        if index == 0:
            index = lst[i]
        else:
            res = res * (lst[i] - index) % MOD
            index = 0
    return res