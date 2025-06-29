
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
		return sortList(head, NULL);
	}

	ListNode* sortList(ListNode* head, ListNode* tail) {

		if (!head) return head;
		if (!head->next)
		{
			head->next = NULL;
			return head;
		}

		ListNode* fast = head;
		ListNode* slow = head;

		//这个条件可能重叠，比如只有两个数的时候
		//while (fast && fast->next)
		while(fast!= tail&& fast->next!= tail)
		{
			slow = slow->next;
			fast = fast->next->next;
		}

		ListNode* righthead = slow->next;
		ListNode* lefttail = slow;
		
		slow->next = NULL;
		
		return mergeList(sortList(head, lefttail), sortList(righthead, tail));
	}

	ListNode* mergeList(ListNode* list1, ListNode* list2) {
		ListNode dummy(0);
		ListNode* p = &dummy;

		while (list1 && list2) {
			if (list1->val < list2->val) {
				p->next = list1;
				list1 = list1->next;
			}
			else {
				p->next = list2;
				list2 = list2->next;
			}
			p = p->next;
		}
		p->next = list1 ? list1 : list2;
		return dummy.next;
	}
};