#include <vector>
using namespace std;

//回溯试试
//超时！
//class Solution {
//public:
//
//    int res = 0;
//
//    int uniquePaths(int m, int n) {
//        if (m == 1 || n == 1) {
//            res++;
//            return 1;
//        }
//
//        uniquePaths(m-1,n);
//        uniquePaths(m, n - 1);
//
//        return res;
//    }
//};

//动态规划
class Solution {
public:
	int uniquePaths(int m, int n) {
		vector<vector<int>> dp(m, vector<int>(n, 1));

		int row = m;
		int col = n;

		for (int row = m - 2; row >= 0; row--)
		{
			for (int col = n - 2; col >= 0; col--)
			{
				dp[row][col] = dp[row + 1][col] + dp[row][col + 1];
			}
		}

		return dp[0][0];
	}
};

int main()
{
	Solution s;
	s.uniquePaths(3, 7);
}