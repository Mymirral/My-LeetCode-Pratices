#include <vector>
#include <algorithm>

using namespace std;

class Solution {
public:
    int sum;
    vector<int> path;
    vector<vector<int>> res;

    vector<vector<int>> combinationSum(vector<int>& candidates, int target) {
        sort(candidates.begin(), candidates.end()); //排序

        dfs(candidates,target,0);
        return res;
    }

    // start 指： 你只能从这一个下标开始，不能往前找
    void dfs(vector<int>& candidates,int target,int start)
    {
        //是否继续循环的条件
        if (sum > target || res.size() >= 150) return;
        if (sum == target)
        {
            res.push_back(path);
            return;
        }

        for (int i = start; i < candidates.size(); i++)
        {
            sum += candidates[i];
            path.push_back(candidates[i]);

            dfs(candidates, target,i);

            sum -= candidates[i];
            path.pop_back();
        }
    }
};