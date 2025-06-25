// 160相交链表.cpp 


#include <iostream>
#include<unordered_set>
using namespace std;


 struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(NULL) {}
    
};

class Solution {
public:
    ListNode* getIntersectionNode(ListNode* headA, ListNode* headB) {

        unordered_set<ListNode*> dict;
        
        while (headA != NULL)
        {
            dict.insert(headA);
            headA = headA->next;
        }

        int index = 0;
        while (headB != NULL)
        {
            int exsist = dict.count(headB);
            if (exsist)return headB;
            headB = headB->next;
        }

        return NULL;
    }
};

int main()
{
}

