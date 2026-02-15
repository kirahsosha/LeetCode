/*
 * @lc app=leetcode.cn id=67 lang=golang
 *
 * [67] 二进制求和
 */
import (
	"fmt"
)
// @lc code=start
func addBinary(a string, b string) string {
    if len(b) > len(a) {
		a, b = b, a
	}
    lenA := len(a)
	lenB := len(b)
	diff := lenA - lenB
	
	result := make([]byte, lenA)
	carry := 0
	
	for i := lenB - 1; i >= 0; i-- {
		bitA := 0
		if a[i+diff] == '1' {
			bitA = 1
		}
		
		bitB := 0
		if b[i] == '1' {
			bitB = 1
		}
		
		sum := bitA + bitB + carry
		if sum > 1 {
			carry = 1
			sum -= 2
		} else {
			carry = 0
		}
		
		if sum == 1 {
			result[i+diff] = '1'
		} else {
			result[i+diff] = '0'
		}
	}
	
	for i := diff - 1; i >= 0; i-- {
		bitA := 0
		if a[i] == '1' {
			bitA = 1
		}
		
		sum := bitA + carry
		if sum > 1 {
			carry = 1
			sum -= 2
		} else {
			carry = 0
		}
		
		if sum == 1 {
			result[i] = '1'
		} else {
			result[i] = '0'
		}
	}
	
	resultStr := string(result)
	if carry == 1 {
		resultStr = "1" + resultStr
	}
	
	return resultStr
}
// @lc code=end

