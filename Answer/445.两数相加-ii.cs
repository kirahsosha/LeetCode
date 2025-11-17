/*
 * @lc app=leetcode.cn id=445 lang=csharp
 *
 * [445] 两数相加 II
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        Stack<ListNode> s1 = new Stack<ListNode>();
        Stack<ListNode> s2 = new Stack<ListNode>();
        int count1 = 0, count2 = 0;
        //将两个链表入栈
        for(ListNode node = l1; node != null; node = node.next)
        {
            s1.Push(node);
            count1++;
        }
        for(ListNode node = l2; node != null; node = node.next)
        {
            s2.Push(node);
            count2++;
        }
        //用于计算的lamda表达式
        Func<Stack<ListNode>, Stack<ListNode>, ListNode> func
            =new Func<Stack<ListNode>, Stack<ListNode>, ListNode>
            (
                (s1,s2)=>
                {
                    ListNode resNode = null;
                    if(count1<count2)
                    {
                        var tmp = s1;
                        s1 = s2;
                        s2 = tmp;
                    }
                    bool isOverflow = false;
                    while(s1.Count() != 0)
                    {
                        ListNode n1 = s1.Pop();
                        ListNode n2 = null;
                        if(s2.Count() != 0)
                        {
                            n2 = s2.Pop();
                            n1.val += n2.val;
                        }
                        //判断进位
                        if(isOverflow)
                            {
                                n1.val++;
                                isOverflow = false;
                            }
                            if(n1.val >= 10)
                            {
                                n1.val -= 10;
                                isOverflow = true;
                            }
                        n1.next = resNode;
                        resNode = n1;
                    }
                    if(isOverflow)
                    {
                        var node = new ListNode(1);
                        node.next = resNode;
                        resNode = node;
                        isOverflow = false;
                    }
                    return resNode;
                }
            );
        return func.Invoke(s1, s2);
    }
}
// @lc code=end

