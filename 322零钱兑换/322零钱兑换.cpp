#include <vector>
using namespace std;

//动态规划， 当前dp[i] = Min(dp[i - coins[j]]) + 1
//当前值的少硬币个数， 等于 （当前值 - 硬币面值） + 1
// +1 就是加的那个硬币

class Solution {
public:
    int coinChange(vector<int>& coins, int amount) {

        if (amount == 0) return 0;

        vector<int> dp;

        dp.resize(amount+1, -1);

        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            int min = INT32_MAX;

            for (auto coin : coins)
            {
                if (i - coin >= 0 && dp[i - coin]!= -1)
                {
                    min = std::min(dp[i - coin], min);
                }               
            }
            if (min == INT32_MAX || min == -1) dp[i] = -1;
            else dp[i] = min + 1;
        }

        return dp[amount];
    }
};

int main()
{
    Solution s;
    vector<int> x = { 2 };
    s.coinChange(x,1);
}