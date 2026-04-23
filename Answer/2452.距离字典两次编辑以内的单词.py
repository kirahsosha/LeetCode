#
# @lc app=leetcode.cn id=2452 lang=python3
#
# [2452] 距离字典两次编辑以内的单词
#

# @lc code=start
from typing import List


class Solution:
    def twoEditWords(self, queries: List[str], dictionary: List[str]) -> List[str]:
        ans = []
        for query in queries:
            for word in dictionary:
                if sum(c1 != c2 for c1, c2 in zip(query, word)) <= 2:
                    ans.append(query)
                    break
        return ans
# @lc code=end

