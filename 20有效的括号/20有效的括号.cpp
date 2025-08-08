#include <stack>
#include <string>
using namespace std;

class Solution {
public:
    bool isValid(string s) {
        stack<char> A;


        for(auto c : s)
        {
            switch (c)
            {
            case '(': A.push(c); break;
            case '[': A.push(c); break;
            case '{': A.push(c); break;
            case ')': 
                if (A.empty())
                {
                    return false;
                }
                if (A.top() != '(') return false; else A.pop(); break;
            case ']': 
                if (A.empty())
                {
                    return false;
                }
                if (A.top() != '[')return false; else A.pop(); break;
            case '}': 
                if (A.empty())
                {
                    return false;
                }
                if (A.top() != '{')return false; else A.pop(); break;
            default:
                break;
            }
        }

        return A.empty();
    }
};