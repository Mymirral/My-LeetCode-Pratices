#include <vector>
#include <unordered_map>
using namespace std;

class Solution {
public:
    vector<int> presum;
    unordered_map<int, int> presumMap;

    int res;

    int subarraySum(vector<int>& nums, int k) {
        int sum = 0;
        presum.push_back(sum);

        for (int i = 0; i < nums.size(); i++)
        {
            sum += nums[i];
            presum.push_back(sum);
        }

        for (int i = 0; i < presum.size(); i++)
        {
            res += presumMap[presum[i] - k];
            presumMap[presum[i]]++;
        }

        return res;
    }
};