#include <vector>
#include <stack>
using namespace std;


/* 单调栈不行
* class Solution {
public:
    int lengthOfLIS(vector<int>& nums) {
        stack<int> stack;

        for (auto num : nums)
        {
            while (!stack.empty() && stack.top() >= num)
            {
                stack.pop();
            }
            stack.push(num);
        }

        return stack.size();
    }
};
*/

class Solution {
public:
    int lengthOfLIS(vector<int>& nums) {
        int max;

        vector<int> dp(nums.size(),1);
        dp[0] = 1;

        for (int i = 1  ; i < nums.size(); i++)
        {
            for (int j = i-1; j >= 0; j--)
            {
                if (nums[j] < nums[i]) {
                    dp[i] = std::max(dp[i], dp[j] + 1);
                    max = std::max(max, dp[i]);
                }
            }
        }

        return max;
    }
};

int main()
{
    Solution s;
    vector<int> x = { 0,1,0,3,2,3 };
    s.lengthOfLIS(x);
}