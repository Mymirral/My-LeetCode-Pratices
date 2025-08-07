#include <vector>
using namespace std;

class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {

        if (matrix.empty() || matrix[0].empty()) return false;
        if (matrix[0][0] > target) return false;

        int left = -1;
        int right = matrix.size();

        while (left + 1 < right)
        {
            int mid = left + (right - left) / 2;
            if (matrix[mid][0] >= (target+1)) right = mid;
            else left = mid;
        }

        int targetRow = right - 1;

        left = -1;
        right = matrix[0].size();

        while (left +1 < right)
        {
            int mid = left + (right - left) / 2;
            if (matrix[targetRow][mid] >= (target + 1)) right = mid;
            else left = mid;
        }

        return target == matrix[targetRow][right-1];
    }
};