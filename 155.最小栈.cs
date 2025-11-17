/*
 * @lc app=leetcode.cn id=155 lang=csharp
 *
 * [155] 最小栈
 */

// @lc code=start
public class MinStack {
    Stack<int> m;
    /** initialize your data structure here. */
    public MinStack() {
        m = new Stack<int>();
    }
    
    public void Push(int x) {
        m.Push(x);
    }
    
    public void Pop() {
        m.Pop();
    }
    
    public int Top() {
        return m.FirstOrDefault();
    }
    
    public int GetMin() {
        return m.Min();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
// @lc code=end

