/*
 * @lc app=leetcode.cn id=2161 lang=javascript
 *
 * [2161] 根据给定数字划分数组
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} pivot
 * @return {number[]}
 */
var pivotArray = function (nums, pivot) {
  let n = nums.length;
  let ans = new Array(n);
  let left = 0,
    right = n - 1;
  for (let i = 0; i < n; i++) {
    let num = nums[i];
    if (num < pivot) {
      ans[left++] = num;
    } else if (num > pivot) {
      ans[right--] = num;
    }
  }
  for (let i = left; i <= right; i++) {
    ans[i] = pivot;
  }
  for (let i = right + 1, j = n - 1; i < j; i++, j--) {
    let tmp = ans[i];
    ans[i] = ans[j];
    ans[j] = tmp;
  }
  return ans;
};
// @lc code=end
