import Solution
from Model import TreeNode


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
    meetings = [[38, 44], [17, 38], [6, 29], [34, 40], [7, 14], [4, 27]]
    res = Solution.mostBooked(self, 4, meetings)
    print(f', {res}')


def Test_1351(self=None):
    grid = [[4, 3, 2, -1], [3, 2, 1, -1], [1, 1, -1, -2], [-1, -1, -2, -3]]
    res = Solution.countNegatives(self, grid)
    print(f', {res}')


def Test_840(self=None):
    grid = [[4, 3, 8, 4], [9, 5, 1, 9], [2, 7, 6, 2]]
    res = Solution.numMagicSquaresInside(self, grid)
    print(f', {res}')


def Test_66(self=None):
    digits = [9, 9, 9, 9]
    res = Solution.plusOne(self, digits)
    print(f', {res}')


def Test_961(self=None):
    nums = [5, 1, 5, 2, 5, 3, 5, 4]
    res = Solution.repeatedNTimes(self, nums)
    print(f', {res}')


def Test_1411(self=None):
    res = Solution.numOfWays(self, 3)
    print(f', {res}')


def Test_1390(self=None):
    nums = [21, 4, 7]
    res = Solution.sumFourDivisors(self, nums)
    print(f', {res}')


def Test_1975(self=None):
    matrix = [[1, 2, 3], [-1, -2, -3], [1, 2, 3]]
    res = Solution.maxMatrixSum(self, matrix)
    print(f', {res}')


def Test_1161(self=None):
    root = TreeNode.create_tree_node("[989,null,10250,98693,-89388,null,null,null,-32127]")
    res = Solution.maxLevelSum(self, root)
    print(f', {res}')


def Test_1339(self=None):
    root = TreeNode.create_tree_node("[2,3,9,10,7,8,6,5,4,11,1]")
    res = Solution.maxProduct(self, root)
    print(f', {res}')


def Test_1458(self=None):
    nums1 = [-3, -8, 3, -10, 1, 3, 9]
    nums2 = [9, 2, 3, 7, -9, 1, -8, 5, -1, -1]
    res = Solution.maxDotProduct(self, nums1, nums2)
    print(f', {res}')


def Test_865(self=None):
    root = TreeNode.create_tree_node("[3,5,1,6,2,0,8,null,null,7,4]")
    res = Solution.subtreeWithAllDeepest(self, root)
    print(f', {res}')


def Test_1266(self=None):
    points = [[1, 1], [3, 4], [-1, 0]]
    res = Solution.minTimeToVisitAllPoints(self, points)
    print(f', {res}')


def Test_2943(self=None):
    n = 14
    m = 4
    hBars = [13]
    vBars = [3, 4, 5, 2]
    res = Solution.maximizeSquareHoleArea(self, n, m, hBars, vBars)
    print(f', {res}')


def Test_2975(self=None):
    n = 4
    m = 5
    hFences = [2]
    vFences = [4]
    res = Solution.maximizeSquareArea(self, n, m, hFences, vFences)
    print(f', {res}')


def Test_1292(self=None):
    mat = [[1, 1, 1, 1], [1, 0, 0, 0], [1, 0, 0, 0], [1, 0, 0, 0]]
    threshold = 6
    res = Solution.maxSideLength(self, mat, threshold)
    print(f', {res}')


def Test_3314(self=None):
    nums = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97]
    res = Solution.minBitwiseArray1(self, nums)
    print(f', {res}')


def Test_3315(self=None):
    nums = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97]
    res = Solution.minBitwiseArray(self, nums)
    print(f', {res}')


def Test_3507(self=None):
    nums = [5, 2, 3, 1]
    res = Solution.minimumPairRemoval(self, nums)
    print(f', {res}')


def Test_1877(self=None):
    nums = [3, 5, 4, 2, 4, 6]
    res = Solution.minPairSum(self, nums)
    print(f', {res}')


def Test_1984(self=None):
    nums = [9, 4, 1, 7]
    k = 2
    res = Solution.minimumDifference(self, nums, k)
    print(f', {res}')


def Test_1200(self=None):
    nums = [3, 8, -10, 23, 19, -4, -14, 27]
    res = Solution.minimumAbsDifference(self, nums)
    print(f', {res}')


