#
# @lc app=leetcode.cn id=3606 lang=python3
#
# [3606] 优惠券校验器
#

# @lc code=start
class Solution:
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
        
# @lc code=end

