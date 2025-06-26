
using namespace std;
#include <iostream>
#include <unordered_map>
#include <vector>

struct ListNode {
	int val;
	ListNode* next;
	ListNode(int x) : val(x), next(NULL) {}
};


class Solution {
public:
	ListNode* detectCycle(ListNode* head) {
		unordered_map<ListNode*,bool> map;
		
		while (head)
		{
			map[head] = true;
			if (map[head->next]) return head->next;
			head = head->next;
		}

		return NULL;
	}
};