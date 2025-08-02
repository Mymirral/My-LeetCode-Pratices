
#include <vector>
#include <unordered_map>
#include <string>
using namespace std;


class Solution {
public:
    unordered_map<char, string> map;
    vector<string> res;
    string path;

    vector<string> letterCombinations(string digits) {
        
        map['2'] = "abc";
        map['3'] = "def";
        map['4'] = "ghi";
        map['5'] = "jkl";
        map['6'] = "mno";
        map['7'] = "pqrs";
        map['8'] = "tuv";
        map['9'] = "wxyz";

        if (digits.size() < 1) return res;

        dfs(digits, 0);

        return res;
    }

    void dfs(string& digits,int start)
    {
        if (path.size() == digits.size())
        {
            res.push_back(path);
            return;
        }

        char num = digits[start];
        string letters = map[num];

        for (int i = 0; i < letters.size(); i++)
        {
            path.push_back(letters[i]);

            dfs(digits,start+1);

            path.pop_back();
        }
    }
};