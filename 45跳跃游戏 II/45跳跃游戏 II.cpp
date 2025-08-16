#include <vector>
using namespace std;

class Solution {
public:
    int jump(vector<int>& nums) {

        int n = nums.size();
        if (n <= 1) return 0;

        int maxReach=0;
        int step=0;

        int curReach = 0;
        
        for (int i = 0; i < n-1; i++)
        {
            //检查是否需要更新最远到达的位置
            if (maxReach < i + nums[i])
            {
                maxReach = i + nums[i];
            }

            if (i == curReach)
            {
                step++;
                curReach = maxReach;
            }
        }

        return step;
    }
};