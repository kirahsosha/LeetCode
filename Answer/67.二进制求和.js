/*
 * @lc app=leetcode.cn id=67 lang=javascript
 *
 * [67] 二进制求和
 */

// @lc code=start
/**
 * @param {string} a
 * @param {string} b
 * @return {string}
 */
var addBinary = function (a, b) {
    /**
     * @param {char} c
     * @return {number}
     */
    function CtoI(c) {
        if (c == '1') return 1;
        return 0;
    }

    /**
     * @param {number} i
     * @return {char}
     */
    function ItoC(i) {
        if (i == 1) return '1';
        return '0';
    }

    let s = "";
    if (b.length > a.length) {
        s = a;
        a = b;
        b = s;
    }
    let c = [a.length];
    let len = a.length - b.length;
    let t = 0;
    for (let i = b.length - 1; i >= 0; i--) {
        let aa = CtoI(a.charAt(i + len)) + CtoI(b.charAt(i)) + t;
        if (aa > 1) {
            t = 1;
            aa -= 2;
        } else {
            t = 0;
        }
        c[i + len] = ItoC(aa);
    }
    for (let i = len - 1; i >= 0; i--) {
        let aa = CtoI(a.charAt(i)) + t;
        if (aa > 1) {
            t = 1;
            aa -= 2;
        } else {
            t = 0;
        }
        c[i] = ItoC(aa);
    }
    s = c.toString().replace(/,/g, "");
    if (t == 1) {
        s = "1" + s;
    }
    return s;
};
// @lc code=end

