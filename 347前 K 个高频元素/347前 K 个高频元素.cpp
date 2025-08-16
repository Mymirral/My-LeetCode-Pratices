#include <vector>
#include <unordered_map>
using namespace std;

class Solution {
public:

    unordered_map<int, int> map;

    vector<int> topKFrequent(vector<int>& nums, int k) {

        vector<int> freq;

        for (auto num : nums)
        {
            map[num]++;
        }

        for (auto m : map)
        {
            freq.push_back(m.first);
        }

        quickSort(freq, 0, freq.size() - 1);

        vector<int> res;
        res.insert(res.end(), freq.begin(), freq.begin() + k);

        return res;
    }

    void quickSort(vector<int>& nums, int left, int right)
    {
        if (left >= right) return;

        int pivot = map[nums[right]];
        int index = left;
        
        for (int i = left; i < right; i++)
        {
            if (pivot < map[nums[i]])
            {
                //降序
                swap(nums[index], nums[i]);
                index++;
            }
        }

        swap(nums[right], nums[index]);

        quickSort(nums, left, index - 1);
        quickSort(nums, index + 1, right);
    }
};

int main()
{
    Solution s;
    vector<int > t = { 1,1,1,2,2,3 };
    s.topKFrequent(t,2);
}