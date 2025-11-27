/*
 * @lc app=leetcode.cn id=3381 lang=golang
 *
 * [3381] 长度可被 K 整除的子数组的最大元素和
 */

// @lc code=start
func maxSubarraySum(nums []int, k int) int64 {
    n := len(nums)
    pre := make([]int64, k)
    sum := int64(0)
    res := int64(-200000000000000)
    pre[0] = 0
	for i := 1; i < k; i++ {
		pre[i] = 200000000000000
	}
	for i := 0; i < n; i++ {
		sum += int64(nums[i])
		res = max(res, sum - pre[(i + 1) % k])
		pre[(i + 1) % k] = min(pre[(i + 1) % k], sum)
	}
	return res
}
// @lc code=end

