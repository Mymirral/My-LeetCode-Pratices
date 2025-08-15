
#include <vector>
using namespace std;

class Solution {
public:
    int findKthLargest(vector<int>& nums, int k) {
        return quickSelect(nums, 0, nums.size() - 1, k);
    }

    int quickSelect(vector<int>& nums, int left, int right, int k)
    {
        if (left == right) return nums[left];

        int pivot = nums[left + rand()%(right-left + 1)];

        int leftMax = left;
        int rightMin = right;

        int index = left;

        while (index <= rightMin)
        {
            //当前小于基准
            if (nums[index] < pivot)
            {
                swap(nums[leftMax], nums[index]);
                index++;
                leftMax++;
            }
            //当前大于基准
            else if(nums[index] > pivot)
            {
                swap(nums[rightMin], nums[index]);
                rightMin--;
            }
            else
            {
                index++;
            }
        }

        int target = nums.size() - k;

        if (target >= leftMax && target <= rightMin) return pivot;
        else if (target < leftMax) return quickSelect(nums, left, leftMax-1,k);
        else return quickSelect(nums, rightMin+1, right,k);
    }
};