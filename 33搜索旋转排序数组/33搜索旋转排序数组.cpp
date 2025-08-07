#include <vector>
using namespace std;

class Solution {
public:
    int search(vector<int>& nums, int target) {

        int left = -1;
        int right = nums.size();

        int mid;

        while (left +1 < right)
        {
            mid = left + (right - left) / 2;
            if (nums[mid] == target) return mid;
            if (nums[left + 1] == target) return left + 1;
            if (nums[right - 1 == target]) return right - 1;

            if (nums[mid] > nums[left + 1]) {
                if (nums[left + 1] <= target && nums[mid] > target)//因为是开区间搜索,left可能会超边界，所以left+1要加个等于号
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }
            else
            {
                if (target > nums[mid] && target <= nums[right - 1])    
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }
        }

        return -1;
    }
};

int main()
{
    Solution s;
    vector<int> v = { 4,5,6,7,0,1,2 };
    s.search(v,3);
}