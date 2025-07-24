
#include <stack>
using namespace std;

struct TreeNode {
	int val;
	TreeNode* left;
	TreeNode* right;
	TreeNode() : val(0), left(nullptr), right(nullptr) {}
	TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
	TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}

};

class Solution {
public:
    int kthSmallest(TreeNode* root, int k) {
		int now = 1;
		stack<TreeNode*> stack;		//用栈来回溯

		while (!stack.empty() || root)	//栈不为空或者root不是空值，就循环
		{
			while (root)				//如果这个节点不是空的，就一直左子节点压进栈中
			{
				stack.push(root);	
				root = root->left;
			}

			if (now == k) break;		//如果这个节点就是k，直接退出循环

			root = stack.top();			//目前遍历的节点是栈顶
			stack.pop();				
			root = root->right;			//变成右节点再重复上面的过程

			now++;
		}

		return stack.top()->val;
    }
};