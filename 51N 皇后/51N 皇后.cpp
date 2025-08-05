#include <string>
#include <vector>
using namespace std;


class Solution {

public:
	vector<vector<string>> res;
	vector<string> path;

	vector<vector<string>> solveNQueens(int n) {
		vector<vector<bool>> used(n, vector<bool>(n, false));

		dfs(used, n,n,0);

		return res;
	}

	void dfs(vector<vector<bool>>& used,int n, int remain , int row)
	{
		if (remain == 0)
		{
			res.push_back(path);
			return;
		}

		string s(n, '.');

		for (int i = 0; i < n; i++)
		{
			if (canPlace(used, row, i))
			{
				s[i] = 'Q';
				used[row][i] = true;
				remain--;
				path.push_back(s);

				dfs(used, n, remain, row + 1);


				s[i] = '.';
				used[row][i] = false;
				remain++;
				path.pop_back();
			}
		}
	}

	bool canPlace(vector<vector<bool>>& used, int r, int c)
	{
		int row = r;
		int col = c;

		//up
		while (row >= 0)
		{
			if (used[row][col]) return false;
			row--;
		}

		//right&up
		row = r;
		col = c;
		while (row >= 0 && col < used[0].size())
		{
			if (used[row][col]) return false;
			row--;
			col++;
		}

		//left&up
		row = r;
		col = c;
		while (row >= 0 && col >= 0)
		{
			if (used[row][col]) return false;
			row--;
			col--;
		}

		return true;

	}
};