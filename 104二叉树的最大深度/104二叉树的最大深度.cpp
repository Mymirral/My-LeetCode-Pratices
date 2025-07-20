#include <queue>
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
    int maxDepth(TreeNode* root) {
		queue<TreeNode*> q;
		int floor = 0;

		if(root) q.push(root);

		while (!q.empty())
		{
			int loop = q.size();
			for (int i = 0; i < loop; i++)
			{
				root = q.front();
				q.pop();

				if (root->left) q.push(root->left);
				if (root->right) q.push(root->right);	
			}
			
			floor++;
		}

		return floor;
    }
};
