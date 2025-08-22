#include <vector>
using namespace std;

class Solution {
public:
	int maxProduct(vector<int>& nums) {

		int len = nums.size();

		int maxres = nums[0];

		int maxdp = nums[0];
		int mindp = nums[0];

		for (int i = 1; i < len; i++)
		{
			int mx= maxdp,mi = mindp;
			mindp = min(min(nums[i] * mi, nums[i]), nums[i] * mx);
			maxdp = max(max(nums[i] * mx, nums[i]), nums[i] * mi);
			maxres = max(maxdp, maxres);
		}

		return maxres;
	}
};