#include <queue>
#include <vector>
using namespace std;

class MedianFinder {
public:

    priority_queue<int,vector<int>,less<int>> max;
    priority_queue<int,vector<int>,greater<int>> min;

    int size;

    MedianFinder() {
        size = 0;
    }

    void addNum(int num) {

        if (size == 0) max.push(num);
        else if (num > max.top()) min.push(num);
        else max.push(num);

        if(max.size() > min.size() + 1)
        {
            min.push(max.top());
            max.pop();
        }

        if(min.size() > max.size() + 1)
        {
            max.push(min.top());
            min.pop();
        }

        size++;
    }

    double findMedian() {
        if (size % 2) return min.size() > max.size() ? min.top()*1.0 : max.top()*1.0;
        return (float)(min.top() + max.top()) / 2;
    }
};

int main()
{
    MedianFinder x;
    x.addNum(1);
    x.addNum(2);

}