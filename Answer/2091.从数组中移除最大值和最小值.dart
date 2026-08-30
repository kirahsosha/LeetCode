/*
 * @lc app=leetcode.cn id=2091 lang=dart
 *
 * [2091] 从数组中移除最大值和最小值
 */

// @lc code=start
class Solution {
  int minimumDeletions(List<int> nums) {
    final n = nums.length;
    var minIndex = 0;
    var maxIndex = 0;
    for (var i = 1; i < n; i++) {
      if (nums[i] < nums[minIndex]) {
        minIndex = i;
      }
      if (nums[i] > nums[maxIndex]) {
        maxIndex = i;
      }
    }
    if (minIndex > maxIndex) {
      final temp = minIndex;
      minIndex = maxIndex;
      maxIndex = temp;
    }
    var ans = maxIndex + 1;
    if (n - minIndex < ans) {
      ans = n - minIndex;
    }
    if (minIndex + 1 + n - maxIndex < ans) {
      ans = minIndex + 1 + n - maxIndex;
    }
    return ans;
  }
}
// @lc code=end