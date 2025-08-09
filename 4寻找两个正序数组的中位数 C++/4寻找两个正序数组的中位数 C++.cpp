#include <vector>
#include <algorithm>

using namespace std;

class Solution {
public:
    double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {
        
        //找到第k小的数，就是中位数

        //思路：
        //A数组切一刀，B数组切一刀
        //比较A[i-1]和B[j-1]，谁小，谁前面就可以全部丢掉 

        //切的位置下标 i,j  
        //k = i+j = (m+n)/2
        //(i+j) = (m+n+1)/2 别忘了这是int

        //所以要保证两个点
        //1.小的数组是A，大的数组是B
        //2.A[i-1] < B[j-1]

        if (nums1.size() > nums2.size())
        {
            swap(nums1, nums2);
        }

        int n = nums1.size();
        int m = nums2.size();

        int left = -1;
        int right = n+1;        //这里要是n+1！为什么： right = n 是合法的，说明，右边没选

        int i;

        while (left + 1 < right)
        {
            i = left + (right - left) / 2;
            int j = (m + n + 1) / 2 - i;

            int Aleft = i - 1 == -1 ? INT_MIN : nums1[i-1];
            int Aright = i == n ? INT_MAX : nums1[i];
            int Bleft = j - 1 == -1 ? INT_MIN : nums2[j-1];
            int Bright = j == m ? INT_MAX : nums2[j];

            //小中大 小于 大中小
            if (max(Aleft, Bleft) < min(Aright, Bright))
            {
                return (n + m) % 2 ? max(Aleft, Bleft) : (float)(max(Aleft, Bleft) + min(Aright, Bright)) / 2;
            }

            if (Aleft > Bright) right = i;
            else if (Bleft > Aright) left = i;
        }

        return 0;
    }
};


int main()
{
    Solution s;
    vector<int> nums1{2};
    vector<int> nums2{1,3};
    s.findMedianSortedArrays(nums1,nums2);
}