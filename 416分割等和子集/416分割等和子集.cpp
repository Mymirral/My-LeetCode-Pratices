#include <vector>
using namespace std;

class Solution {
public:
    bool canPartition(vector<int>& nums) {
        //总和是偶数，就可以尝试分割，是奇数，返回false

        int sum = 0;
        for (int i = 0; i < nums.size(); i++)
        {
            sum += nums[i];
        }

        if (sum % 2) return false;

        int target = sum / 2;

        //目标,数组内能的和 能等于target
        //找零钱..那道题的类似,但是数量有限
        //494 目标和
        vector<bool> dp(target+1,false);

        dp[0] = true;
        
        
        //背包问题 ， 有限背包
        for (auto num : nums)
        {
            for (int i = target; i >= num ; i--) //倒序是有限背包
            {
                dp[i] = dp[i - num] || dp[i];
            }
        }

        return dp[target];
    }
};

int main()
{
    vector<int> x = { 3,3,6,8,16,16,16,18,20 };
    Solution s;
    s.canPartition(x);
}