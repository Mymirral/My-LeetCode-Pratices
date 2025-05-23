//Definition for singly - linked list.
using System.Net.Http.Headers;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        //新建链表
        ListNode head = new ListNode(0, null);  //头节点
        ListNode current = head;
        ListNode NextOne = null;

        //然后是很多的判断

        //首先是长度问题
        //Ⅰ、两个链表一样长
        //Ⅱ、链表一长一短

        //其次是结尾的问题
        //进一
        //不进一
        int n = 0;  //用于判断是否进一

        while (l1 != null && l2 != null)
        {

            int val = l1.val + l2.val + n;
            n = val/10;
            val = val % 10;


            l1 = l1.next;                   //下一个值
            l2 = l2.next;

            //让节点变成下一个
            NextOne = new ListNode(val, null);
            current.next = NextOne;
            current = current.next;
        }

        //看看是l1还是l2空了
        if (l2 != null)         //l1空了               
        {
            while (l2 != null)
            {
                int val = l2.val + n;
                n = val / 10;
                val = val % 10;

                l2 = l2.next;

                NextOne = new ListNode(val, null);
                current.next = NextOne;
                current = current.next;
            }

        }
        else if (l1 != null)         //l2空了               
        {
            while (l1 != null)
            {
                int val = l1.val + n;
                n = val / 10;
                val = val % 10;

                l1 = l1.next;

                NextOne = new ListNode(val, null);
                current.next = NextOne;
                current = current.next;
            }

        }

        if (n == 1)
        {
            current.next = new ListNode(1, null);
        }

        return head.next;

    }
}
//总结，很难，我觉得很难，难在我不会链表，这道题做的我都要哭了，
//花了3个小时，结果还是看的别人的题目才知道，而且还改改改
//为什么呢
//1.不熟悉链表
//2.不熟悉链表
//3.不熟悉链表

//对链表的理解很限制我的做题
//他妈的，哥们不甘心啊，但是那种在巨大的困难面前束手无策的感觉真的令人绝望