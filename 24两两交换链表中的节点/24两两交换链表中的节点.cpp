// 24两两交换链表中的节点.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
using namespace std;


struct ListNode {
	int val;
	ListNode* next;
	ListNode() : val(0), next(nullptr) {}
	ListNode(int x) : val(x), next(nullptr) {}
	ListNode(int x, ListNode* next) : val(x), next(next) {}
};

class Solution {
public:
	ListNode* swapPairs(ListNode* head) {

		if (!head || !head->next)
		{
			return head;
		}

		ListNode* starthead = head->next;


		ListNode* nx = head->next->next;		//记录尾巴节点

		head->next->next = head;

		//要先改变下一对！
		nx = swapPairs(nx);
		head->next = nx;
		head = head->next;


		return starthead;
	}
};

int main()
{
	ListNode* q = new ListNode(4);
	ListNode* x = new ListNode(3, q);
	ListNode* y = new ListNode(2, x);
	ListNode* z = new ListNode(1, y);

	Solution s;
	cout << s.swapPairs(z);
}