#include <string>
#include <stack>
#include <vector>
using namespace std;

class Solution {
public:
    int longestValidParentheses(string s) {
        if (s.size() <= 1) return 0;

        stack<int> stack;

        vector<bool> record(s.size(),false);

        int max = 0;

        for (int i = 0; i < s.size(); i++)
        {
            if(s[i] == '(') stack.push(i);
            else
            {
                if (stack.empty()) continue;
                else
                {
                    record[i] = true;
                    record[stack.top()] = true;
                    stack.pop();
                }
            }
        }

        int nums = 0;

        for (int i = 0; i < record.size(); i++)
        {
            if (record[i]) {
                nums++;
                max = std::max(nums, max);
            }
            else
            {
                nums = 0;
            }
        }

        return max;
    }
};

int main()
{
    Solution s;
    s.longestValidParentheses(")(()(()(((())(((((()()))((((()()(()()())())())()))()()()())(())()()(((()))))()((()))(((())()((()()())((())))(())))())((()())()()((()((())))))((()(((((()((()))(()()(())))((()))()))())");
}