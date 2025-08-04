#include <string>
#include <vector>
using namespace std;

class Solution {
public:

    vector<vector<string>> res;
    vector<string> path;

    vector<vector<string>> partition(string s) {

    }

    //切，然后遍历子串。 ← 
    //是回文，加入队列，  |
    //对接下来的子串， ---
    void dfs(string& s, vector<bool>& used)
    {

    }

    bool check(string s)
    {
        if (s.size() == 1) return true;

        int start = 0;
        int last = s.size() - 1;

        while (start < last)
        {
            if (s[start] != s[last]) return false;
            start++;
            last--;
        }

        return true;
    }
};