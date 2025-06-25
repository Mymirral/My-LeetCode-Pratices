
using namespace std;
#include <stdio.h>
#include <vector>
#include <iostream>


class Solution {
public:
	bool searchMatrix(vector<vector<int>>& matrix, int target) {        //二分查找不太好...

		int m = matrix.size();
		int n = matrix[0].size();

		if (target < matrix[0][0] || target > matrix[m - 1][n - 1]) return false; //目标超出范围

		int row = m-1;
		int col = 0;

		while (row >= 0 && col < n)
		{
			if (matrix[row][col] == target)
			{
				return true;
			}
			else if (matrix[row][col] < target)
			{
				col++;
			}
			else  // matrix[row][col] > target
			{
				row--;
			}
		}


		return false;
	}
};

void main()
{
	// 应该这样写：
	vector<vector<int>> matrix = {
		{1,3,5,7,9},
		{2,4,6,8,10},
		{11,13,15,17,19},
		{12,14,16,18,20},
		{21,22,23,24,25}
	};
	Solution s;
	cout << (s.searchMatrix(matrix, 20) ? "true" : "false") << endl;
}