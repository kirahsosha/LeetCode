/*
 * @lc app=leetcode.cn id=3043 lang=java
 *
 * [3043] 最长公共前缀的长度
 */

// @lc code=start
import java.util.HashSet;
import java.util.Set;

class Solution {

    public int longestCommonPrefix(int[] arr1, int[] arr2) {
        Set<Integer> prefixSet = new HashSet<>();

        for (int num : arr1) {
            for (int n = num; n > 0; n /= 10) {
                prefixSet.add(n);
            }
        }

        int maxLen = 0;
        for (int num : arr2) {
            int length = 0;
            for (int temp = num; temp > 0; temp /= 10) {
                length++;
            }

            for (int n = num; n > 0; n /= 10) {
                if (prefixSet.contains(n)) {
                    if (length > maxLen) {
                        maxLen = length;
                    }
                    break;
                }
                length--;
            }
        }

        return maxLen;
    }
}
// @lc code=end
