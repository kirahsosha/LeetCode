/*
 * @lc app=leetcode.cn id=1437 lang=golang
 *
 * [1437] 是否所有 1 都至少相隔 k 个元素
 */

// @lc code=start
func kLengthApart(nums []int, k int) bool {
    index := -1
    for i := 0; i < len(nums); i++ {
        if nums[i] == 1 && index == -1 {
                index = 0
            } else if nums[i] == 1 && index < k {
                return false
            } else if nums[i] == 1 {
                index = 0
            } else if index != -1 {
                index++
            }
        }
        return true
}
// @lc code=end

