import Solution


def Test_198(self=None):
    nums = [2,7,9,3,1]
    res = Solution.rob(self, nums)
    print(f', {res}')

def Test_3577(self=None):
    nums = [38, 223, 100, 123, 406, 234, 256, 93, 222, 259, 233, 69, 139, 245, 45, 98, 214]
    res = Solution.countPermutations(self, nums)
    print(f', {res}')

def Test_3531(self=None):
    n = 3
    buildings = [[1,2],[2,2],[3,2],[2,1],[2,3]]
    res = Solution.countCoveredBuildings(self, n, buildings)
    print(f', {res}')

def Test_3433(self=None):
    numberOfUsers = 2
    events = [["MESSAGE","10","id1 id0"],["OFFLINE","11","0"],["MESSAGE","71","HERE"]]
    res = Solution.countMentions(self, numberOfUsers, events)
    print(f', {res}')