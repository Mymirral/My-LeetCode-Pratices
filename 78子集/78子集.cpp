
#include <vector>
using namespace std;

class Solution {
public:
    vector<vector<int>> res;
    vector<int> path;

    vector<vector<int>> subsets(vector<int>& nums) {

        vector<bool> used(nums.size(), false);

        dfs(nums, used, 0);

        return res;
    }

    void dfs(vector<int>& nums, vector<bool>& used, int start)
    {

        res.push_back(path);    //添加[]

        for (int i = start; i < nums.size(); i++)
        {
            if (used[i]) continue;

            path.push_back(nums[i]);
            
            used[i] = true;

            dfs(nums, used,i+1);

            used[i] = false;
            path.pop_back();
        }
    }
};

void main()
{
    Solution S;
    vector<int> x = { 1, 2, 3 };
    S.subsets(x);
}