/*
 * @lc app=leetcode.cn id=3606 lang=javascript
 *
 * [3606] 优惠券校验器
 */

// @lc code=start
/**
 * @param {string[]} code
 * @param {string[]} businessLine
 * @param {boolean[]} isActive
 * @return {string[]}
 */
var validateCoupons = function (code, businessLine, isActive) {
    const res = new Map([
        ["electronics", []],
        ["grocery", []],
        ["pharmacy", []],
        ["restaurant", []]
    ]);

    const n = code.length;
    const regex = /^[a-zA-Z0-9_]+$/;

    for (let i = 0; i < n; i++) {
        if (!isActive[i]) {
            continue;
        }
        if (!res.has(businessLine[i])) {
            continue;
        }
        if (!regex.test(code[i])) {
            continue;
        }
        res.get(businessLine[i]).push(code[i]);
    }

    const ans = [];
    for (const couponList of res.values()) {
        couponList.sort();
        ans.push(...couponList);
    }

    return ans;
};
// @lc code=end

