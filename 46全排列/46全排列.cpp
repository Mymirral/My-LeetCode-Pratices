#include <vector>
using namespace std;

class Solution {
public:
    vector<int> path;
    vector<vector<int>> res;

    vector<vector<int>> permute(vector<int>& nums) {

        vector<bool> used(nums.size(), false);

        dfs(nums, used);

        return res;
    }

    void dfs(vector<int> nums , vector<bool> used)
    {
         if(path.size() == nums.size())
         {
             res.push_back(path);
             return;
         }

         for (int i = 0; i < nums.size(); i++)
         {
             if (used[i]) continue; //这个数已经用过了，下一个循环

             used[i] = true; //标记访问过了
             path.push_back(nums[i]);

             dfs(nums, used);       //再对下一层进行访问

             //回溯
             used[i] = false;
             path.pop_back();
         }
    }
};