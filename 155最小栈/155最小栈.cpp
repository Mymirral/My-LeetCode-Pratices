#include <stack>
#include <algorithm>

using namespace std;

class MinStack {
public:

    stack<int> main;
    stack<int> min;

    MinStack() {

    }

    void push(int val) {
        if (min.empty() || min.top() > val) min.push(val);
        else min.push(min.top());
        main.push(val);
    }

    void pop() {
        main.pop();
        min.pop();
    }

    int top() {
        return main.top();
    }

    int getMin() {
        return min.top();
    }
};

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack* obj = new MinStack();
 * obj->push(val);
 * obj->pop();
 * int param_3 = obj->top();
 * int param_4 = obj->getMin();
 */