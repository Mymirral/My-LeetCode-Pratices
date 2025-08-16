#include <vector>
using namespace std;

class Solution {
public:
    int maxProfit(vector<int>& prices) {

		int max = INT32_MIN;
		int res = 0;

		for (int i = prices.size() - 1 ; i >= 0; i--)
		{
			if (prices[i] > max) max = prices[i];
			else res = std::max(res, max - prices[i]);
		}

		return res;
    }
};