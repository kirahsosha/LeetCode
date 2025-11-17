/*
 * @lc app=leetcode.cn id=946 lang=csharp
 *
 * [946] 验证栈序列
 */

// @lc code=start
public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        if(pushed.Length != popped.Length) return false;
        if(pushed.Length <= 2) return true;
        Stack<int> s = new Stack<int>();
        int index = 0;
        for(int i = 0; i < pushed.Length; i++)
        {
            if(popped[index] == pushed[i])
            {
                index++;
                while(s.Count() > 0 && s.Peek() == popped[index])
                {
                    s.Pop();
                    index++;
                }
            }
            else
            {
                s.Push(pushed[i]);
            }
        }
        if(s.Count() > 0) return false;
        return true;
    }
}
// @lc code=end

