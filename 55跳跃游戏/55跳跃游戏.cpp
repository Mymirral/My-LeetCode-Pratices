#include <vector>
using namespace std;

class Solution {
public:
    bool canJump(vector<int>& nums) {

        if (nums.size() == 1) return true;

        int maxReach = 0;

        for (int i = 0; i < nums.size()-1; i++)
        {
            maxReach--;
            if (maxReach < nums[i]) maxReach = nums[i];
            if (maxReach == 0 && nums[i] == 0) return false;
        }

        return maxReach > 0;
    }
};

int main()
{
    vector<int> nums = { 2,0,0 };
    Solution s;
    s.canJump(nums);
}