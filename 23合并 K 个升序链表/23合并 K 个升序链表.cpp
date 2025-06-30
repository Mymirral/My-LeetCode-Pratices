
#include <vector>
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
	ListNode* mergeKLists(vector<ListNode*>& lists) {
		ListNode newlist(0);

		ListNode* newhead = &newlist;
		ListNode* cur = newhead;

		while (cur)
		{
			int minindex = -1;
			ListNode* minNode = NULL;
			for (int i = 0; i < lists.size(); i++)
			{
				if (!lists[i]) continue;
				if (!minNode)
				{
					minindex = i;
					minNode = lists[i];
				}
				else
				{
					if (minNode->val > lists[i]->val)
					{
						minindex = i;
						minNode = lists[i];
					}
				}
			}
			if (!minNode) break;  // 全为空，结束

			lists[minindex] = lists[minindex]->next;
			cur->next = minNode;
			cur = cur->next;
		}
		return newhead->next;
	}
};