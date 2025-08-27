#include <string>
#include <vector>
using namespace std;

class Solution {
public:
	string longestPalindrome(string s) {

		int len = s.size();
		int start = 0;

		int maxlen = 0;

		// 记录 head, tail 
		vector<vector<bool>> record(len, vector<bool>(len, false));

		//一个和两个的
		for (int i = 0; i < len; i++)
		{
			record[i][i] = true;
			maxlen = max(maxlen, 1);

			//单个字母一致的
			int j = 1;
			if (i + 1 < len && s[i] == s[i + 1])
			{
				record[i][i + 1] = true;
				start = i;
				maxlen = 2;
			}
		}

		//外层循环 ： 可能的长度
		for (int  L = 3; L <= len; L++)
		{
			//内层循环 ： 所有起点
			for (int head = 0; head + L - 1 < len; head++)
			{
				int tail = head + L - 1;
				if (s[head] == s[tail] && record[head + 1][tail - 1])
				{
					maxlen = max(maxlen, L);
					start = head;
					record[head][tail] = true;
				}
			}
		}

		return s.substr(start, maxlen);
	}
};

int main()
{
	Solution s;
	s.longestPalindrome("ccc");
}