
#include <iostream>
#include <unordered_map>
using namespace std;

// Definition for a Node.
class Node {
public:
    int val;
    Node* next;
    Node* random;

    Node(int _val) {
        val = _val;
        next = NULL;
        random = NULL;
    }
};


class Solution {
public:
    Node* copyRandomList(Node* head) {
        
        Node* oldListcur = head;
        unordered_map<Node*,Node*> map; //两个链表节点对应

        Node* newhead = new Node(0);
        Node* newListcur = newhead;

        //不管三七二十一，先复制原来的再说
        while (oldListcur)
        {
            Node* newnode = new Node(oldListcur->val);  //新建一个节点
            newListcur->next = newnode;                 //让新链表下一个节点指向新建节点
            newListcur = newListcur->next;              //新链表到达最新节点


            map[oldListcur] = newListcur;               //记录对应关系
            oldListcur = oldListcur->next;
        }

        newListcur = newhead->next;
        oldListcur = head;

        //再遍历一次，赋值随机
        while (newListcur)
        {
            newListcur->random = map[oldListcur->random];
            newListcur = newListcur->next;
            oldListcur = oldListcur->next;
        }

        return newhead->next;
    }
};