def Test_744(self=None):
    letters = "['c', 'f', 'j']"
    target = 'a'
    res = Solution.nextGreatestLetter(self, letters, target)
    print(f', {res}')


def Test_3010(self=None):
    nums = [10, 3, 1, 1]
    res = Solution.minimumCost(self, nums)
    print(f', {res}')


def Test_110(self=None):
    root = TreeNode.create_tree_node("[3,9,20,null,null,15,7]")
    res = Solution.isBalanced(self, root)
    print(f', {res}')


def Test_799(self=None):
    poured = 999999999
    query_row = 99
    query_glass = 99
    res = Solution.champagneTower(self, poured, query_row, query_glass)
    print(f', {res}')


def Test_67(self=None):
    res = Solution.addBinary(self, "1010", "1011")
    print(f', {res}')


def Test_401(self=None):
    res = Solution.readBinaryWatch(self, 2)
    print(f', {res}')


def Test_693(self=None):
    res = Solution.hasAlternatingBits(self, 5)
    print(f', {res}')


def Test_696(self=None):
    res = Solution.countBinarySubstrings(self, "00110011")
    print(f', {res}')


def Test_1404(self=None):
    res = Solution.numSteps(self, "100110110")
    print(f', {res}')


def Test_1680(self=None):
    res = Solution.concatenatedBinary(self, 12)
    print(f', {res}')


def Test_1536(self=None):
    res = Solution.minSwaps(self, [[0, 0, 1], [1, 1, 0], [1, 0, 0]])
    print(f', {res}')


def Test_1545(self=None):
    n = 4
    k = 11
    res = Solution.findKthBit(self, n, k)
    print(f', {res}')


def Test_1582(self=None):
    res = Solution.numSpecial(self, [[0, 0, 1], [1, 1, 0], [1, 0, 0]])
    print(f', {res}')


def Test_1758(self=None):
    res = Solution.minOperations(self, "010101101010")
    print(f', {res}')


def Test_1784(self=None):
    res = Solution.checkOnesSegment(self, "10101101010")
    print(f', {res}')


def Test_1980(self=None):
    res = Solution.findDifferentBinaryString(self, ["111", "011", "001"])
    print(f', {res}')


def Test_3296(self=None):
    res = Solution.minNumberOfSeconds(self, 100000, [10, 9, 8, 7, 6, 5, 4, 3, 2, 1])
    print(f', {res}')


def Test_1415(self=None):
    res = Solution.getHappyString(self, 3, 9)
    print(f', {res}')


def Test_3070(self=None):
    grid = [[7, 2, 9], [1, 5, 0], [2, 6, 6]]
    res = Solution.countSubmatrices(self, grid, 20)
    print(f', {res}')


def Test_3212(self=None):
    grid = [["X", "Y", "."], ["Y", ".", "."]]
    res = Solution.numberOfSubmatrices(self, grid)
    print(f', {res}')


def Test_3643(self=None):
    grid = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12], [13, 14, 15, 16]]
    res = Solution.reverseSubmatrix(self, grid, 1, 0, 3)
    print(f', {res}')


def Test_1886(self=None):
    met = [[0, 0, 0], [0, 1, 0], [1, 1, 1]]
    target = [[1, 1, 1], [0, 1, 0], [0, 0, 0]]
    res = Solution.findRotation(self, met, target)
    print(f', {res}')


def Test_1594(self=None):
    grid = [[-1, -2, -3], [-2, -3, -3], [-3, -3, -2]]
    res = Solution.maxProductPath(self, grid)
    print(f', {res}')


def Test_2906(self=None):
    grid = [[1, 2], [3, 4]]
    res = Solution.constructProductMatrix(self, grid)
    print(f', {res}')


def Test_3546(self=None):
    grid = [[1, 4], [2, 3]]
    res = Solution.canPartitionGrid(self, grid)
    print(f', {res}')


def Test_2946(self=None):
    grid = [[1, 2, 1, 2], [5, 5, 5, 5], [6, 3, 6, 3]]
    res = Solution.areSimilar(self, grid, 2)
    print(f', {res}')
