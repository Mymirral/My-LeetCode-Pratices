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
    ListNode* reverseList(ListNode* head) {


        ListNode* reListHead = NULL;   //新链表的头
        

        while (head != NULL)
        {
            ListNode* newNode = new ListNode(head->val);;   //新节点
            newNode->val = head->val;    //新节点的值等于原链表的对应位置的值
            newNode->next = reListHead;  //新节点下一个节点是上个列表的头节点
            reListHead = newNode;      //新链表的入口变为新节点
            head = head->next;
        }

        return  reListHead;
    }
};