#include <string>
#include <vector>
using namespace std;

class Solution {
public:

	vector<vector<string>> res;
	vector<string> path;

	vector<vector<string>> partition(string s) {
		dfs(s,0);
		return res;
	}

	//切，然后遍历子串。 ← 
	//是回文，加入队列，  |
	//对接下来的子串， ---
	void dfs(string& s, int start)
	{
		if (start == s.size())
		{
			res.push_back(path);
			return;
		}

		for (int end = start; end < s.size(); end++)
		{
			if (!check(s, start, end)) continue;

			path.push_back(s.substr(start, end - start + 1));
			dfs(s, end+1);
			path.pop_back();
		}
	}

	bool check(string& s, int start, int end)
	{
		while (start < end)
		{
			if (s[start] != s[end]) return false;
			start++;
			end--;
		}

		return true;
	}
};