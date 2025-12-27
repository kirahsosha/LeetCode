import Solution


def Test_198(self=None):
    nums = [2, 7, 9, 3, 1]
    res = Solution.rob(self, nums)
    print(f', {res}')


def Test_3577(self=None):
    nums = [38, 223, 100, 123, 406, 234, 256, 93, 222, 259, 233, 69, 139, 245, 45, 98, 214]
    res = Solution.countPermutations(self, nums)
    print(f', {res}')


def Test_3531(self=None):
    n = 3
    buildings = [[1, 2], [2, 2], [3, 2], [2, 1], [2, 3]]
    res = Solution.countCoveredBuildings(self, n, buildings)
    print(f', {res}')


def Test_3433(self=None):
    numberOfUsers = 2
    events = [["MESSAGE", "10", "id1 id0"], ["OFFLINE", "11", "0"], ["MESSAGE", "71", "HERE"]]
    res = Solution.countMentions(self, numberOfUsers, events)
    print(f', {res}')


def Test_3606(self=None):
    code = ["P", "j", "x", "c", "j", "C", "G"]
    businessLine = ["pharmacy", "electronics", "invalid", "restaurant", "electronics", "pharmacy", "restaurant"]
    isActive = [True, True, False, False, True, False, False]
    res = Solution.validateCoupons(self, code, businessLine, isActive)
    print(f', {res}')


def Test_2147(self=None):
    corridor = "PPPPPPPSPPPSPPPPSPPPSPPPPPSPPPSPPSPPSPPPPPSPSPPPPPSPPSPPPPPSPPSPPSPPPSPPPPSPPPPSPPPPPSPSPPPPSPSPPPSPPPPSPPPPPSPSPPSPPPPSPPSPPSPPSPPPSPPSPSPPSSSS"
    res = Solution.numberOfWays(self, corridor)
    print(f', {res}')


def Test_2110(self=None):
    prices = [3, 2, 1, 4]
    res = Solution.getDescentPeriods(self, prices)
    print(f', {res}')


def Test_3573(self=None):
    prices = [12, 16, 19, 19, 8, 1, 19, 13, 9]
    res = Solution.maximumProfit(self, prices, 3)
    print(f', {res}')


def Test_3652(self=None):
    prices = [4, 2, 8]
    strategy = [-1, 0, 1]
    res = Solution.maxProfit(self, prices, strategy, 2)
    print(f', {res}')


def Test_944(self=None):
    strs = ["cba", "daf", "ghi"]
    res = Solution.minDeletionSize(self, strs)
    print(f', {res}')


def Test_955(self=None):
    strs = ["xga", "xfb", "yfa"]
    res = Solution.minDeletionSize2(self, strs)
    print(f', {res}')


def Test_3074(self=None):
    apple = [1, 8, 3, 3, 5]
    capacity = [3, 9, 5, 1, 9]
    res = Solution.minimumBoxes(self, apple, capacity)
    print(f', {res}')


def Test_3075(self=None):
    happiness = [1, 2, 3]
    res = Solution.maximumHappinessSum(self, happiness, 2)
    print(f', {res}')

def Test_2483(self=None):
    customers = "YYNY"
    res = Solution.bestClosingTime(self, customers)
    print(f', {res}')

def Test_2483(self=None):
    meetings = [[38,44],[17,38],[6,29],[34,40],[7,14],[4,27]]
    res = Solution.mostBooked(self, 4, meetings)
    print(f', {res}')
