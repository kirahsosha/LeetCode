/*
 * @lc app=leetcode.cn id=148 lang=csharp
 *
 * [148] 排序链表
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
public class Solution
{
    public ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null)
            return head; //already sorted.

        //Divide this list in 2 parts at the half point. 
        //"head" will be truncated at the half point and will be the start of the first half
        //"start2" will be the second half of the list
        ListNode start2 = DivideLinkedList(head);

        //sort both halves recursively
        head = SortList(head);
        start2 = SortList(start2);

        //Merge the two sorted lists by changing the reference pointers to achieve O(1) space
        ListNode root = MergeLinkedListOpt(head, start2);

        return root;
    }

    private ListNode DivideLinkedList(ListNode head)
    {
        //use a fast and slow pointer to find midpoint of link list
        ListNode slow = head;
        ListNode fast = head.next;
        ListNode start2 = null;
        while (fast != null && fast.next != null)
        {
            slow = slow?.next;
            head = head?.next;
            fast = fast.next?.next;
        }

        start2 = slow.next;
        head.next = null;
        return start2;
    }


    private ListNode MergeLinkedListOpt(ListNode start1, ListNode start2)
    {
        //initial new node as root
        ListNode prev = new ListNode(0);
        ListNode head = prev;

        while (start1 != null && start2 != null)
        {
            if (start1.val < start2.val)
            {
                prev.next = start1;
                start1 = start1.next;
            }
            else
            {
                prev.next = start2;
                start2 = start2.next;
            }
            prev = prev.next;
        }

        //if one list is empty and the other has values, attach to the tail of answer
        if (start1 == null && start2 != null)
        {
            prev.next = start2;
        }
        if (start2 == null && start1 != null)
        {
            prev.next = start1;
        }
        return head.next;
    }
}
// @lc code=end

