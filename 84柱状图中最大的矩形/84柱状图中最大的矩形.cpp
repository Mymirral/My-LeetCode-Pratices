#include <stack>
#include <vector>
using namespace std;

class Solution {
public:
    int largestRectangleArea(vector<int>& heights) {

        //最小长度是最底层一行的矩形面积
        int max = 0;
        stack<int> stack;

        //单调栈：
        //递增栈！
        //1. 如果下一个数比栈顶小， 当前数是栈顶的右界
        //2. 左界就是弹出栈顶后的上一个数

        //变为前后都是0的哨兵
        vector<int> newheights(heights.size() + 2, 0);
        copy(heights.begin(), heights.end(), newheights.begin() + 1);

        int index = 0;
        stack.push(index++);

        while (index != newheights.size())
        {
            //当前比栈顶小，当前是栈顶的右界
            while(newheights[index] < newheights[stack.top()])
            {
                int h = newheights[stack.top()]; stack.pop();

                //左界是上一个栈顶
                //宽度就是右界减左界 - 1
                int w = index - stack.top() - 1;
                max = std::max(max, h * w);
            }

            stack.push(index);
            index++;
        }
        return max;
    }
};