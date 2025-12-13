/*
 * @lc app=leetcode.cn id=3606 lang=golang
 *
 * [3606] 优惠券校验器
 */

// @lc code=start
func validateCoupons(code []string, businessLine []string, isActive []bool) []string {
	res := map[string][]string{
		"electronics": []string{},
		"grocery":     []string{},
		"pharmacy":    []string{},
		"restaurant":  []string{},
	}

	regex := regexp.MustCompile(`^[a-zA-Z0-9_]+$`)

	n := len(code)
	for i := 0; i < n; i++ {
		if !isActive[i] {
			continue
		}
		if _, exists := res[businessLine[i]]; !exists {
			continue
		}
		if !regex.MatchString(code[i]) {
			continue
		}
		res[businessLine[i]] = append(res[businessLine[i]], code[i])
	}

	var ans []string
	order := []string{"electronics", "grocery", "pharmacy", "restaurant"}
	for _, category := range order {
		coupons := res[category]
		sort.Strings(coupons)
		ans = append(ans, coupons...)
	}

	return ans
}

// @lc code=end

