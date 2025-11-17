/*
 * @lc app=leetcode.cn id=23 lang=csharp
 *
 * [23] 合并 K 个升序链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        ListNode result = null;//先取null
        for (int i = 0; i < lists.Length; i++)
        {
            result = MargeTwo(result, lists[i]);
        }
        return result;
    }

    public ListNode MargeTwo(ListNode result, ListNode listNode)
    {
        if (result == null) //左为空，返回右，也是递归结束边界
        {
            return listNode;
        }
        ;
        if (listNode == null) //右为空返回左，2个都为空返回空，也是递归结束边界
        {
            return result;
        }
        if (result.val <= listNode.val) //左链表头结点小于右链表
        {
            result.next = MargeTwo(result.next, listNode); //左结点的下一个为它们剩下比较的结果
            return result;
        }
        else
        {
            listNode.next = MargeTwo(result, listNode.next); //右结点的下一个为它们剩下比较的结果
            return listNode;
        }
    }
}
// @lc code=end

