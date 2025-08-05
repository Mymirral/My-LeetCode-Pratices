#include <string>
#include <vector>
using namespace std;

class Solution {
public:

    vector<string> res;
    string now = "";
    int left = 0;
    int right = 0;

    vector<string> generateParenthesis(int n) {
        dfs(now, n, 0, 0);

        return res;
    }


    void dfs(string& now, int n, int left,int right)
    {
        if (now.size() == 2 * n)
        {
			res.push_back(now);
			return;
        }

        if (left < n)
        {
            now += "(";
            left++;
            dfs(now, n, left, right);
            left--;
            now.pop_back();
        }

        if (left > right)
        {
            now += ")";
            right++;
            dfs(now, n, left, right + 1);
            right--;
            now.pop_back();
        }
    }
};