// 21合并两个有序链表.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。

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
	ListNode* mergeTwoLists(ListNode* list1, ListNode* list2) {

		if (!list1 && !list2) return NULL;
		if (!list1) return list2;
		if (!list2) return list1;

		ListNode* start = list1->val > list2->val ? list2 : list1;

		//cur1 是头节点起点
		//cur2 是另一条
		ListNode* cur1 = start;
		ListNode* cur2 = list1->val > list2->val ? list1 : list2;

		while (cur1 && cur2 && cur1->next)
		{
			if (cur1->next->val <= cur2->val)	//比较起点所在的链的下一个数和另一条的所在节点
			{
				cur1 = cur1->next;		//如果下一个节点比另一条的小，移动到下一个节点
			}
			else
			{
				ListNode* next = cur1->next;	//否则，下一个节点变成了另一条链的当前节点
				cur1->next = cur2;				//另一条链的当前变成原来这条链的下一个节点
				cur2 = next;
			}
		}

		cur1->next = cur2;

		return start;
	}
};

