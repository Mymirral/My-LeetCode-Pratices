#include <vector>
using namespace std;


class Solution {
public:
	int minPathSum(vector<vector<int>>& grid) {

		int m = grid.size();
		int n = grid[0].size();

		vector<vector<int>>dp(m, vector<int>(n, 0));

		dp[m - 1][n - 1] = grid[m - 1][n - 1];

		//最后一行
		for (int i = m - 2; i >= 0; i--)
		{
			dp[i][n - 1] = dp[i + 1][n - 1] + grid[i][n - 1];
		}

		//最后一列
		for (int i = n - 2; i >= 0; i--)
		{
			dp[m-1][i] = dp[m-1][i+1] + grid[m-1][i];
		}

		for (int row = m - 2; row >= 0; row--)
		{
			for (int col = n - 2; col >= 0; col--)
			{
				dp[row][col] = min(dp[row + 1][col], dp[row][col + 1]) + grid[row][col];
			}
		}

		return dp[0][0];
	}
};

int main()
{
	vector<vector<int>> x{
		{1,3,1},
		{1,5,1},
		{4,2,1}
	};
	Solution s;
	s.minPathSum(x);
}