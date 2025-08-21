#include <unordered_map>
#include <vector>
#include <string>

using namespace std;

// 当前遍历到的下标index，所在位置是否能组成，
// dp[i] = dp[i - word.size] && word

class Solution {
public:
    bool wordBreak(string s, vector<string>& wordDict) {
        unordered_map<string, int> map;

        int len = s.size();

        //字母对应的个数
        for (auto word : wordDict)
        {
            map[word] = word.size();
        }

        vector<bool> dp;
        dp.resize(len+1,false); //注意是len+1

        dp[0] = true; //哨兵位，如果s根本就没有，返回 true;

        for (int i = 1; i < len+1; i++)
        {
            for (int j = 0; j < wordDict.size(); j++)
            {
                int newlen = i - map[wordDict[j]];

                //如果newlen < 0 说明不匹配啦
                if (newlen >= 0)
                {
                    string newword = s.substr(newlen, map[wordDict[j]]);
                    dp[i] = dp[newlen] && map[newword];
                    if (dp[i]) break;
                }
            }
        }

        return dp[len];
    }
};

int main()
{
    Solution s;
    vector<string> x = { "apple","pen" };
    s.wordBreak("applepenapple", x);
}