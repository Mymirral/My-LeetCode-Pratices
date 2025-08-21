#include <vector>
using namespace std;

class Solution {
public:
    long long minArraySum(vector<int>& nums, int k) {
        int sum= 0;
        for (auto num : nums)
        {
            sum += num;
        }

        int cut = 0;
        for (auto num : nums)
        {
            cut += num;

            if (cut % k == 0)
            {
                sum -= cut;
                cut = 0;
            }
        }

        return sum;
    }
}; 