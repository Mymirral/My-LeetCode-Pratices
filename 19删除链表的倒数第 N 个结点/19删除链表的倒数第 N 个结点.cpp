// 19删除链表的倒数第 N 个结点.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>

struct ListNode {
	int val;
	ListNode* next;
	ListNode() : val(0), next(nullptr) {}
	ListNode(int x) : val(x), next(nullptr) {}
	ListNode(int x, ListNode* next) : val(x), next(next) {}
};

class Solution {
public:
	ListNode* removeNthFromEnd(ListNode* head, int n) {
		int count = 0;
		ListNode* newhead = head;
		ListNode* forcount = head;
		while (forcount)
		{
			count++;
			forcount = forcount->next;
		}

		count -= n;

		if (count == 0)
		{
			return head->next;
		}

		for (int i = 0; i < count - 1; i++)
		{
			head = head->next;
		}

		if(head->next->next)head->next = head->next->next;
		else
		{
			head->next = NULL;
		}

		return newhead;
	}
};