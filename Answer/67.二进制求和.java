/*
 * @lc app=leetcode.cn id=67 lang=java
 *
 * [67] 二进制求和
 */

// @lc code=start
class Solution {
    public String addBinary(String a, String b) {
        String s;
        if (b.length() > a.length()) {
            s = a;
            a = b;
            b = s;
        }
        var c = new char[a.length()];
        var len = a.length() - b.length();
        var t = 0;
        for (int i = b.length() - 1; i >= 0; i--) {
            var aa = CtoI(a.charAt(i + len)) + CtoI(b.charAt(i)) + t;
            if (aa > 1) {
                t = 1;
                aa -= 2;
            } else {
                t = 0;
            }
            c[i + len] = ItoC(aa);
        }
        for (int i = len - 1; i >= 0; i--) {
            var aa = CtoI(a.charAt(i)) + t;
            if (aa > 1) {
                t = 1;
                aa -= 2;
            } else {
                t = 0;
            }
            c[i] = ItoC(aa);
        }
        s = new String(c);
        if (t == 1) {
            s = "1" + s;
        }
        return s;
    }

    private int CtoI(char c) {
        if (c == '1')
            return 1;
        return 0;
    }

    private char ItoC(int i) {
        if (i == 1)
            return '1';
        return '0';
    }

}
// @lc code=end
