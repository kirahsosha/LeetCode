/*
 * @lc app=leetcode.cn id=23 lang=csharp
 *
 * [23] 合并K个排序链表
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
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists.Length == 0) return null;
        if(lists.Length == 1) return lists[0];
        //结果链表起始节点
        ListNode ans = null;
        //结果链表最后节点
        ListNode last = null;
        //记录每一轮比较时当前已空的链表数
        int p = 0;
        //记录每一轮比较时最小值所在链表下标
        int t = -1;
        while(p < lists.Length)
        {
            p = 0;
            t = -1;
            //找到当前所有链表起始节点中的最小值
            for(int i = 0; i < lists.Length;i++)
            {
                if(lists[i] == null) p++;
                else if(t == -1) t = i;
                else if(lists[i].val < lists[t].val) t = i;
            }
            if(p >= lists.Length) break;
            //将当前最小值取下，放到结果链表中
            if(ans == null)
            {
                ans = lists[t];
                lists[t] = lists[t].next;
                ans.next = null;
                last = ans;
            }
            else
            {
                last.next = lists[t];
                lists[t] = lists[t].next;
                last = last.next;
                last.next = null;
            }
        }
        return ans;
    }
}
// @lc code=end

