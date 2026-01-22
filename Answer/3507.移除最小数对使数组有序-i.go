/*
 * @lc app=leetcode.cn id=3507 lang=golang
 *
 * [3507] 移除最小数对使数组有序 I
 */

// @lc code=start
func minimumPairRemoval(nums []int) int {
	var GetMin = func(nums []int) int {
		res := nums[0] + nums[1]
		index := 0
		for i := 0; i < len(nums)-1; i++ {
			if nums[i]+nums[i+1] < res {
				res = nums[i] + nums[i+1]
				index = i
			}
		}
		return index
	}

	var Replace = func(nums []int, index int) []int {
		newNums := []int{}
		for i := 0; i < index; i++ {
			newNums = append(newNums, nums[i])
		}
		newNums = append(newNums, nums[index]+nums[index+1])
		for i := index + 2; i < len(nums); i++ {
			newNums = append(newNums, nums[i])
		}
		return newNums
	}

	var Check = func(nums []int) bool {
		if len(nums) <= 1 {
			return true
		}
		for i := 0; i < len(nums)-1; i++ {
			if nums[i] > nums[i+1] {
				return false
			}
		}
		return true
	}

	times := 0
	for !Check(nums) {
		index := GetMin(nums)
		nums = Replace(nums, index)
		times++
	}
	return times
}

// @lc code=end
