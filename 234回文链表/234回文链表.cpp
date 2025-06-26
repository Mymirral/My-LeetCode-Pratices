
using namespace std;
#include <iostream>;
#include <vector>;

  struct ListNode {
      int val;
      ListNode *next;
      ListNode() : val(0), next(nullptr) {}
      ListNode(int x) : val(x), next(nullptr) {}
     ListNode(int x, ListNode *next) : val(x), next(next) {}
  };
 



class Solution {
public:
    bool isPalindrome(ListNode* head) {
        vector<int> list;
        while (head != nullptr)
        {
            list.push_back(head->val);
            head = head->next;
        }

        if (list.size() == 1) return true;

        int left = 0;
        int right = list.size()-1;

        while (left < right)
        {
            if (list[left] != list[right] )return false;
            left++;
            right--;
        }

        return true;
    }
};