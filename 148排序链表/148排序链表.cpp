
#include <iostream>

/**
 * Definition for singly-linked list.*/
struct ListNode {
	int val;
	ListNode* next;
	ListNode() : val(0), next(nullptr) {}
	ListNode(int x) : val(x), next(nullptr) {}
	ListNode(int x, ListNode* next) : val(x), next(next) {}
};

class Solution {
public:
	ListNode* sortList(ListNode* head) {
		
		ListNode* newHead = NULL;

		while (head)
		{
			ListNode* cur = head;	//把头节点拿出来
			head = head->next;		//赋值新的头

			cur->next = NULL;		//新拿出来的节点断舍离

			if (!newHead)	//新链是空的话
			{
				newHead = cur;	//直接添加
				continue;
			}

			ListNode* p = newHead;
			while(p)
			{
				if (cur->val < p->val)
				{
					cur->next = p;
					newHead = cur;
					break;
				}
				p = p->next;
			}
		}
	}
};