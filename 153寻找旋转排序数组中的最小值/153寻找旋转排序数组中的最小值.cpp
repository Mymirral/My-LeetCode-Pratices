#include <vector>
#include <algorithm>

using namespace std;

class Solution {
public:
    int findMin(vector<int>& nums) {
        int left = -1;
        int right = nums.size();

        int mid;

        int min = 5000;

        while (left + 1 < right)
        {
            mid = left + (right - left) / 2;

            min = std::min(std::min(std::min(nums[left + 1], min),nums[mid]),nums[right-1]);

            //找左右两边哪个有序，无序的那边才有最小值
            if (nums[mid] > nums[left + 1]) left = mid;
            else right = mid;
        }

        return min;
    }
};