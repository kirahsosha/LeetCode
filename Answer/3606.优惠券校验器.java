/*
 * @lc app=leetcode.cn id=3606 lang=java
 *
 * [3606] 优惠券校验器
 */

// @lc code=start

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.regex.Pattern;

class Solution {
    public List<String> validateCoupons(String[] code, String[] businessLine, boolean[] isActive) {
        HashMap<String, List<String>> res = new HashMap<>();
        res.put("electronics", new ArrayList<>());
        res.put("grocery", new ArrayList<>());
        res.put("pharmacy", new ArrayList<>());
        res.put("restaurant", new ArrayList<>());
        
        int n = code.length;
        
        Pattern pattern = Pattern.compile("^[a-zA-Z0-9_]+$");
        
        for (int i = 0; i < n; i++) {
            if (!isActive[i]) {
                continue;
            }
            if (!res.containsKey(businessLine[i])) {
                continue;
            }
            if (!pattern.matcher(code[i]).matches()) {
                continue;
            }
            res.get(businessLine[i]).add(code[i]);
        }
        
        List<String> ans = new ArrayList<>();
        Collections.sort(res.get("electronics"));
        ans.addAll(res.get("electronics"));
        Collections.sort(res.get("grocery"));
        ans.addAll(res.get("grocery"));
        Collections.sort(res.get("pharmacy"));
        ans.addAll(res.get("pharmacy"));
        Collections.sort(res.get("restaurant"));
        ans.addAll(res.get("restaurant"));
        
        return ans;
    }
}
// @lc code=end

