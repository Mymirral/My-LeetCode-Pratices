// 25K 个一组翻转链表.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <stack>

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
	ListNode* reverseKGroup(ListNode* head, int k) {

		if (k == 1) return head;

		stack<ListNode*> stack;
		ListNode* cur = head;

		ListNode* newhead = NULL;

		for (int i = 0; i < k; i++)
		{
			if (!cur) break;	//如果已经空了,跳出for循环
			stack.push(cur);	//入栈
			cur = cur->next;	//切换到下一个节点
		}

		if (stack.size() < k) return head;	//如果栈里不满足一组，直接返回头节点
		newhead = stack.top();

		for (int i = 0; i < k; i++)	//同样
		{
			ListNode* top = stack.top();	//当前栈顶拿出来
			stack.pop();

			if (stack.empty())	//如果栈顶拿完是空的
			{
				top->next = reverseKGroup(cur, k);
			}
			else
			top->next = stack.top();		//栈顶的下一个节点反转
		}
		return newhead;
	}
};

int main()
{
	ListNode* a = new ListNode(5);
	ListNode* b = new ListNode(4, a);
	ListNode* c = new ListNode(3, b);
	ListNode* d = new ListNode(2, c);
	ListNode* e = new ListNode(1, d);

	Solution s;
	cout << s.reverseKGroup(e,2);
}