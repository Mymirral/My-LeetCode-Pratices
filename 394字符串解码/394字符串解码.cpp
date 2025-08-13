#include <string>
#include<stack>
#include <iostream>
using namespace std;

class Solution {
public:

	/*
	*   栈模拟
		栈1 保存数字（重复次数）。
		栈2 保存前一层的字符串（进入 [ 前的结果）。

		流程：
		遇到数字 → 更新 curr_num（注意多位数，例如 "12[a]"）。
		遇到 [ → 把 curr_num 和 curr_str 压栈，清空 curr_num 和 curr_str，开始新的片段。
		遇到字母 → 直接加到 curr_str 末尾。
		遇到 ] → 出栈得到上一个 num 和上一个字符串，把 curr_str 重复 num 次后接到上一个字符串后面，赋给 curr_str。
		最终 curr_str 就是答案。

	*/

	string decodeString(string s) {
		string cur = "";
		int num;
		stack<string> strs;
		stack<int> nums;

		for (auto c : s)
		{
			//数字
			if (c <= '9' && c >= '0')
			{
				//没有多位
				if (num == -1)
				{
					num = c - '0';
				}
				//多位
				else 
				{
					num *= 10;
					num += c - '0';
				}
			}

			//字母
			else if (c >= 'a' && c <= 'z')
			{
				cur.push_back(c);
			}

			//左括号
			else if (c == '[')
			{
				strs.push(cur);
				nums.push(num);

				cur.clear();
				num = -1;
			}

			//右括号
			else if (c == ']')
			{
				//次数
				int time = nums.top();
				nums.pop();
				string str = cur;

				for (int i = 0; i < time; i++)
				{
					cur += str;
				}

				str = strs.top();
				strs.pop();
				cur = str + cur;
			}
		}

		return cur;
	}
};