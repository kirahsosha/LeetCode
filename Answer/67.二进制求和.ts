/*
 * @lc app=leetcode.cn id=67 lang=typescript
 *
 * [67] 二进制求和
 */

// @lc code=start
function addBinary(a: string, b: string): string {
    function CtoI(c: string): number {
        if (c == '1') return 1;
        return 0;
    }

    function ItoC(i: number): string {
        if (i == 1) return '1';
        return '0';
    }

    let s = "";
    if (b.length > a.length) {
        s = a;
        a = b;
        b = s;
    }
    let c = [];
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

